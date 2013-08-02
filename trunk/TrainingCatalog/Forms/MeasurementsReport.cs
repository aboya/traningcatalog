using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using TrainingCatalog.BusinessLogic.Types;
using TrainingCatalog.BusinessLogic;
using System.Data.SqlServerCe;

namespace TrainingCatalog.Forms
{
    public partial class MeasurementsReport : BaseForm
    {
 
        bool _IsShown = false;
        public MeasurementsReport()
        {
            InitializeComponent();
        }

 
        private void MeasurementsReport_Load(object sender, EventArgs e)
        {
            DateTime MinDateTime = DateTime.MinValue, MaxDateTime = DateTime.MaxValue;
            foreach (var p in typeof(MeasurementType).GetProperties())
            {
                cbBodyPart.Items.Add(p.Name);
            }
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

            cbBodyPart.SelectedIndex = 0;
            _IsShown = true;
            CreateGraph(mainGraphControl);
        }
        private void CreateGraph(ZedGraphControl zgc)
        {
            // get a reference to the GraphPane
            if (_IsShown == false) return;
            try
            {
                mainGraphControl.IsShowPointValues = true;
                GraphPane myPane = zgc.GraphPane;
                myPane.CurveList.Clear();
                myPane.XAxis.Type = AxisType.Date;
                // Set the Titles
                myPane.Title.Text = "Measurements";
                //myPane.Title.IsVisible = false;
                myPane.XAxis.Title.Text = "Date";
                myPane.YAxis.Title.Text = "Cm";
                List<MeasurementType> measurements = null;
                // Make up some data arrays based on the Sine function
                try
                {
                    connection.Open();
                    using (SqlCeCommand cmd = connection.CreateCommand())
                    {
                        measurements = TrainingBusiness.GetMeasurementReport(cmd, dtpFrom.Value, dtpTo.Value);
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    return;
                }
                finally
                {
                    connection.Close();
                }
                //double x, y1, y2;
                string fieldName = Convert.ToString(cbBodyPart.SelectedItem);
                PointPairList pointWeightCount = new PointPairList();
                bool IsBodyWeight = (fieldName == "BodyWeight");
                PointPairList pointBodyFat = new PointPairList();
                PointPairList pointWater = new PointPairList();
                PointPairList pointMuscule = new PointPairList();

                foreach (var m in measurements)
                {
                   float value = Convert.ToSingle(typeof(MeasurementType).GetProperty(fieldName).GetValue(m, null));
                   double date = m.date.ToOADate();
                   if (Math.Abs(value) <= 0.01) continue;
                   string tag = string.Format("Cm:{0:0.##} | {1} ({2})", value, m.date.ToString("dd.MM.yy"), m.date.DayOfWeek.ToString());
                   pointWeightCount.Add(date, value, tag);
                   if (IsBodyWeight)
                   {
                       float Percent;
                       Percent = Convert.ToSingle(typeof(MeasurementType).GetProperty("BodyFat").GetValue(m, null));
                       if (Math.Abs(Percent) > 0.01) {
                           tag = string.Format("Cm:{0:0.##} | {1} ({2})", value * Percent / 100.0, m.date.ToString("dd.MM.yy"), m.date.DayOfWeek.ToString());
                           pointBodyFat.Add(date, value * Percent / 100.0, tag); 
                       }
                       Percent = Convert.ToSingle(typeof(MeasurementType).GetProperty("Water").GetValue(m, null));
                       if (Math.Abs(Percent) > 0.01)
                       {
                           tag = string.Format("Cm:{0:0.##} | {1} ({2})", value * Percent / 100.0, m.date.ToString("dd.MM.yy"), m.date.DayOfWeek.ToString());
                           pointWater.Add(date, value * Percent / 100.0, tag);
                       }
                       Percent = Convert.ToSingle(typeof(MeasurementType).GetProperty("Muscule").GetValue(m, null));
                       if (Math.Abs(Percent) > 0.01)
                       {
                           tag = string.Format("Cm:{0:0.##} | {1} ({2})", value * Percent / 100.0, m.date.ToString("dd.MM.yy"), m.date.DayOfWeek.ToString());
                           pointMuscule.Add(date, value * Percent / 100.0, tag);
                       }

                   }

                }
                myPane.AddCurve("Cm", pointWeightCount, Color.Brown, SymbolType.Circle);
                if (IsBodyWeight)
                {
                    myPane.AddCurve("BodyFat", pointBodyFat, Color.Green, SymbolType.Plus);
                    myPane.AddCurve("Water", pointWater, Color.Red, SymbolType.Square);
                    myPane.AddCurve("Muscule", pointMuscule, Color.Purple, SymbolType.Triangle);
                }

                zgc.AxisChange();
                zgc.Refresh();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        private void cbBodyPart_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CreateGraph(mainGraphControl);
        }

  
    }
}
