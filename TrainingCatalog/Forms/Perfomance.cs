using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.Data.SqlServerCe;
using System.Configuration;
using TrainingCatalog.BusinessLogic.Types;
using TrainingCatalog.Forms;
namespace TrainingCatalog
{
    public partial class Perfomance : BaseForm
    {
        SqlCeConnection connection;
        SqlCeDataAdapter table = new SqlCeDataAdapter();
        DataSet Exersizes = new DataSet();
        protected DateTime MinDateTime;
        protected DateTime MaxDateTime;
        private bool IsShown = false;
        public Perfomance()
        {
            InitializeComponent();
        }
        private List<PerfomanceDataType> _bodyWeight;
        private List<PerfomanceDataType> BodyWeight
        {
            get
            {
                if (_bodyWeight == null)
                {
                    _bodyWeight = GetBodyWeight();
                }
                return _bodyWeight;
            }
    
        }

        private void Perfomance_Load(object sender, EventArgs e)
        {
            connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            this.MinimumSize = new Size(475, 319);
 
            ExersizeLoad();
            CreateGraph(mainGraphControl);
            Form mainForm = Application.OpenForms["mainForm"];
            this.Location = mainForm.Location;

            //if (chkBodyWeight.Checked)
            //{
            //    chkApprox.Enabled = true;
            //}
            //else
            //{
            //    chkApprox.Enabled = false;
            //    chkApprox.Checked = false;
            //}
    
        }
        private void SetSize()
        {
            mainGraphControl.Location = new Point(10, 36);
            // Leave a small margin around the outside of the control

            mainGraphControl.Size = new Size(ClientRectangle.Width - 20,
                                    ClientRectangle.Height - 65);
            
        }
        private void CreateGraph(ZedGraphControl zgc)
        {
            // get a reference to the GraphPane
            if (IsShown == false) return;
            try
            {
                mainGraphControl.IsShowPointValues = true;
                GraphPane myPane = zgc.GraphPane;
                myPane.CurveList.Clear();
                myPane.XAxis.Type = AxisType.Date;
                // Set the Titles

                myPane.Title.Text = "Perfomance";
                myPane.Title.IsVisible = false;
                myPane.XAxis.Title.Text = "Date";
                myPane.YAxis.Title.Text = "Weight";

                // Make up some data arrays based on the Sine function

                //double x, y1, y2;
                PointPairList pointWeightCount = new PointPairList();
                PointPairList pointBodyWeight = new PointPairList();
                PointPairList pointWeight = new PointPairList();
                List<PerfomanceDataType> items = GetPerfomance();
                myPane.CurveList.Clear();
                if (chkTotalWork.Checked)
                {
                    PointPairList totalWork = TotalWorkCreate(items);
                    myPane.AddCurve("TotalWork", totalWork, Color.Black, SymbolType.Circle);
                }
                items = ApplyFilters(items);
                int lastTrainingId = -1;
                PerfomanceDataType previous = null;
                foreach (PerfomanceDataType p in items)
                {
                    string tag = string.Format("Дата:{0} {1}x{2}={3}", p.Day.ToString("dd.MM.yyyy"), p.Weight, p.Count, p.Weight * p.Count);
                    if (previous != null)
                    {
                        double A,W;
                        A = 100 * (double)(p.Weight * p.Count - previous.Weight * previous.Count) / (previous.Weight * previous.Count);
                        W = 100 * (double)(p.Weight - previous.Weight) / (previous.Weight);
                        tag += string.Format("\t\n A:{0:0.##}% W:{1:0.##}%", A, W);
                    }
                    if (chkWeighCount.Checked)
                    {
                        pointWeightCount.Add(p.Day.ToOADate(), p.Weight * p.Count, tag);
                    }
                    if (chkWeight.Checked) 
                    {
                        if (previous == null || lastTrainingId != p.TrainingID || previous.Weight != p.Weight)// exculde dublicates
                             pointWeight.Add(p.Day.ToOADate(), p.Weight, tag);
                    }
                    previous = p;
                    lastTrainingId = p.TrainingID;
                }
                
                
                if (chkBodyWeight.Checked)
                {
     
                    PerfomanceDataType lastBodyWeight = null;
                    string tag = string.Empty;
                    foreach (PerfomanceDataType p in BodyWeight)
                    {
                        if (p.BodyWeight > 0)
                        {
                            tag = string.Format("Вес:{0:0.##} | {1} ({2}) \t\n", p.BodyWeight,p.Day.ToString("dd.MM.yy"), p.Day.DayOfWeek.ToString());
                            if (lastBodyWeight != null)
                            {
                                tag += string.Format("({0:0.##}кг|{1:0.##}%)",(p.BodyWeight - lastBodyWeight.BodyWeight), 
                                    100 * (double)(p.BodyWeight - lastBodyWeight.BodyWeight) / lastBodyWeight.BodyWeight);
                            }
                            pointBodyWeight.Add(p.Day.ToOADate(), p.BodyWeight, tag);
                        }
                        lastBodyWeight = p;
                    }
                    LineItem myCurve2 = myPane.AddCurve("Вес Тела", pointBodyWeight, Color.Blue, SymbolType.Circle);

                }

                if (chkApprox.Checked)
                {
                    LineItem myCurve3 = myPane.AddCurve("ApproxWeight", this.GetApproxWeight(BodyWeight), Color.Teal, SymbolType.Triangle);
                    myCurve3.Line.IsSmooth = true;
                    myCurve3.Line.IsAntiAlias = true;
                    myCurve3.Line.SmoothTension = 0.6f;
                }
                // Generate a red curve with diamond

                // symbols, and "Porsche" in the legend
                if (chkWeighCount.Checked)
                {
                    LineItem myCurve = myPane.AddCurve("Вес * Повторения",
                          pointWeightCount, Color.Red, SymbolType.Circle);
                }


                // Generate a blue curve with circle

                // symbols, and "Piper" in the legend


                //myPane.YAxis.MajorGrid.IsVisible = true;
                //myPane.YAxis.MinorGrid.IsVisible = true;
                if (chkWeight.Checked)
                {
                    myPane.AddCurve("Weight", pointWeight, Color.Brown, SymbolType.Circle);
                }
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
        private PointPairList GetApproxWeight(List<PerfomanceDataType> weights)
        {
            PointPairList res = new PointPairList();
            if (weights.Count > 2)
            {
                double y;
                double dt = weights[0].Day.ToOADate();
                y = weights[0].BodyWeight;
                res.Add(weights[0].Day.ToOADate(), weights[0].BodyWeight);
                for(int i = 1; i < weights.Count; i++)
                {
                    res.Add((dt + weights[i].Day.ToOADate()) / 2, (weights[i].BodyWeight + y) / 2);
                    y = (y + weights[i].BodyWeight) / 2;
                    dt = weights[i].Day.ToOADate();
                }

            }
            
            return res;
        }
        private List<PerfomanceDataType> GetBodyWeight()
        {
            List<PerfomanceDataType> res = new List<PerfomanceDataType>();
            try
            {
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = "select BodyWeight,Day from Training where Day between @start and @end and BodyWeight is not null and BodyWeight > 0";
                    cmd.Parameters.Add("@start", SqlDbType.DateTime).Value = dtpFrom.Value.Date;
                    cmd.Parameters.Add("@end", SqlDbType.DateTime).Value = dtpTo.Value.Date;
                    using (SqlCeDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!(reader[0] is DBNull)) res.Add(new PerfomanceDataType()
                            {
                                BodyWeight = (double)reader["BodyWeight"],
                                Day = Convert.ToDateTime(reader["Day"])
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
            return res;
        }
        private PointPairList TotalWorkCreate(List<PerfomanceDataType> items)
        {
            Dictionary<int, List<PerfomanceDataType> > dic = new Dictionary<int, List<PerfomanceDataType> >();
            foreach (PerfomanceDataType i in items)
            {
                List<PerfomanceDataType> t;
                if (dic.TryGetValue(i.TrainingID, out t))
                {
                    t.Add(i);
                }
                else
                {
                    t = new List<PerfomanceDataType>();
                    t.Add(i);
                    dic[i.TrainingID] = t;
                }
            }
            PointPairList res = new PointPairList();
            foreach (int trainingId in dic.Keys)
            {
                string tag = string.Empty;
                int val = 0;
                DateTime dt = DateTime.MinValue;
                foreach(PerfomanceDataType i in dic[trainingId])
                {
                    if (tag.Length == 0) {
                        tag = string.Format("Дата:{0}\t\n", i.Day.ToString("dd.MM.yyyy"));
                        dt = i.Day;
                    }

                    val += i.Weight * i.Count;
                    tag += string.Format("{0}x({1})x", i.Weight, i.Count);
                }
                if (tag[tag.Length - 1] == 'x') tag = tag.Substring(0, tag.Length - 1);
                tag += string.Format("={0}\t\n",val);
                res.Add(dt.ToOADate(), val, tag);
            }


            return res;
 
        }
        private List<PerfomanceDataType> ApplyFilters(List<PerfomanceDataType> items)
        {
            if (rbNone.Checked) return items;
            List<PerfomanceDataType> res = new List<PerfomanceDataType>();
            Dictionary<int, int> maxes = new Dictionary<int, int>();
            Dictionary<int, int> maxes2 = new Dictionary<int, int>();
            Dictionary<int, int> indexes = new Dictionary<int,int>();
            int index = 0;
            if (rbWork.Checked)
            {
                foreach (PerfomanceDataType p in items)
                {
                    int m,m2;
                    if (maxes.TryGetValue(p.TrainingID, out m))
                    {
                        m2 = maxes2[p.TrainingID];
                        if (m < p.Weight * p.Count || m == p.Weight * p.Count && m2 < p.Weight )
                        {
                            maxes[p.TrainingID] = p.Weight * p.Count;
                            maxes2[p.TrainingID] = p.Weight;
                            indexes[p.TrainingID] = index;
                        }
                    }
                    else
                    {
                        maxes[p.TrainingID] = p.Weight * p.Count;
                        maxes2[p.TrainingID] = p.Weight;
                        indexes[p.TrainingID] = index;
                    }
                    index++;

                }

            }
            else if (rbMaxWeight.Checked)
            {
                foreach (PerfomanceDataType p in items)
                {
                    int m,m2;
                    if (maxes.TryGetValue(p.TrainingID, out m))
                    {
                        m2 = maxes2[p.TrainingID];
                        if (m < p.Weight || m == p.Weight && m2 < p.Weight * p.Count)
                        {
                            maxes[p.TrainingID] = p.Weight ;
                            maxes2[p.TrainingID] = p.Weight * p.Count;
                            indexes[p.TrainingID] = index;
                        }
                    }
                    else
                    {
                        maxes[p.TrainingID] = p.Weight ;
                        maxes2[p.TrainingID] = p.Weight * p.Count;
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
                using (SqlCeCommand cmd = new SqlCeCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText =
                        String.Format("select Day,Weight,Count,BodyWeight,Training.ID as TrainingID from Link " +
                                      "inner join Training on Training.ID = Link.TrainingID " +
                                      "where ExersizeID = @exersizeId " +
                                      "and Day between @start and  @end " +
                                      "order by Day, Weight");
                    cmd.Parameters.Add("@start", SqlDbType.DateTime).Value = dtpFrom.Value.Date;
                    cmd.Parameters.Add("@end", SqlDbType.DateTime).Value = dtpTo.Value.Date;
                    cmd.Parameters.Add("@exersizeId", SqlDbType.Int).Value = ExersizeId;
                    using (SqlCeDataReader reader = cmd.ExecuteReader())
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
                using (SqlCeCommand cmd = new SqlCeCommand("select Id as ExersizeId, ShortName from Exersize order by ShortName", connection))
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
            CreateGraph(mainGraphControl);
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value < MinDateTime) dtpFrom.Value = MinDateTime;
            CreateGraph(mainGraphControl);

        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTo.Value > MaxDateTime) dtpTo.Value = MaxDateTime;
            CreateGraph(mainGraphControl);
        }

        private void bntClear_Click(object sender, EventArgs e)
        {
            dtpTo.Value = MaxDateTime;
            dtpFrom.Value = MinDateTime;
        }

        private void chkBodyWeight_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (sender as CheckBox);
            CreateGraph(mainGraphControl);
        }

        private void chkWeighCount_CheckedChanged(object sender, EventArgs e)
        {
            CreateGraph(mainGraphControl);
        }

        private void chkWeight_CheckedChanged(object sender, EventArgs e)
        {
            CreateGraph(mainGraphControl);
        }

        private void rbWork_CheckedChanged(object sender, EventArgs e)
        {
            CreateGraph(mainGraphControl);
        }

        private void rbNone_CheckedChanged(object sender, EventArgs e)
        {
            CreateGraph(mainGraphControl);
        }

        private void Perfomance_Shown(object sender, EventArgs e)
        {
            this.IsShown = true;
            CreateGraph(mainGraphControl);
            
        }

        private void chkTotalWork_CheckedChanged(object sender, EventArgs e)
        {
            CreateGraph(mainGraphControl);
        }

        private void chkApprox_CheckedChanged(object sender, EventArgs e)
        {
            CreateGraph(mainGraphControl);
        }
    }
}
