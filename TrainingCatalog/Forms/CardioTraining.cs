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
            using (CardioSession cardioSession = new CardioSession(SessionId))
            {
                cardioSession.ShowDialog(this);
                mCalendar.AddBoldedDate(mCalendar.SelectionStart);
                mCalendar.UpdateBoldedDates();
              
            }
            UpdateSessions();
            
        }
        private void UpdateSessions()
        {
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
            bs.DataSource = sessions;
    
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
                this.WindowState = FormWindowState.Normal;
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
                    mCalendar.BoldedDates = TrainingBusiness.GetCardioTrainingDays(cmd).ToArray();
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
                int SessionId = Convert.ToInt32(lstSession.SelectedValue);
                var res = MessageBox.Show("Вы действительно хотите удалить сессию ?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        connection.Open();
                        using (cmd = connection.CreateCommand())
                        {
                           
                            TrainingBusiness.DeleteCardioSession(cmd, SessionId);

                            mCalendar.BoldedDates = TrainingBusiness.GetCardioTrainingDays(cmd).ToArray();
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
                sessions.Remove((from s in sessions where s.Id == SessionId select s).FirstOrDefault());
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
                using (CardioSession cardioSession = new CardioSession(Convert.ToInt32(lstSession.SelectedValue)))
                {
                    cardioSession.ShowDialog(this);
                }
                CreateCgraph();
                UpdateSessions();
                
            }
        }

        private void mCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
          
            UpdateSessions();

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
            
            List<CardioIntervalType> intervals = GetCardioIntervals();
            if (intervals.Count == 0)
            {
                zedGraphControl.AxisChange();
                zedGraphControl.Refresh();
                return;
            }
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
            
            foreach (CardioIntervalType i in intervals)
            {
                if (i.Velocity > 0 && i.Time > 0)
                {
                    string tag = string.Format("{0:0}",i.Velocity);
                    mainIntervals.Add(TotalTime, 0, tag);
                    mainIntervals.Add(TotalTime, i.Velocity, tag);
                    mainIntervals.Add(TotalTime + i.Time, i.Velocity, tag);
                    mainIntervals.Add(TotalTime + i.Time, 0, tag);
                    TotalTime += i.Time;

                }
            }

            if (TotalTime > 0)
            {
                double MaxV = (from i in intervals
                               select i.Velocity).Max();
                if (MaxV > 0)
                {
                    // add resistance
                    pane.XAxis.Scale.Min = 0;
                    pane.XAxis.Scale.Max = TotalTime;
                    pane.YAxis.Scale.Min = 0;
                    pane.YAxis.Scale.Max = MaxV + MaxV * 0.2;

                    double MaxResistance = (from i in intervals
                                            select i.Resistance).Max();
                    if (MaxResistance > 0)
                    {

                        double scaleResistance = (MaxV + MaxV * 0.1) / MaxResistance;
                        TotalTime = 0;
                        foreach (CardioIntervalType i in intervals)
                        {
                            if (i.Time > 0)
                            {
                                string tag = string.Format("{0:0}", i.Resistance);
                                Resistance.Add(TotalTime, scaleResistance * i.Resistance, tag);
                                Resistance.Add(TotalTime + i.Time, scaleResistance * i.Resistance, tag);
                                TotalTime += i.Time;
                            }
                        }
                       LineItem lineItemR = pane.AddCurve("Resistance", Resistance, Color.Blue, SymbolType.None);
                       lineItemR.Line.Width = 3.0F;
                    }
                }
            }
            LineItem lineItem = pane.AddCurve("Velocity", mainIntervals, Color.Black, SymbolType.None);
            lineItem.Line.Fill = new Fill(Color.White, Color.Red, 45F);

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

        private void mCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            UpdateSessions();
            CreateCgraph();
            
        }

        private void mCalendar_DoubleMouseClick(object sender, EventArgs e)
        {

            if (lstSession.SelectedValue != null)
            {
                using (CardioSession cardioSession = new CardioSession(Convert.ToInt32(lstSession.SelectedValue)))
                {
                    cardioSession.ShowDialog(this);
                }
                CreateCgraph();
                UpdateSessions();

            }
            else
            {
                btnAdd_Click(null, null);
            }
        }
        

    }
}
