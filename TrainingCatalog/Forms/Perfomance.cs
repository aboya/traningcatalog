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
using System.Diagnostics;
using TrainingCatalog.BusinessLogic;
namespace TrainingCatalog
{
    public partial class Perfomance : BaseForm
    {

        protected DateTime MinDateTime = DateTime.MinValue;
        protected DateTime MaxDateTime = DateTime.MaxValue;
        private bool _IsShown = false;

        protected DateTime startTimeOld, endTimeOld;
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
            connection = new SqlCeConnection(dbBusiness.connectionString);
            this.MinimumSize = new Size(475, 319);
            TrainingList.DropDownStyle = ComboBoxStyle.DropDownList;
            cbExersizeCategory.ValueMember = "Id";
            cbExersizeCategory.DisplayMember = "Name";

            TrainingList.ValueMember = "ExersizeID";
            TrainingList.DisplayMember = "ShortName";
            
     
           
            Form mainForm = Application.OpenForms["mainForm"];
            this.Location = mainForm.Location;
            try
            {
                connection.Open();
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    MinDateTime = TrainingBusiness.GetStartTrainingDay(cmd);
                    MaxDateTime = TrainingBusiness.GetEndTrainingDay(cmd);
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
            dtpFrom.Value = MinDateTime;
            dtpTo.Value = MaxDateTime;
            dtpFrom.MinDate = dtpTo.MinDate = MinDateTime;
            dtpFrom.MaxDate = dtpTo.MaxDate = MaxDateTime;
            ExersizeCategoryLoad();
            ExersizeLoad();
            this._IsShown = true;
            CreateGraph(mainGraphControl);
    
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
            if (_IsShown == false) return;
            try
            {
                Debug.WriteLine("GraphRecreated");
                mainGraphControl.IsShowPointValues = true;
                GraphPane myPane = zgc.GraphPane;
                
                myPane.CurveList.Clear();
                myPane.XAxis.Type = AxisType.Date;
                // Set the Titles

                myPane.Title.Text = "Perfomance";
                //myPane.Title.IsVisible = false;
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
                    myPane.AddCurve("Вес Тела", pointBodyWeight, Color.Blue, SymbolType.Circle);

                }

                if (chkApprox.Checked)
                {
                    LineItem myCurve3 = myPane.AddCurve("ApproxWeight", this.GetApproxWeight(BodyWeight,3), Color.Teal, SymbolType.None);
                    myCurve3.Line.IsSmooth = true;
                    myCurve3.Line.IsAntiAlias = true;
                    myCurve3.Line.SmoothTension = 0.6f;
                }
                // Generate a red curve with diamond

                // symbols, and "Porsche" in the legend
                if (chkWeighCount.Checked)
                {
                    myPane.AddCurve("Вес * Повторения",
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
        private PointPairList GetApproxWeight(List<PerfomanceDataType> weights, int iters)
        {
            PointPairList res = new PointPairList();
            List<pair<double, double>> points = new List<pair<double, double>>();

            if (weights.Count > 2)
            {
                foreach (PerfomanceDataType i in weights)
                {
                    points.Add(new pair<double, double>(i.Day.ToOADate(), i.BodyWeight));
                }
                for (int i = 0; i < iters; i++)
                {
                    for (int j = 1; j < weights.Count; j++)
                    {
                        points[j].First = (points[j].First + points[j - 1].First) / 2;
                        points[j].Second = (points[j - 1].Second + points[j].Second) / 2;
                    }
                }
                for (int i = 0; i < weights.Count; i++)
                {
                    res.Add(points[i].First, points[i].Second);
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
        private void ExersizeCategoryLoad()
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
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    categories.AddRange(TrainingBusiness.GetCategories(cmd));
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
            cbExersizeCategory.DataSource = categories;
        }
        private List<PerfomanceDataType> GetPerfomance()
        {
            
            try
            {
                int ExersizeId = Convert.ToInt32(TrainingList.SelectedValue); 
                connection.Open();
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                     return TrainingBusiness.GetPerfomance(cmd, dtpFrom.Value.Date, dtpTo.Value.Date, ExersizeId);
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
            return null;
        }
        public void ExersizeLoad()
        {
            List<ExersizeSource> exersizes = new List<ExersizeSource>();
            try
            {
                connection.Open();
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    // fill exersizes
                    exersizes = TrainingBusiness.GetExersizes(cmd, Convert.ToInt32(cbExersizeCategory.SelectedValue));
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
            {
                TrainingList.SelectedIndex = 0;
            }

            startTimeOld = MinDateTime;
            endTimeOld = MaxDateTime;
        }

        private void TrainingList_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void chkTotalWork_CheckedChanged(object sender, EventArgs e)
        {
            CreateGraph(mainGraphControl);
        }

        private void chkApprox_CheckedChanged(object sender, EventArgs e)
        {
            CreateGraph(mainGraphControl);
        }

        private void mainGraphControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            CurveItem nearestCurve;
            int iNearest;
            if (mainGraphControl.GraphPane.FindNearestPoint(new PointF(e.X, e.Y), out nearestCurve, out iNearest))
            {
                PointF p = mainGraphControl.GraphPane.GeneralTransform(nearestCurve[iNearest].X, nearestCurve[iNearest].Y, CoordType.AxisXY2Scale);
                if (Math.Abs(e.X - p.X) < 5 && Math.Abs(e.Y - p.Y) < 5)
                {
                    DateTime dt = DateTime.FromOADate(nearestCurve[iNearest].X);
                    using (Training tr = new Training())
                    {
                        tr.TrainingDate = dt.Date;
                        tr.ShowDialog(this);
                    }
                }
            }
          
        }

        private void dtpTo_CloseUp(object sender, EventArgs e)
        {
            if (dtpTo.Value > MaxDateTime) dtpTo.Value = MaxDateTime;
            _bodyWeight = null;
            CreateGraph(mainGraphControl);
        }

        private void dtpFrom_CloseUp(object sender, EventArgs e)
        {
            if (dtpFrom.Value < MinDateTime) dtpFrom.Value = MinDateTime;
            _bodyWeight = null;
            CreateGraph(mainGraphControl);
        }

        private void cbExersizeCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExersizeLoad();
        }
    }
}
