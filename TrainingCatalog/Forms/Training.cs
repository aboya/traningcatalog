using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;
using System.Configuration;

namespace TrainingCatalog
{
    public partial class Training : Form
    {
        OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
        OleDbDataAdapter table = new OleDbDataAdapter();
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
            int lastId, lastLinkId;
            Object o;
            string date;
            date = dateTime.Value.ToString("dd/MM/yyyy");
            OleDbCommand cmd = new OleDbCommand();

            try
            {
                connection.Open();
                weight = Convert.ToUInt32(txtWeight.Text);
                count = Convert.ToUInt32(txtCount.Text);
                cmd.Connection = connection;
                cmd.CommandText = "select max(ID) from Training";
                lastId = (int)cmd.ExecuteScalar();
                cmd.CommandText = String.Format("select ID from Training where Day = DateValue(\"{0}\")", date);
                o = cmd.ExecuteScalar();
                if (o == null || o is DBNull)
                {
                    // создаем новый тренировочный день
                    cmd.CommandText = String.Format("insert into Training  values({0},DateValue(\"{1}\"), \'\',{2})", lastId + 1, date, 0);
                    cmd.ExecuteNonQuery();
                    TrainingId = lastId + 1;
                }
                else
                {
                    // используем уже созданный день
                    TrainingId = (int)o;

                }
                cmd.CommandText = "select max(ID) from Link";
                lastLinkId = (int)cmd.ExecuteScalar();

                ExersizeId = (int)Exersizes.Tables[0].Rows[TrainingList.SelectedIndex]["ExersizeID"];
                cmd.CommandText = String.Format("insert into Link values({0},{1},{2},{3},{4})", lastLinkId + 1, TrainingId, ExersizeId, weight, count);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                connection.Close();
                cmd.Dispose();
            }
            cmd.Dispose();
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

                using (OleDbCommand cmd = new OleDbCommand())
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
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = connection;
                    // теперь загружаем список учитывая наш фильтр ExersizeCategoryTable


                    // если в фильтре указали что бы показывать все упражнения
                    if (cbTraningCategory.SelectedIndex == 0)
                    {
                        cmd.CommandText = "select * from Exersize order by ShortName";
                    }
                    else
                    {
                        int exersizeCategoryId = (int)ExersizeCategoryTable.Tables[0].Rows[cbTraningCategory.SelectedIndex - 1]["ID"];
                        cmd.CommandText = @"select Exersize.ExersizeID, Exersize.ShortName from Exersize 
                                        inner join ExersizeCategoryLink on
                                        ExersizeCategoryLink.ExersizeID = Exersize.ExersizeID
                                        where  ExersizeCategoryLink.ExersizeCategoryID = @exersizeCategoryId   
                                        order by ShortName";
                        cmd.Parameters.Add("@exersizeCategoryId", OleDbType.Integer).Value = exersizeCategoryId;
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
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                dataGridView1.Columns.Clear();
                string date = dateTime.Value.ToString("dd/MM/yyyy");
                connection.Open();
                cmd.Connection = connection;
                cmd.CommandText = String.Format("select ShortName,Weight, Count from( ( Link inner join Training on Training.ID = Link.TrainingID ) inner  join Exersize on Exersize.ExersizeID = Link.ExersizeID) where Day = DateValue(\"{0}\") order by Link.ID", date);
                DataSet dataSet = new DataSet();
                OleDbDataAdapter tableAdapter = new OleDbDataAdapter();
                tableAdapter.SelectCommand = cmd;
                tableAdapter.Fill(dataSet);

                DataSet TrainingIds = new DataSet();
                tableAdapter.SelectCommand.CommandText = String.Format("select Link.ID from( ( Link inner join Training on Training.ID = Link.TrainingID ) inner  join Exersize on Exersize.ExersizeID = Link.ExersizeID) where Day = DateValue(\"{0}\") order by Link.ID", date);
                tableAdapter.Fill(TrainingIds);

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
                cmd.CommandText = string.Format("select BodyWeight from Training where Day = DateValue(\"{0}\")", date);
                object bodyWeight = (object)cmd.ExecuteScalar();
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
            OleDbCommand cmd = new OleDbCommand();
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
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;
            // обновляем вес тела
            try
            {
                cmd.Connection.Open();
                double bodyWeight = Convert.ToDouble(txtBodyWeigh.Text);
                cmd.CommandText = string.Format("UPDATE Training set BodyWeight = {0} where Day = DateValue(\"{1}\")", bodyWeight.ToString("F1", CultureInfo.InvariantCulture), date);
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
