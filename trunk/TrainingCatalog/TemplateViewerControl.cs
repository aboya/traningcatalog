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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;

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
            
            InitializeComponent();

            connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            command = new OleDbCommand();
            command.Connection = connection;
            FillCategoryList();

            this.dt.Columns.Add("Column1", typeof(string));
            this.dt.Columns.Add("Column2", typeof(string));
            this.dt.Columns.Add("Column3", typeof(string));

            for (int i = 0; i < 5; i++)
            {
                string rowNumber = Convert.ToString(i + 1);

                this.dt.Rows.Add(new object[] { "Item1-" + rowNumber, "Item2-" + rowNumber, "Item3-" + rowNumber });
            }

            gvMain.DataSource = dt;
        }
        public void AddRow()
        {
            //gvMain.RepositoryItems.Add(new DevExpress.XtraEditors.Repository.RepositoryItem());   
           // this.dt.Rows.Add(new object[] { "Item1-" + 5, "Item2-" + 5, "Item3-" + 5 });
            this.gridView1.AddNewRow();
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

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {

            string rowNumber = Convert.ToString(this.dt.Rows.Count + 1);

            //for (int i = 0; i < this.gridView1.Columns.Count; i++)
            //{
            //    this.gridView1.SetRowCellValue(e.RowHandle, this.gridView1.Columns[i].FieldName, string.Format("Item{0}-{1}", i + 1, rowNumber));
            //}
            gridView1.SetRowCellValue(e.RowHandle, this.gridView1.Columns[2].FieldName, "asdasd");

            DevExpress.XtraEditors.Repository.RepositoryItemComboBox c;
	       

        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            //GridView view = sender as GridView;
            //if (e.Column is DevExpress.XtraGrid.Columns.GridColumn)
            //{
            //    DataView dv = (gridView1.DataSource as DataView);
            //    if (e.IsGetData)
            //        e.Value = dv[e.ListSourceRowIndex]["Id"];
            //    else
            //        dv[e.ListSourceRowIndex]["Id"] = e.Value;
            //}
        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            int a;
            a = 0;
            if (e.Column.AbsoluteIndex == 0)
            {
                RepositoryItemComboBox cb = e.RepositoryItem as RepositoryItemComboBox;
                if(cb.Items.Count == 0)
                cb.Items.Add("1");
                ComboBoxEdit c;
              
                //foreach (DataRow dr in ExersizeCategoryTable.Tables[0].Rows)
                //{
                //    cb.Items.Add(dr["Name"]);
                //}
                ImageComboBoxEdit ie;

            }
        }

    }
}
