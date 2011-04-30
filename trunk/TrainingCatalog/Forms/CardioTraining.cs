using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrainingCatalog.BusinessLogic.Types;
using TrainingCatalog.BusinessLogic;
using System.Data.SqlServerCe;
using System.Configuration;
using ZedGraph;

namespace TrainingCatalog.Forms
{
    public partial class CardioTraining : BaseForm
    {
        BindingSource bs;
        BindingList<CardioSessionType> sessions;
        SqlCeConnection connection;
        SqlCeCommand cmd;
        public CardioTraining()
        {
            InitializeComponent();
            chkGraph_CheckedChanged(null, null);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int SessionId = 0;
            try
            {
                connection.Open();
                using (cmd = connection.CreateCommand())
                {
                    var newSession = TrainingBusiness.CreateCardioSession(cmd, mCalendar.SelectionStart.Date);
                    sessions.Add(newSession);
                    SessionId = newSession.Id;
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
            new CardioSession(SessionId).ShowDialog(this);
        }

        private void chkGraph_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGraph.Checked)
            {
                zedGraphControl.Visible = true;
                this.MinimumSize = new System.Drawing.Size(465, 426);
                this.MaximumSize = new Size(0, 0);
                CreateCgraph();
            }
            else
            {
                zedGraphControl.Visible = false;
                this.MaximumSize = this.MinimumSize = new System.Drawing.Size(465, 228);
            }
        }

        private void CardioTraining_Load(object sender, EventArgs e)
        {
            connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            try
            {
                connection.Open();
                using (cmd = connection.CreateCommand())
                {
                    sessions = new BindingList<CardioSessionType>(TrainingBusiness.GetCardioSessions(cmd, mCalendar.SelectionStart.Date));
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
            bs = new BindingSource();
            bs.DataSource = sessions;
            lstSession.ValueMember = "Id";
            lstSession.DisplayMember = "Name";
            lstSession.DataSource = bs;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstSession.SelectedIndex >= 0)
            {
                var res = MessageBox.Show("Вы действительно хотите удалить сессию ?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        connection.Open();
                        using (cmd = connection.CreateCommand())
                        {
                            int SessionId = Convert.ToInt32(lstSession.SelectedValue);
                            TrainingBusiness.DeleteCardioSession(cmd, SessionId);
                            sessions.Remove((from s in sessions where s.Id == SessionId select s).FirstOrDefault());
                            // sessions = new BindingList<CardioSessionType>(TrainingBusiness.GetCardioSessions(cmd, mCalendar.SelectionStart.Date));
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
            }
            else
            {
                MessageBox.Show("Вы не выбрали что удалять");
            }
        }

        private void lstSession_DoubleClick(object sender, EventArgs e)
        {
            if (lstSession.SelectedValue != null)
            {
                new CardioSession(Convert.ToInt32(lstSession.SelectedValue)).ShowDialog(this);
                
            }
        }

        private void mCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            try
            {
                using (cmd = connection.CreateCommand())
                {
                    connection.Open();
                    sessions = new BindingList<CardioSessionType>(TrainingBusiness.GetCardioSessions(cmd, mCalendar.SelectionStart.Date));
                    
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
            bs.DataSource = sessions;
        }

        private void lstSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateCgraph();
        }
        private void CreateCgraph()
        {
            if (chkGraph.Checked == false) return;
            if (lstSession.SelectedItem == null) return;
            GraphPane pane = zedGraphControl.GraphPane;

            pane.CurveList.Clear();
            Bar a;
            
            List<CardioIntervalType> intervals = GetCardioIntervals();
            if (intervals.Count == 0) return;
            //pane.XAxis.Type = AxisType.Linear;
            // Set the Titles
            pane.GraphObjList.Clear();
            pane.CurveList.Clear();
            //myPane.Title.IsVisible = false;
            zedGraphControl.IsShowPointValues = true;
            pane.XAxis.Title.Text = "Time";
            pane.YAxis.Title.Text = "Velocity";
            pane.Title.IsVisible = false;
            PointPairList mainIntervals = new PointPairList();
            PointPairList Resistance = new PointPairList();
            double TotalTime = 0;
            double MaxV = 0;
            foreach (CardioIntervalType i in intervals)
            {
                if (i.Velocity > 0 && i.Time > 0)
                {
                    mainIntervals.Add(TotalTime, i.Velocity);
                    BoxObj box = new BoxObj(TotalTime, i.Velocity, i.Time, i.Velocity);
                   // box.IsClippedToChartRect = true;
                    box.Border.Color = Color.Black;
                    if (i.Velocity > MaxV) MaxV = i.Velocity;
                   // box.Fill.SecondaryValueGradientColor = Color.Brown;
                   // box.Fill.Color = Color.Black;
                   // box.Fill.Type = FillType.GradientByColorValue;
                 //   pane.GraphObjList.Add(box);
                    TotalTime += i.Time;

                }
            }
            BarItem bi = pane.AddBar("", mainIntervals, Color.Red);
            if (TotalTime == 0) return;
            // add resistance
            pane.XAxis.Scale.Min = 0;
            pane.XAxis.Scale.Max = TotalTime;
            pane.YAxis.Scale.Min = 0;
            pane.YAxis.Scale.Max = MaxV;
           
            double MaxResistance = (from i in intervals
                                    where i.Resistance > 0
                                    select i.Resistance).Max();
            if (MaxResistance== 0) return;
            
            double scaleResistance = MaxV / MaxResistance;
            TotalTime = 0;
            foreach (CardioIntervalType i in intervals)
            {
                string tag = string.Format("{0:0}", i.Resistance);
                Resistance.Add(TotalTime, scaleResistance * i.Resistance, tag);
                TotalTime += i.Time;
            }
            BoxObj box1 = new BoxObj(1, 10, 1, 1);
            pane.GraphObjList.Add(box1);


            
            // pane.AddCurve("Weight", mainIntervals, Color.Brown, SymbolType.None);
            pane.AddCurve("", Resistance, Color.Blue, SymbolType.Circle);
            zedGraphControl.AxisChange();
            zedGraphControl.Refresh();
        }
        private List<CardioIntervalType> GetCardioIntervals()
        {
            List<CardioIntervalType> res = new List<CardioIntervalType>();
            try
            {
                using (cmd = connection.CreateCommand())
                {
                    connection.Open();

                    res = TrainingBusiness.GetCardioIntervals(cmd, Convert.ToInt32(lstSession.SelectedValue));
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
        

    }
}
