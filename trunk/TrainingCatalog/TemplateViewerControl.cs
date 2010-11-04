using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;
using DevExpress.XtraGrid.Views.BandedGrid;
using System.Web.UI.WebControls;

namespace TrainingCatalog
{
    public partial class TemplateViewerControl : UserControl
    {
        DataSet ExersizeCategoryTable = new DataSet();
        OleDbConnection connection;
        OleDbCommand command;
        OleDbDataAdapter table = new OleDbDataAdapter();
        DataTable dt = new DataTable();
        public TemplateViewerControl()
        {
            dt.Columns.Add(new DataColumn("Id"));
            InitializeComponent();
            InitializeComponent();
            connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            command = new OleDbCommand();
            command.Connection = connection;
          
            FillCategoryList();
        }
        public void AddRow()
        {
            //gvMain.RepositoryItems.Add(new DevExpress.XtraEditors.Repository.RepositoryItem());   
            gridView1.AddNewRow();
            



        }
        public void Save()
        {
 
        }
        private void FillCategoryList()
        {
            try
            {
                connection.Open();
                command.CommandText = "select * from ExersizeCategory";
                table.SelectCommand = command;
                table.Fill(ExersizeCategoryTable);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            connection.Close();
        }
    }
}
