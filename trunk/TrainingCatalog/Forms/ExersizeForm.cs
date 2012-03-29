using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Configuration;
using TrainingCatalog.Forms;
using TrainingCatalog.BusinessLogic.Types;
namespace TrainingCatalog
{
    public partial class ExersizeForm : BaseForm
    {

        DataSet categories = new DataSet();
        public ExersizeForm()
        {
            InitializeComponent();
            try
            {
                connection = new SqlCeConnection(dbBusiness.connectionString);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ok = true;
            
            SqlCeCommand cmd = new SqlCeCommand();
            String ShortName = String.Empty, Description = String.Empty;
            try
            {
                connection.Open();
                cmd.Connection = connection;

                ShortName = textBox1.Text;
                Description = textBox2.Text;



                cmd.CommandText = "insert into Exersize (ShortName,Description) values(@name,@description)";
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = ShortName;
                cmd.Parameters.Add("@description", SqlDbType.NVarChar).Value = Description;
                cmd.ExecuteNonQuery();
                int lastExersizeId = 0;
                cmd.Parameters.Clear();
                cmd.CommandText = "select @@Identity";
                lastExersizeId = Convert.ToInt32(cmd.ExecuteScalar());
                AddLinkToExersizeCategories(lastExersizeId);
            }
            catch (Exception ex)
            {
                ok = false;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            if(ok) MessageBox.Show("Упражнение успешно добавленно");
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            foreach(int index in chkLstExersizeCategories.CheckedIndices)
            {
                chkLstExersizeCategories.SetItemChecked(index, false);
            }

        }

        private void ExersizeForm_Load(object sender, EventArgs e)
        {
            textBox1.MaxLength = 150;
            textBox2.MaxLength = 1000;
            LoadExersizeCategories();
            
        }
        private void LoadExersizeCategories()
        {
            SqlCeCommand cmd = new SqlCeCommand();
            try
            {
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandText = "select * from ExersizeCategory order by Name";
                SqlCeDataAdapter dataAdapter = new SqlCeDataAdapter();
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(categories);

                foreach (DataRow dr in categories.Tables[0].Rows)
                {
                    chkLstExersizeCategories.Items.Add(dr["Name"], false);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            }
            cmd = null;
        }
        private void AddLinkToExersizeCategories(int ExersizeID)
        {
            // assume that connection alredy open and DONT close 
            using (SqlCeCommand cmd = connection.CreateCommand())
            {
                foreach (int index in chkLstExersizeCategories.CheckedIndices)
                {
                    int exersizeCategoryId = (int)categories.Tables[0].Rows[index]["ID"];
                    cmd.CommandText = string.Format("insert into ExersizeCategoryLink (ExersizeId, ExersizeCategoryId) values({0},{1})", ExersizeID, exersizeCategoryId);
                    cmd.ExecuteNonQuery();
                }
            }
         
        }
    }
}
