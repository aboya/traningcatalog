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


namespace TrainingCatalog
{
    public partial class TemplateViewerControl : UserControl
    {
        public class ExersizeSource
        {
            public int ExersizeID {get; set;}
            public string ShortName { get; set; }
            public ExersizeSource() { }
        }
        DataSet ExersizeCategoryTable = new DataSet();
        //List<ExersizeSource> Exersizes = new List<ExersizeSource>();
        SqlCeConnection connection;
        SqlCeCommand command;
        SqlCeDataAdapter table = new SqlCeDataAdapter();
        DataTable dt = new DataTable();
        public TemplateViewerControl()
        {
            InitializeComponent();
           // this.dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            


        }

        public List<TemplateExersizesType> GetTemplateExersizes()
        {
            List<TemplateExersizesType> res = new List<TemplateExersizesType>();
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                int exersizeId = Convert.ToInt32((dr.Cells["Exersize"] as DataGridViewComboBoxCell).Value);
                int weight = Convert.ToInt32((dr.Cells["Weight"] as DataGridViewTextBoxCell).Value);
                int count = Convert.ToInt32((dr.Cells["Count"] as DataGridViewTextBoxCell).Value);
                int id = 0;
                if (dr.Tag is int) id = Convert.ToInt32(dr.Tag);
                res.Add(new TemplateExersizesType() {  ExersizeID = exersizeId, 
                                                        Count = count, 
                                                        Weight = weight, 
                                                        ID = id
                                                    });
            }
            return res;
        }
        public void LoadTemplateExersizes(List<TemplateExersizesType> input)
        {
            int i = 0;
            dataGridView1.Rows.Clear();
            foreach (TemplateExersizesType e in input)
            {
                this.AddNewRow();   
                dataGridView1.Rows[i].Cells["Exersize"].Value = e.ExersizeID;
                dataGridView1.Rows[i].Cells["Weight"].Value = e.Weight;
                dataGridView1.Rows[i].Cells["Count"].Value = e.Count;
                dataGridView1.Rows[i].Tag = e.ID;
                
                i++;
            }
        }

        public void AddNewRow()
        {
            dataGridView1.Rows.Add();
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

                    if (categoryId <= 0)
                    {
                        cmd.CommandText = "select * from Exersize order by ShortName";
                    }
                    else
                    {

                        cmd.CommandText = @"select Exersize.ID, Exersize.ShortName from Exersize 
                                        inner join ExersizeCategoryLink on
                                        ExersizeCategoryLink.ExersizeID = Exersize.ID
                                        where  ExersizeCategoryLink.ExersizeCategoryID = @exersizeCategoryId   
                                        order by ShortName";
                        cmd.Parameters.Add("@exersizeCategoryId", SqlDbType.Int).Value = categoryId;

                    }
                    using (SqlCeDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Exersizes.Add(new ExersizeSource()
                            {
                                ExersizeID = Convert.ToInt32(dr["ExersizeID"]),
                                ShortName = Convert.ToString(dr["ShortName"])

                            });
                        }
                    }

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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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
            //    DataGridViewComboBoxCell cell = dataGridView1[1, 0] as DataGridViewComboBoxCell;
             
            //    if (cell != null)
            //    {
            //        cell.DataSource = Exersizes.Tables[0];
            //        cell.ValueMember = "ExersizeID";
            //        cell.DisplayMember = "ShortName";
            //    }
            //}
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0 )
            {
                DataGridView gv = (sender as DataGridView);
                if(e.RowIndex >= 0)
                    OnCnageCategory(gv.Rows[e.RowIndex]);
            }
        }
        private void OnCnageCategory(DataGridViewRow row)
        {
            if (row == null) return;
            int categoryId = Convert.ToInt32((row.Cells[0] as DataGridViewComboBoxCell).Value);
            Debug.WriteLine(string.Format("categoryId = {0}", categoryId));
            List<ExersizeSource> exersizes =  FillExersizes(categoryId);
            DataGridViewComboBoxCell exers = (row.Cells[1] as DataGridViewComboBoxCell);
            exers.DataSource = exersizes;
            exers.Value = exersizes[0].ExersizeID;
        }
        private void SetDefaultValuesForNewRow(DataGridViewRow row)
        {
            DataGridViewComboBoxCell cellCategory = row.Cells[0] as DataGridViewComboBoxCell;
            DataGridViewComboBoxCell cellExersize = row.Cells[1] as DataGridViewComboBoxCell;
            DataGridViewTextBoxCell txtWeight = row.Cells[2] as DataGridViewTextBoxCell;
            DataGridViewTextBoxCell txtCount = row.Cells[3] as DataGridViewTextBoxCell;
            row.Cells[4].Value = "Remove";
            row.Tag = 0;
            cellCategory.Value = -1;

            if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value =
                            (selectedRow.Cells[0] as DataGridViewComboBoxCell).Value;
                    dataGridView1.Rows[dataGridView1.Rows.Count-1].Cells[1].Value =
                            (selectedRow.Cells[1] as DataGridViewComboBoxCell).Value;
                }
            }
 
        }
        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DataGridView gv = (sender as DataGridView);
            if (gv.IsCurrentCellDirty)
            {
                gv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            SetDefaultValuesForNewRow(dataGridView1.Rows[e.RowIndex]);
        }

        private void TemplateViewerControl_Load(object sender, EventArgs e)
        {
            if (ConfigurationManager.ConnectionStrings["db"] != null)
            {
                connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
                command = new SqlCeCommand();
                command.Connection = connection;
                FillCategoryList();
                try
                {
                    DataGridViewComboBoxColumn col1 = dataGridView1.Columns[0] as DataGridViewComboBoxColumn;
                    col1.ValueMember = "ID";
                    col1.DisplayMember = "Name";
                    col1.DataSource = ExersizeCategoryTable.Tables[0];


                    DataGridViewComboBoxColumn col2 = dataGridView1.Columns[1] as DataGridViewComboBoxColumn;
                    col2.ValueMember = "ExersizeID";
                    col2.DisplayMember = "ShortName";
                    col2.Width = 290;

                    dataGridView1.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView1.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView1.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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
                object id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Tag);
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                //this.RemoveTrainingTemplateById(id);
            }
        }
        //private void RemoveTrainingTemplateById(int id)
        //{
        //    try
        //    {
        //        connection.Open();
        //        using (SqlCeCommand cmd = connection.CreateCommand())
        //        {
        //            cmd.CommandText = string.Format("delete from TrainingTemplate where ID={0}", id);
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //    connection.Close();
        //}
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
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

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Tab)
            {
                 
            }
        }



    }
}
