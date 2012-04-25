using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Globalization;
using System.Configuration;
using TrainingCatalog.BusinessLogic;
using TrainingCatalog.Forms;
using TrainingCatalog.BusinessLogic.Types;

namespace TrainingCatalog
{
    public partial class Training : BaseForm
    {
        public DateTime TrainingDate = DateTime.Now;
        public Training()
        {
            InitializeComponent();
            AddExersize.Image = TrainingCatalog.AppResources.AppResources.Plus_green_32x32;          

        }

        private void AddExersize_Click(object sender, EventArgs e)
        {
            uint weight = 0, count = 0;
            int TrainingId = 0, ExersizeId = 0;
            if (TrainingList.Items.Count == 0)
            {
                MessageBox.Show("Добавтье хотя бы одно упражнение");
                return;
            }
            if (!uint.TryParse(txtWeight.Text, out weight))
            {
                MessageBox.Show("Не задан вес");
                return;
            }
            if (!uint.TryParse(txtCount.Text, out count))
            {
                MessageBox.Show("Не заданны повторения");
                return;
            }
            try
            {
                connection.Open();
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    TrainingId = TrainingBusiness.GetTrainingDayId(cmd, dateTime.Value);
                    ExersizeId = Convert.ToInt32(TrainingList.SelectedValue);
                    TrainingBusiness.AddExersize(cmd, TrainingId, ExersizeId, (int)weight, (int)count);
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                connection.Close();
            }
            GridBind();
        }

        private void Training_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(588, 382);
            
            try
            {
                connection.Open();
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    dateTime.MinDate = TrainingBusiness.GetStartTrainingDay(cmd);
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                connection.Close();
            }
            dateTime.Value = TrainingDate;
            // порядок вызова этих функций важен
            TrainingList.ValueMember = "ExersizeID";
            TrainingList.DisplayMember = "ShortName";
            cbTraningCategory.ValueMember = "Id";
            cbTraningCategory.DisplayMember = "Name";
            
            CategoryFilterLoad();
            ExersizeLoad();
            GridBind();

        }
        protected void CategoryFilterLoad()
        {
            List<CategoryType> categories = new List<CategoryType>();
            categories.Add(new CategoryType()
            {
                Id = -1,
                Name = "Все"
            });
            try
            {
                connection.Open();
                using (cmd = connection.CreateCommand())
                {
                    cmd.Parameters.Clear();
                    categories.AddRange(TrainingBusiness.GetCategories(cmd));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            // этой строчкой мы фактически вызываем ExersizeLoad()
            cbTraningCategory.DataSource = categories;
            // и этой строчкой тоже)
            cbTraningCategory.SelectedIndex = 0;

         
        }
        private void ExersizeLoad()
        {
            List<ExersizeSource> exersizes = new List<ExersizeSource>();
            try
            {
                connection.Open();
                using (cmd = connection.CreateCommand())
                {
                    int exersizeCategoryId = Convert.ToInt32(cbTraningCategory.SelectedValue);
                    exersizes = TrainingBusiness.GetExersizes(cmd, exersizeCategoryId);

                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                connection.Close();
                
            }
            
            TrainingList.DataSource = exersizes;
            if (exersizes.Count > 0)
                TrainingList.SelectedIndex = 0;
        }
        private void GridBind()
        {
            SqlCeCommand cmd = new SqlCeCommand();
            try
            {
                dataGridView1.Columns.Clear();
                //string date = dateTime.Value.ToString("dd/MM/yyyy");
                DateTime date = dateTime.Value.Date;
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandText = @"select ShortName,Weight, Count from  Link 
                                    inner join Training on Training.ID = Link.TrainingID  
                                    inner  join Exersize on Exersize.ID = Link.ExersizeID
                                    where Day = @day order by Link.ID";
                cmd.Parameters.Add("@Day", SqlDbType.DateTime).Value = date;
                DataSet dataSet = new DataSet();
                SqlCeDataAdapter tableAdapter = new SqlCeDataAdapter();
                tableAdapter.SelectCommand = cmd;
                tableAdapter.Fill(dataSet);
                cmd.Parameters.Clear();

                DataSet TrainingIds = new DataSet();
                tableAdapter.SelectCommand.CommandText = @"select Link.ID from Link 
                                                           inner join Training on Training.ID = Link.TrainingID 
                                                           inner join Exersize on Exersize.ID = Link.ExersizeID
                                                           where Day = @Day order by Link.ID";
                cmd.Parameters.Add("@Day", SqlDbType.DateTime).Value = date;
                tableAdapter.Fill(TrainingIds);
                cmd.Parameters.Clear();

                dataGridView1.Columns.Add("Exersize", "Exersize");
                dataGridView1.Columns.Add("Weight", "Weight");
                dataGridView1.Columns.Add("Count", "Count");
                DataGridViewColumn col = new System.Windows.Forms.DataGridViewButtonColumn();
                col.HeaderText = "-";

                dataGridView1.Columns.Add(col);
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {

                    dataGridView1.Rows.Add(
                        dataSet.Tables[0].Rows[i].ItemArray
                    );
                    dataGridView1.Rows[i].Cells[3].Value = "Remove";
                    dataGridView1.Rows[i].Tag = TrainingIds.Tables[0].Rows[i][0];

                }
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.BorderStyle = BorderStyle.Fixed3D;

                // Put the cells in edit mode when user enters them.
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // get body weight
                txtBodyWeight.Text = TrainingBusiness.GetBodyWeight(cmd, date).ToString();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
        }


        private void dateTime_ValueChanged(object sender, EventArgs e)
        {
            this.GridBind();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 3) return;
            if (e.RowIndex >= dataGridView1.Rows.Count) return;
            SqlCeCommand cmd = new SqlCeCommand();
            try
            {
                object o = dataGridView1.Rows[e.RowIndex].Tag;
                if (o != null)
                {
                    int LinkId = Convert.ToInt32(o);
                    connection.Open();
                    cmd.Connection = connection;
                    cmd.CommandText = String.Format("delete from Link where Link.ID = {0}", LinkId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                connection.Close();
            }
            this.GridBind();
        }


        private void cbTraningCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

 

        private void btnSaveWeight_Click(object sender, EventArgs e)
        {
            string date = dateTime.Value.ToString("dd/MM/yyyy");
            SqlCeCommand cmd = new SqlCeCommand();
            cmd.Connection = connection;
            // обновляем вес тела
            try
            {
                cmd.Connection.Open();
                float bodyWeight = Convert.ToSingle(txtBodyWeight.Text);
                int affectedRows = TrainingBusiness.SaveBodyWeight(cmd, dateTime.Value.Date, (float)bodyWeight);
                if (affectedRows == 0)
                {
                    MessageBox.Show("Необходимо добавить хотя бы 1 упражнение");
                }
                if (affectedRows > 1)
                {
                    MessageBox.Show("Вес записался в другие тренировочные дни!!");
                }
                
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Dispose();
            }

        }
        private void txtWeight_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnSaveWeight_Click(null, null);
            }
            else
            {
                DisableIncorectKeys(e);
            }
        }
        private void txtCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                AddExersize_Click(null, null);
            }
            else
            {
                DisableIncorectKeys(e);
            }
        }
        private void DisableIncorectKeys(KeyEventArgs e)
        {
            //8-backspace
            // 46 - delete
            // 37 - left arrow
            // 39 - right arrow
            // 13 - enter

      
                if (e.KeyValue != 8 && e.KeyValue != 46 && e.KeyValue != 37 && e.KeyValue != 39)
                {
                    if (e.KeyValue < '0' || e.KeyValue > '9') e.SuppressKeyPress = true;
                    if (e.KeyValue >= 96 && e.KeyValue <= 105) e.SuppressKeyPress = false;
                }
          
        }

        private void btnAddFromTemplate_Click(object sender, EventArgs e)
        {
            new TemplateAdd(dateTime.Value).ShowDialog(this);
            GridBind();
        }

        private void btnOtherDay_Click(object sender, EventArgs e)
        {
            using (AddFromOtherDay od = new AddFromOtherDay(dateTime.Value.Date))
            {
                od.ShowDialog(this);
                GridBind();
            }
        }

        private void cbTraningCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ExersizeLoad();
        }

    }
}
