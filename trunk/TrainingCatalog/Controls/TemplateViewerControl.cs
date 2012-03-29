using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Configuration;
using System.Diagnostics;
using TrainingCatalog.BusinessLogic.Types;
using TrainingCatalog.BusinessLogic;


namespace TrainingCatalog
{
    public partial class TemplateViewerControl : UserControl
    {

        DataSet ExersizeCategoryTable = new DataSet();
        //List<ExersizeSource> Exersizes = new List<ExersizeSource>();
        SqlCeConnection connection;
        SqlCeCommand command;
        SqlCeDataAdapter table = new SqlCeDataAdapter();
        DataTable dt = new DataTable();
        public TemplateViewerControl()
        {
            InitializeComponent();
           // this.gv_templates.EditMode = DataGridViewEditMode.EditOnEnter;
            this.gv_templates.AllowUserToAddRows = false;
            this.gv_templates.AllowUserToDeleteRows = false;
            


        }

        public List<TemplateExersizesType> GetTemplateExersizes()
        {
            List<TemplateExersizesType> res = new List<TemplateExersizesType>();
            foreach (DataGridViewRow dr in gv_templates.Rows)
            {
                int exersizeId = Convert.ToInt32((dr.Cells["Exersize"] as DataGridViewComboBoxCell).Value);
                int weight = Convert.ToInt32((dr.Cells["Weight"] as DataGridViewTextBoxCell).Value);
                int count = Convert.ToInt32((dr.Cells["Count"] as DataGridViewTextBoxCell).Value);
                int categoryId = Convert.ToInt32((dr.Cells["Category"] as DataGridViewComboBoxCell).Value);
                int id = 0;
                if (dr.Tag is int) id = Convert.ToInt32(dr.Tag);
                res.Add(new TemplateExersizesType()
                {
                    ExersizeID = exersizeId,
                    Count = count,
                    Weight = weight,
                    ID = id,
                    ExersizeCategoryID = categoryId > 0 ? (int?)categoryId : null
                });
            }
            return res;
        }
        public void LoadTemplateExersizes(List<TemplateExersizesType> input)
        {
            int i = 0;
            gv_templates.Rows.Clear();
            foreach (TemplateExersizesType e in input)
            {
                this.AddNewRow();   
                gv_templates.Rows[i].Cells["Weight"].Value = e.Weight;
                gv_templates.Rows[i].Cells["Count"].Value = e.Count;
                //this order is important
                DataGridViewComboBoxCell cellCategory = gv_templates.Rows[i].Cells[0] as DataGridViewComboBoxCell;
                if (e.ExersizeCategoryID.HasValue)
                {
                    cellCategory.Value = e.ExersizeCategoryID.Value;
                }
                else
                {
                    cellCategory.Value = -1;
                }
                gv_templates.Rows[i].Tag = e.ID;
                gv_templates.Rows[i].Cells["Exersize"].Value = e.ExersizeID;
                i++;
            }
        }


        public void AddNewRow()
        {
            gv_templates.Rows.Add();
        }
        private void FillCategoryList()
        {
            try
            {
                connection.Open();
                command.CommandText = "select ID,Name from ExersizeCategory order by Name";
                table.SelectCommand = command;


                table.Fill(ExersizeCategoryTable);
                DataRow dr = ExersizeCategoryTable.Tables[0].NewRow();
                dr["ID"] = "-1";
                dr["Name"] = "Все";
                ExersizeCategoryTable.Tables[0].Rows.InsertAt(dr, 0);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        private List<ExersizeSource> FillExersizes(int categoryId)
        {
            List<ExersizeSource> Exersizes = new List<ExersizeSource>();
            try
            {

                using (SqlCeCommand cmd = new SqlCeCommand())
                {
                    cmd.Connection = connection;
                    connection.Open();
                    Exersizes = TrainingBusiness.GetExersizes(cmd, categoryId);
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
            return Exersizes;
        }
        private void gv_templates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //private void gv_templates_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    //ComboBox combo = e.Control as ComboBox;
            
        //    //if (combo != null)
        //    //{
        //    //    // Remove an existing event-handler, if present, to avoid 
        //    //    // adding multiple handlers when the editing control is reused.
        //    //    combo.SelectedIndexChanged -=
        //    //        new EventHandler(ComboBox_SelectedIndexChanged);

        //    //    // Add the event handler. 
        //    //    combo.SelectedIndexChanged +=
        //    //        new EventHandler(ComboBox_SelectedIndexChanged);
        //    //}
        //}

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int a;
            //a = 0;
            //ComboBox cb = sender as ComboBox;
            //if (cb != null && cb.SelectedValue != null && cb.SelectedValue is int)
            //{
            //    int categoryId = Convert.ToInt32((cb.SelectedValue));
            //    FillExersizes(categoryId);
            //    //MessageBox.Show(string.Format("categoryId={0}",categoryId));
            //    DataGridViewComboBoxCell cell = gv_templates[1, 0] as DataGridViewComboBoxCell;
             
            //    if (cell != null)
            //    {
            //        cell.DataSource = Exersizes.Tables[0];
            //        cell.ValueMember = "ExersizeID";
            //        cell.DisplayMember = "ShortName";
            //    }
            //}
        }

        private void gv_templates_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0 )
            {
                DataGridView gv = (sender as DataGridView);
                if(e.RowIndex >= 0 && e.RowIndex < gv.Rows.Count)
                    OnCnageCategory(gv.Rows[e.RowIndex]);
            }
        }
        private void OnCnageCategory(DataGridViewRow row)
        {
            try
            {
                if (row == null) return;
                int categoryId = Convert.ToInt32((row.Cells[0] as DataGridViewComboBoxCell).Value);
                List<ExersizeSource> exersizes = FillExersizes(categoryId);
                if (exersizes.Count > 0)
                {
                    DataGridViewComboBoxCell exers = (row.Cells[1] as DataGridViewComboBoxCell);
                    exers.DataSource = exersizes;
                    exers.Value = exersizes[0].ExersizeID;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void SetDefaultValuesForNewRow(DataGridViewRow row)
        {
            try
            {
                DataGridViewComboBoxCell cellCategory = row.Cells[0] as DataGridViewComboBoxCell;
                DataGridViewComboBoxCell cellExersize = row.Cells[1] as DataGridViewComboBoxCell;
                DataGridViewTextBoxCell txtWeight = row.Cells[2] as DataGridViewTextBoxCell;
                DataGridViewTextBoxCell txtCount = row.Cells[3] as DataGridViewTextBoxCell;
                row.Cells[4].Value = "-";
                row.Tag = 0;
                cellCategory.Value = -1;

       
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
 
        }
        private void gv_templates_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DataGridView gv = (sender as DataGridView);
            if (gv.IsCurrentCellDirty)
            {
                gv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        
        private void gv_templates_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            SetDefaultValuesForNewRow(gv_templates.Rows[e.RowIndex]);
        }

        private void TemplateViewerControl_Load(object sender, EventArgs e)
        {
            if (ConfigurationManager.ConnectionStrings["db"] != null)
            {
                connection = new SqlCeConnection(dbBusiness.connectionString);
                command = new SqlCeCommand();
                command.Connection = connection;
                FillCategoryList();
                try
                {
                    DataGridViewComboBoxColumn col1 = gv_templates.Columns[0] as DataGridViewComboBoxColumn;
                    col1.ValueMember = "ID";
                    col1.DisplayMember = "Name";
                    col1.DataSource = ExersizeCategoryTable.Tables[0];


                    DataGridViewComboBoxColumn col2 = gv_templates.Columns[1] as 
                        DataGridViewComboBoxColumn;
                    col2.ValueMember = "ExersizeID";
                    col2.DisplayMember = "ShortName";
                    col2.Width = 290;

                    gv_templates.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                    gv_templates.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                    gv_templates.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                    gv_templates.Columns[4].Width = 20;
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }

        private void gv_templates_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;     // Header
            }
            // this need for one click on combobox drop down
            DataGridView gv = (sender as DataGridView);
            gv.BeginEdit(true);
            if (gv.EditingControl is ComboBox)
            {
                gv.BeginEdit(true);
                ComboBox comboBox = (ComboBox)gv.EditingControl;
                comboBox.DroppedDown = true;
            }
            
            if (e.ColumnIndex == 4) // remove button
            {
                object id = Convert.ToInt32(gv_templates.Rows[e.RowIndex].Tag);
                gv_templates.Rows.RemoveAt(e.RowIndex);
                //this.RemoveTrainingTemplateById(id);
            }
        }
        private void gv_templates_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txt = e.Control as TextBox;

            if (txt != null)
            {
                // Remove an existing event-handler, if present, to avoid 
                // adding multiple handlers when the editing control is reused.
                txt.KeyPress -=
                    new KeyPressEventHandler(txt_KeyPress);

                // Add the event handler. 
                txt.KeyPress +=
                    new KeyPressEventHandler(txt_KeyPress);
            }
        }
        private void txt_KeyPress(object sender, KeyPressEventArgs args)
        {
            if ((args.KeyChar < 48 || args.KeyChar > 57) && args.KeyChar != 8)
            {
                args.Handled = true;
 
            }
            
 
        }

        private void gv_templates_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                SelectNextEditableCell(sender as DataGridView);
            }
        }

        private void SelectNextEditableCell(DataGridView dataGridView)
        {
            DataGridViewCell currentCell = dataGridView.CurrentCell;
            if (currentCell != null)
            {
                int nextRow = currentCell.RowIndex;
                int nextCol = currentCell.ColumnIndex + 1;
                if (nextCol >= dataGridView.ColumnCount)
                {
                    nextCol = 0;
                    nextRow++;
                }
                if (nextRow > dataGridView.RowCount)
                {
                    nextRow = 0;
                }
                DataGridViewCell nextCell = dataGridView.Rows[nextRow].Cells[nextCol];
                if (nextCell != null && nextCell.Visible)
                {
                    dataGridView.CurrentCell = nextCell;
                }
            }
        }

        private void gv_templates_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Tab)
            {
                 
            }
        }
        public void AddRowByUser()
        {
            this.AddNewRow();
            if (gv_templates.Rows.Count > 0)
            {
                if (gv_templates.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = gv_templates.SelectedRows[0];
                    gv_templates.Rows[gv_templates.Rows.Count - 1].Cells[0].Value =
                            (selectedRow.Cells[0] as DataGridViewComboBoxCell).Value;
                    gv_templates.Rows[gv_templates.Rows.Count - 1].Cells[1].Value =
                            (selectedRow.Cells[1] as DataGridViewComboBoxCell).Value;
                }
            }
        }



    }
}
