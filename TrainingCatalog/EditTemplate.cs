using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;

namespace TrainingCatalog
{
    public partial class EditTemplate : Form
    {
        DataSet ExersizeCategoryTable = new DataSet();
        OleDbConnection connection ;
        OleDbCommand command;
        OleDbDataAdapter table = new OleDbDataAdapter();
        DataTable dt = new DataTable();
        public EditTemplate()
        {
            InitializeComponent();
            connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            command = new OleDbCommand();
            command.Connection = connection;
            FillCategoryList();

           
            dt.Columns.Add(new DataColumn("Category", typeof(ComboBox)));
            gvTemplate.DataSource = dt.DefaultView;
        }

        private void btnAddExersize_Click(object sender, EventArgs e)
        {

            int cnt = gvTemplate.Rows.Count;
            //gvTemplate.Rows[cnt - 2].Cells[0] = new ComboBox();
           // DataGridViewComboBoxCell cbExersize = gvTemplate.Rows[cnt-2].Cells[0] as DataGridViewComboBoxCell;
            //foreach (DataRow item in ExersizeCategoryTable.Tables[0].Rows)
            //{
            //    cbExersize.Items.Add(new object[] {item["Name"], item["Id"]} );
               
             
            //}
            DataRow dr = dt.NewRow();
            ComboBox cb = new ComboBox();
            cb.Items.Add("asd");
            dr["Category"] = cb;
            dt.Rows.Add(dr);
            
        }

        private void gvTemplate_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            ComboBox cbCatergory = e.Row.Cells[0].Value as ComboBox;
        }

        private void FillCategoryList()
        {
            try {
                connection.Open();
                command.CommandText = "select * from ExersizeCategory";
                table.SelectCommand = command;
                table.Fill(ExersizeCategoryTable);
                
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            connection.Close();
        }

    }
}
