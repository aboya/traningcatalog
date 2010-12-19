using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.Data.OleDb;
using System.Configuration;
using TrainingCatalog.BusinessLogic.Types;
namespace TrainingCatalog
{
    public partial class Perfomance : Form
    {
        OleDbConnection connection;
        OleDbDataAdapter table = new OleDbDataAdapter();
        DataSet Exersizes = new DataSet();
        protected DateTime MinDateTime;
        protected DateTime MaxDateTime;
        public Perfomance()
        {
            InitializeComponent();
        }

        private void Perfomance_Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            this.MinimumSize = new Size(475, 319);
 
            ExersizeLoad();
            CreateGraph(zedGraphControl1);

        }
        private void SetSize()
        {
            zedGraphControl1.Location = new Point(10, 36);
            // Leave a small margin around the outside of the control

            zedGraphControl1.Size = new Size(ClientRectangle.Width - 20,
                                    ClientRectangle.Height - 65);
            
        }
        private void CreateGraph(ZedGraphControl zgc)
        {
            // get a reference to the GraphPane

            try
            {
                zedGraphControl1.IsShowPointValues = true;
                GraphPane myPane = zgc.GraphPane;
                myPane.XAxis.Type = AxisType.Date;
                // Set the Titles

                myPane.Title.Text = "Perfomance";
                myPane.XAxis.Title.Text = "Date";
                myPane.YAxis.Title.Text = "Weight";

                // Make up some data arrays based on the Sine function

                //double x, y1, y2;
                PointPairList pointWeightCount = new PointPairList();
                PointPairList pointBodyWeight = new PointPairList();
                PointPairList pointWeight = new PointPairList();
                List<PerfomanceDataType> items = GetPerfomance();
                items = ApplyFilters(items);
                int lastTrainingId = -1;
                foreach (PerfomanceDataType p in items)
                {

                    if (chkWeighCount.Checked)
                    {
                        pointWeightCount.Add(p.Day.ToOADate(), p.Weight * p.Count,
                            string.Format("Дата:{0} {1}x{2}={3}", p.Day.ToString("dd.MM.yyyy"), p.Weight, p.Count, p.Weight * p.Count));
                    }
                    if (chkBodyWeight.Checked)
                    {
                        if (p.BodyWeight > 0)
                            pointBodyWeight.Add(p.Day.ToOADate(), p.BodyWeight);
                    }
                    if (chkWeight.Checked && lastTrainingId != p.TrainingID) // exculde dublicates
                    {
                        pointWeight.Add(p.Day.ToOADate(), p.Weight);
                    }
                }

                 
                // Generate a red curve with diamond

                // symbols, and "Porsche" in the legend
                myPane.CurveList.Clear();
                LineItem myCurve = myPane.AddCurve("Weight * Count",
                      pointWeightCount, Color.Red, SymbolType.Circle);


                // Generate a blue curve with circle

                // symbols, and "Piper" in the legend

                LineItem myCurve2 = myPane.AddCurve("BodyWeight",
                     pointBodyWeight, Color.Blue, SymbolType.Circle);


                myPane.AddCurve("Weight", pointWeight, Color.Brown, SymbolType.Circle);
                // Tell ZedGraph to refigure the

                // axes since the data have changed


                zgc.AxisChange();
                zgc.Refresh();


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        private List<PerfomanceDataType> ApplyFilters(List<PerfomanceDataType> items)
        {
            if (rbNone.Checked) return items;
            List<PerfomanceDataType> res = new List<PerfomanceDataType>();
            Dictionary<int, int> maxes = new Dictionary<int, int>();
            Dictionary<int, int> indexes = new Dictionary<int,int>();
            int index = 0;
            if (rbWork.Checked)
            {
                foreach (PerfomanceDataType p in items)
                {
                    int m;
                    if (maxes.TryGetValue(p.TrainingID, out m))
                    {
                        if (m < p.Weight * p.Count)
                        {
                            maxes[p.TrainingID] = p.Weight * p.Count;
                            indexes[p.TrainingID] = index;
                        }
                    }
                    else
                    {
                        maxes[p.TrainingID] = p.Weight * p.Count;
                        indexes[p.TrainingID] = index;
                    }
                    index++;

                }

            }
            if (rbMaxWeight.Checked)
            {
                foreach (PerfomanceDataType p in items)
                {
                    int m;
                    if (maxes.TryGetValue(p.TrainingID, out m))
                    {
                        if (m < p.Weight * p.Count)
                        {
                            maxes[p.TrainingID] = p.Weight ;
                            indexes[p.TrainingID] = index;
                        }
                    }
                    else
                    {
                        maxes[p.TrainingID] = p.Weight ;
                        indexes[p.TrainingID] = index;
                    }
                    index++;

                }
            }
            foreach (int i in indexes.Values)
            {
                res.Add(items[i]);
            }
            return res;
        }

        private List<PerfomanceDataType> GetPerfomance()
        {
            List<PerfomanceDataType> res = new List<PerfomanceDataType>();
            try
            {
                int ExersizeId = (int)Exersizes.Tables[0].Rows[TrainingList.SelectedIndex]["ExersizeID"];
                connection.Open();
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText =
                        String.Format("select Day,Weight,Count,BodyWeight,Training.ID as TrainingID from Link " +
                                      "inner join Training on Training.ID = Link.TrainingID " +
                                      "where ExersizeID = {0} " +
                                      "and Day between DateValue(\"{1}\") and  DateValue(\"{2}\") " +
                                      "order by Day, Weight", ExersizeId, dtpFrom.Value.ToString("dd/MM/yyyy"),
                                                                    dtpTo.Value.ToString("dd/MM/yyyy"));
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            PerfomanceDataType dt = new PerfomanceDataType();
                            dt.Weight = (int)reader["Weight"];
                            dt.Count = (int)reader["Count"];
                            dt.Day = (DateTime)reader["Day"];
                            if (reader["BodyWeight"] is DBNull) dt.BodyWeight = 0;
                            else dt.BodyWeight = Convert.ToDouble(reader["BodyWeight"]);
                            dt.TrainingID = (int) reader["TrainingID"];
                            res.Add(dt);
                        }
                    }

                }

                //zgc.Refresh();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                connection.Close();
            }
            return res;
        }
        private void Perfomance_Resize(object sender, EventArgs e)
        {
            //SetSize();
            //TrainingList.Top = this.Height - 65;
        }
        public void ExersizeLoad()
        {
            try
            {
                connection.Open();
                using (OleDbCommand cmd = new OleDbCommand("select * from Exersize order by ShortName", connection))
                {
                    // fill exersizes
                    cmd.Connection = connection;
                    table.SelectCommand = cmd;

                    table.Fill(Exersizes);
                    for (int i = 0; i < Exersizes.Tables[0].Rows.Count; i++)
                    {
                        TrainingList.Items.Add(Exersizes.Tables[0].Rows[i]["ShortName"]);
                    }


                    TrainingList.DropDownStyle = ComboBoxStyle.DropDownList;

                    // get min and max datevalue for datetime 
                    cmd.CommandText = "select max(Day) from Training";
                    MaxDateTime = Convert.ToDateTime(cmd.ExecuteScalar());
                    cmd.CommandText = "select min(Day) from Training";
                    MinDateTime = Convert.ToDateTime(cmd.ExecuteScalar());
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
            TrainingList.SelectedIndex = 0;
            dtpFrom.Value = MinDateTime;
            dtpTo.Value = MaxDateTime;
        }

        private void TrainingList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateGraph(zedGraphControl1);
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value < MinDateTime) dtpFrom.Value = MinDateTime;
            CreateGraph(zedGraphControl1);

        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTo.Value > MaxDateTime) dtpTo.Value = MaxDateTime;
            CreateGraph(zedGraphControl1);
        }

        private void bntClear_Click(object sender, EventArgs e)
        {
            dtpTo.Value = MaxDateTime;
            dtpFrom.Value = MinDateTime;
        }

        private void chkBodyWeight_CheckedChanged(object sender, EventArgs e)
        {
            CreateGraph(zedGraphControl1);
        }

        private void chkWeighCount_CheckedChanged(object sender, EventArgs e)
        {
            CreateGraph(zedGraphControl1);
        }

        private void chkWeight_CheckedChanged(object sender, EventArgs e)
        {
            CreateGraph(zedGraphControl1);
        }

        private void rbWork_CheckedChanged(object sender, EventArgs e)
        {
            CreateGraph(zedGraphControl1);
        }

        private void rbNone_CheckedChanged(object sender, EventArgs e)
        {
            CreateGraph(zedGraphControl1);
        }
 

    }
}
