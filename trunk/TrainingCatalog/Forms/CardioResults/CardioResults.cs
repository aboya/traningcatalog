using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrainingCatalog.BusinessLogic;
using System.Data.SqlServerCe;
using System.Configuration;
using ZedGraph;
using TrainingCatalog.BusinessLogic.Types;

namespace TrainingCatalog.Forms
{
    public partial class CardioResults : BaseForm
    {
        Dictionary<int, List<CardioIntervalType>> cardioTrainingReport = new Dictionary<int, List<CardioIntervalType>>();
        Dictionary<int, string> exersizeNames = new Dictionary<int, string>();
        CardioFiltrationType filter = null;
        public CardioResults()
        {
            InitializeComponent();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            if(filter == null) {
                filter = new CardioFiltrationType();
            }
            new CardioResultsOptions(cardioTrainingReport, filter).ShowDialog();
            CreateCgraph();
        }

        private void CardioResults_Load(object sender, EventArgs e)
        {
            cbType.SelectedIndex = 0;
            filter = null;
         //   TrainingBusiness.GetCardioResults();
            try
            {
                using (connection = new SqlCeConnection(dbBusiness.connectionString))
                {
                    using (SqlCeCommand cmd = connection.CreateCommand())
                    {

                        connection.Open();
                        var exersizes = TrainingBusiness.GetCardioExersizes(cmd);
                        exersizes.Insert(0,new CardioExersizeType()
                        {
                            Id = -1,
                            Name = "Все"
                        });
                        TrainingList.DataSource = exersizes;
                        TrainingList.ValueMember = "Id";
                        TrainingList.DisplayMember = "Name";
                        foreach (var ex in exersizes)
                        {
                            exersizeNames[ex.Id] = ex.Name;
                        }
                        dtpFrom.Value = TrainingBusiness.GetStartTrainingDay(cmd);
                        dtpTo.Value = TrainingBusiness.GetEndTrainingDay(cmd);
                        cardioTrainingReport = TrainingBusiness.GetCardioReport(cmd, dtpFrom.Value, dtpTo.Value);
                        

                        connection.Close();
                    }
                }
                string o;
                Units.DistanceUnit SpeedDistance = Units.DistanceUnit.Meters, Distance = Units.DistanceUnit.Meters;
                Units.TimeUnit Time = Units.TimeUnit.Hour, SpeedTime = Units.TimeUnit.Hour;
                o = dbBusiness.GetValue("DistanceUnit");
                if (!string.IsNullOrEmpty(o)) Distance = (Units.DistanceUnit) Convert.ToInt32(o);
                o = dbBusiness.GetValue("TimeUnit");
                if (!string.IsNullOrEmpty(o)) Time= (Units.TimeUnit) Convert.ToInt32(o);
                o = dbBusiness.GetValue("Velocity_DistanceUnit");
                if (!string.IsNullOrEmpty(o)) SpeedDistance= (Units.DistanceUnit) Convert.ToInt32(o);
                o = dbBusiness.GetValue("Velocity_TimeUnit");
                if (!string.IsNullOrEmpty(o)) SpeedTime = (Units.TimeUnit) Convert.ToInt32(o);
                if (ConfigurationManager.ConnectionStrings["db"] != null)
                {
                    connection = new SqlCeConnection(dbBusiness.connectionString);
                }
                Units units = new Units(SpeedDistance, SpeedTime, Distance, Time);
                foreach (var l in cardioTrainingReport.Values)
                {
                    units.ConvertToUnits(l);
                }
                CreateCgraph();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private void CreateCgraph()
        {

            GraphPane pane = mainGraphControl.GraphPane;

            pane.CurveList.Clear();


            if (cardioTrainingReport == null || cardioTrainingReport.Count == 0)
            {
                mainGraphControl.AxisChange();
                mainGraphControl.Refresh();
                return;
            }
            //pane.XAxis.Type = AxisType.Linear;
            // Set the Titles
            pane.GraphObjList.Clear();
            pane.CurveList.Clear();
            //myPane.Title.IsVisible = false;
            mainGraphControl.IsShowPointValues = true;
            pane.XAxis.Title.Text = "Time";
            pane.YAxis.Title.Text = cbType.SelectedText;
            pane.Title.IsVisible = false;
            pane.XAxis.Type = AxisType.Date;
            PointPairList mainIntervals = new PointPairList();
            PointPairList Resistance = new PointPairList();

            int Type = cbType.SelectedIndex + 1;
            int cardioExersizeId = Convert.ToInt32(TrainingList.SelectedValue);
            foreach (var sessionId in cardioTrainingReport.Keys)
            {
                var intervals = cardioTrainingReport[sessionId];
                double TotalTime = 0;

                foreach (CardioIntervalType i in intervals)
                {
                    if (Filtration(i)) continue;
                    double value;
                    if (Type == 1) value = i.Velocity;
                    else if (Type == 2) value = i.Time;
                    else value = i.Distance;
                    if (cardioExersizeId >= 0 && cardioExersizeId != i.CardioTypeId) continue;
                    if (i.Date < dtpFrom.Value || i.Date.Date > dtpTo.Value) continue;
                    if (value > 0 && i.Time > 0)
                    {
                        string tag = string.Format("S:{0:0.##} V:{1:0.##} T:{2:0.##} | {3} ({4})", 
                                            i.Distance, i.Velocity, i.Time, 
                                            i.Date.AddSeconds(TotalTime).ToString("dd.MM.yy"), 
                                            i.Date.AddSeconds(TotalTime).DayOfWeek.ToString());
                        if (cardioExersizeId < 0) tag += string.Format("|{0}", exersizeNames[i.CardioTypeId]);
                        // string tag = string.Format("{0:0}", value);
                        mainIntervals.Add(i.Date.AddSeconds(TotalTime).ToOADate(), 0, tag);
                        mainIntervals.Add(i.Date.AddSeconds(TotalTime).ToOADate(), value, tag);
                        mainIntervals.Add(i.Date.AddSeconds(TotalTime + i.Time).ToOADate(), value, tag);
                        mainIntervals.Add(i.Date.AddSeconds(TotalTime + i.Time).ToOADate(), 0, tag);
                        TotalTime += i.Time;
                    }
                    
                }
            }


            LineItem lineItem = pane.AddCurve("Velocity", mainIntervals, Color.Black, SymbolType.None);
            lineItem.Line.Fill = new Fill(Color.White, Color.Red, 45F);

            mainGraphControl.AxisChange();
            mainGraphControl.Refresh();
        }
        private bool Filtration(CardioIntervalType i)
        {
            if (filter != null)
            {
                if(filter.DistanceFrom > 0.01) 
                {
                    if (i.Distance < filter.DistanceFrom) return true;
                }
                if (filter.DistanceTo > 0.01)
                {
                    if (i.Distance > filter.DistanceTo) return true;
                }

                if (filter.VelocityFrom > 0.01)
                {
                    if (i.Velocity < filter.VelocityFrom) return true;
                }
                if (filter.VelocityTo > 0.01)
                {
                    if (i.Velocity > filter.VelocityTo) return true;
                }

                if (filter.TimeFrom > 0.01)
                {
                    if (i.Time < filter.TimeFrom) return true;
                }
                if (filter.TimeTo > 0.01)
                {
                    if (i.Time > filter.TimeTo) return true;
                }

            }
            return false;
 
        }
        private void TrainingList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CreateCgraph();

        }

        private void cbType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CreateCgraph();
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            CreateCgraph();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            CreateCgraph();
        }

        private void baseButton1_Click(object sender, EventArgs e)
        {
            CardioResults_Load(null, null);
        }
    }
}
