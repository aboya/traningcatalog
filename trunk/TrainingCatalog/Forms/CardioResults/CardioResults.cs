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
        public CardioResults()
        {
            InitializeComponent();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            new CardioResultsOptions().ShowDialog();
        }

        private void CardioResults_Load(object sender, EventArgs e)
        {
            cbType.SelectedIndex = 0;
         //   TrainingBusiness.GetCardioResults();
            try
            {
                using (connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
                {
                    using (SqlCeCommand cmd = connection.CreateCommand())
                    {
                        connection.Open();
                        TrainingList.DataSource = TrainingBusiness.GetCardioExersizes(cmd);
                        TrainingList.ValueMember = "Id";
                        TrainingList.DisplayMember = "Name";

                        dtpFrom.Value = TrainingBusiness.GetStartTrainingDay(cmd);
                        dtpTo.Value = TrainingBusiness.GetEndTrainingDay(cmd);

                        CreateCgraph(TrainingBusiness.GetCardioReport(cmd, dtpFrom.Value, dtpTo.Value));

                        connection.Close();
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
        private void CreateCgraph(Dictionary<int, List<CardioIntervalType> > cardioTrainingReport)
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
            
            int Type = 1;
            foreach (var sessionId in cardioTrainingReport.Keys)
            {
                var intervals = cardioTrainingReport[sessionId];
                double TotalTime = 0;

                foreach (CardioIntervalType i in intervals)
                {
                    if (i.Velocity > 0 && i.Time > 0)
                    {
                        string tag = string.Format("{0:0}", i.Velocity);
                        //mainIntervals.Add(i.Date.ToOADate()+TotalTime, 0, tag);
                        //mainIntervals.Add(i.Date.ToOADate()+TotalTime, i.Velocity, tag);
                        //mainIntervals.Add(i.Date.ToOADate()+TotalTime + i.Time, i.Velocity, tag);
                        //mainIntervals.Add(i.Date.ToOADate()+TotalTime + i.Time, 0, tag);
                        mainIntervals.Add(i.Date.ToOADate(), i.Velocity);
                        TotalTime += i.Time;

                    }
                }
            }

            //if (TotalTime > 0)
            //{
            //    double MaxV = (from i in intervals
            //                   select i.Velocity).Max();
            //    if (MaxV > 0)
            //    {
            //        // add resistance
            //        pane.XAxis.Scale.Min = 0;
            //        pane.XAxis.Scale.Max = TotalTime;
            //        pane.YAxis.Scale.Min = 0;
            //        pane.YAxis.Scale.Max = MaxV + MaxV * 0.2;

            //        double MaxResistance = (from i in intervals
            //                                select i.Resistance).Max();
            //        if (MaxResistance > 0)
            //        {

            //            double scaleResistance = (MaxV + MaxV * 0.1) / MaxResistance;
            //            TotalTime = 0;
            //            foreach (CardioIntervalType i in intervals)
            //            {
            //                if (i.Time > 0)
            //                {
            //                    string tag = string.Format("{0:0}", i.Resistance);
            //                    Resistance.Add(TotalTime, scaleResistance * i.Resistance, tag);
            //                    Resistance.Add(TotalTime + i.Time, scaleResistance * i.Resistance, tag);
            //                    TotalTime += i.Time;
            //                }
            //            }
            //            LineItem lineItemR = pane.AddCurve("Resistance", Resistance, Color.Blue, SymbolType.None);
            //            lineItemR.Line.Width = 3.0F;
            //        }
            //    }
            //}
            LineItem lineItem = pane.AddCurve("Velocity", mainIntervals, Color.Black, SymbolType.None);
            lineItem.Line.Fill = new Fill(Color.White, Color.Red, 45F);

            mainGraphControl.AxisChange();
            mainGraphControl.Refresh();
        }
        private void TrainingList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                using (connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
                {
                    using (SqlCeCommand cmd = connection.CreateCommand())
                    {
        
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }
    }
}
