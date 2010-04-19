using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace TrainingCatalog
{
    public partial class ExersizeForm : Form
    {
        OleDbConnection connection;
        DataSet categories = new DataSet();
        public ExersizeForm()
        {
            InitializeComponent();
            try
            {
                connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database2.accdb");
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
            int lastExersizeId = 0;
            OleDbCommand cmd = new OleDbCommand();
            String ShortName = String.Empty, Description = String.Empty;
            try
            {
                connection.Open();
                cmd.Connection = connection;

                cmd.CommandText = "select max(ExersizeID) from Exersize";
                lastExersizeId = (int)cmd.ExecuteScalar();
                ShortName = textBox1.Text;
                Description = textBox2.Text;



                cmd.CommandText = String.Format("insert into Exersize (ExersizeID,ShortName,Description) values({0},'{1}','{2}')",lastExersizeId + 1, ShortName, Description);
                cmd.ExecuteNonQuery();
                AddLinkToExersizeCategories(lastExersizeId + 1);
            }
            catch (Exception ex)
            {
                ok = false;
                MessageBox.Show(ex.Message);
            }
            if(ok) MessageBox.Show("Упражнение успешно добавленно");
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            foreach(int index in chkLstExersizeCategories.CheckedIndices)
            {
                chkLstExersizeCategories.SetItemChecked(index, false);
            }
            
            connection.Close();
        }

        private void ExersizeForm_Load(object sender, EventArgs e)
        {
            textBox1.MaxLength = 150;
            textBox2.MaxLength = 1000;
            LoadExersizeCategories();
            
        }
        private void LoadExersizeCategories()
        {
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandText = "select * from ExersizeCategory order by Name";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(categories);

                foreach(DataRow dr in categories.Tables[0].Rows)
                {
                    chkLstExersizeCategories.Items.Add(dr["Name"], false);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            connection.Close();
            cmd = null;
        }
        private void AddLinkToExersizeCategories(int ExersizeID)
        {
            // assume that connection alredy open and DONT close 
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            foreach (int index in chkLstExersizeCategories.CheckedIndices)
            {
                cmd.CommandText = "select max(ID)+1 from ExersizeCategoryLink";
                int lastId = (int)cmd.ExecuteScalar();
                int exersizeCategoryId = (int)categories.Tables[0].Rows[index]["ID"];
                cmd.CommandText = string.Format("insert into ExersizeCategoryLink values({0},{1},{2})", lastId, ExersizeID, categories.Tables[0].Rows[index]["ID"]);
                cmd.ExecuteNonQuery();
            }

            cmd = null;
        }
    }
}
