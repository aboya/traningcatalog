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

namespace TrainingCatalog
{
    public partial class Training : BaseForm
    {
        SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
        SqlCeDataAdapter table = new SqlCeDataAdapter();
        DataSet Exersizes = new DataSet();
        DataSet ExersizeCategoryTable = new DataSet();
        DateTime lastPressKeyTime;

        public Training()
        {
            lastPressKeyTime = DateTime.MinValue;
            InitializeComponent();
            this.MinimumSize = new Size(588, 382);
        }

        private void AddExersize_Click(object sender, EventArgs e)
        {
            uint weight = 0, count = 0;
            int TrainingId = 0, ExersizeId = 0;
            try
            {
                connection.Open();
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    weight = Convert.ToUInt32(txtWeight.Text);
                    count = Convert.ToUInt32(txtCount.Text);

                    TrainingId = TrainingBusiness.GetTrainingDayId(dateTime.Value, cmd);
                    
                    ExersizeId = (int)Exersizes.Tables[0].Rows[TrainingList.SelectedIndex]["ExersizeID"];
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
            // порядок вызова этих функций важен
            CategoryFilterLoad();
            GridBind();
        }
        protected void CategoryFilterLoad()
        {

            try
            {
                connection.Open();
                cbTraningCategory.Items.Add("Все");

                using (SqlCeCommand cmd = new SqlCeCommand())
                {
                    cmd.Connection = connection;
                    cmd.Parameters.Clear();
                    cmd.CommandText = "select * from ExersizeCategory order by Name";
                    table.SelectCommand = cmd;
                    table.Fill(ExersizeCategoryTable);
                    foreach (DataRow row in ExersizeCategoryTable.Tables[0].Rows)
                    {
                        cbTraningCategory.Items.Add(row["Name"]);
                    }
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
            cbTraningCategory.SelectedIndex = 0;
        }
        private void ExersizeLoad()
        {

            // это надо что бы рекурсии небыло

            try
            {
                connection.Open();
                using (SqlCeCommand cmd = new SqlCeCommand())
                {
                    cmd.Connection = connection;
                    // теперь загружаем список учитывая наш фильтр ExersizeCategoryTable


                    // если в фильтре указали что бы показывать все упражнения
                    if (cbTraningCategory.SelectedIndex == 0)
                    {
                        cmd.CommandText = "select Id as ExersizeId, ShortName from Exersize order by ShortName";
                    }
                    else
                    {
                        int exersizeCategoryId = (int)ExersizeCategoryTable.Tables[0].Rows[cbTraningCategory.SelectedIndex - 1]["ID"];
                        cmd.CommandText = @"select Exersize.ID as ExersizeID, Exersize.ShortName from Exersize 
                                            inner join ExersizeCategoryLink on
                                            ExersizeCategoryLink.ExersizeID = Exersize.ID
                                            where  ExersizeCategoryLink.ExersizeCategoryID = @exersizeCategoryId   
                                            order by ShortName";
                        cmd.Parameters.Add("@exersizeCategoryId", SqlDbType.Int).Value = exersizeCategoryId;
                    }

                    table.SelectCommand = cmd;
                    Exersizes.Clear();
                    TrainingList.Items.Clear();
                    table.Fill(Exersizes);
                    for (int i = 0; i < Exersizes.Tables[0].Rows.Count; i++)
                    {
                        TrainingList.Items.Add(Exersizes.Tables[0].Rows[i]["ShortName"]);
                    }

                    TrainingList.SelectedIndex = 0;
                    TrainingList.DropDownStyle = ComboBoxStyle.DropDownList;
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
                cmd.CommandText = @"select BodyWeight from Training 
                                    where Day = @Day";
                cmd.Parameters.Add("@Day", SqlDbType.DateTime).Value = date;
                object bodyWeight = (object)cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                if (bodyWeight == null)
                {
                    txtBodyWeigh.Text = "0";
                }
                else
                {
                    txtBodyWeigh.Text = Convert.ToString(bodyWeight);
                }
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

        private void Training_Resize(object sender, EventArgs e)
        {

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
                int LinkId = (int)dataGridView1.Rows[e.RowIndex].Tag;
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandText = String.Format("delete from Link where Link.ID = {0}", LinkId);
                cmd.ExecuteNonQuery();
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

        private void TrainingList_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TrainingList_KeyPress(object sender, KeyPressEventArgs e)
        {
           // int b;
        }

        private void cbTraningCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // внутырь функции ExersizeLoad не пихать эти две строчки, поотому что там идут реукрсивные вызовы
            // когда вызывается .selectedIndex = 0
            ExersizeLoad();
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
                double bodyWeight = Convert.ToDouble(txtBodyWeigh.Text);
                cmd.CommandText = "UPDATE Training set BodyWeight = @bodyWeight where Day = @day";
                cmd.Parameters.Add("@day", SqlDbType.DateTime).Value = dateTime.Value.Date;
                cmd.Parameters.Add("@bodyWeight", SqlDbType.Float).Value = bodyWeight;
                int affectedRows = cmd.ExecuteNonQuery();
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
            DisableIncorectKeys(e);
        }
        private void txtCount_KeyDown(object sender, KeyEventArgs e)
        {
            DisableIncorectKeys(e);
        }
        private void DisableIncorectKeys(KeyEventArgs e)
        {
            //8-backspace
            // 46 - delete
            // 37 - left arrow
            // 39 - right arrow
            if (e.KeyValue != 8 && e.KeyValue != 46 && e.KeyValue != 37 && e.KeyValue != 39)
            {
                if(e.KeyValue < '0' || e.KeyValue > '9') e.SuppressKeyPress = true;
                if (e.KeyValue >= 96 && e.KeyValue <= 105) e.SuppressKeyPress = false;
            }
        }

        private void Training_ResizeBegin(object sender, EventArgs e)
        {

        }

        private void Training_ResizeEnd(object sender, EventArgs e)
        {
        }

        private void btnAddFromTemplate_Click(object sender, EventArgs e)
        {
            new TemplateAdd(dateTime.Value).ShowDialog(this);
            GridBind();
        }
    }
}
