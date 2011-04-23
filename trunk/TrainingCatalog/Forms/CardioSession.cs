using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Configuration;
using TrainingCatalog.BusinessLogic.Types;
using TrainingCatalog.BusinessLogic;
using TrainingCatalog.BusinessLogic.Enums;

namespace TrainingCatalog.Forms
{
    public partial class CardioSession : BaseForm
    {
        SqlCeConnection connection;
        SqlCeCommand cmd;
        BindingSource bs;
        BindingList<CardioIntervalType> intervals;
        //int sessionId;
        CardioSessionType session;
        private void CardioSession_Load(object sender, EventArgs e)
        {
            if (session.Id == 0)
            {
                this.Close();
                return;
            }
            this.btnAdd.Image = TrainingCatalog.AppResources.AppResources.Plus_green_32x32;
            this.btnOk.Image = TrainingCatalog.AppResources.AppResources.save_48x48;
            connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            cmd = connection.CreateCommand();
            List<CardioExersizeType> exersizes = null;
            try
            {
                connection.Open();
                exersizes = TrainingBusiness.GetCardioExersizes(cmd);
                lstExersizes.ValueMember = "Id";
                lstExersizes.DisplayMember = "Name";
                intervals = new BindingList<CardioIntervalType>(TrainingBusiness.GetCardioIntervals(cmd, session.Id));
                session = TrainingBusiness.GetCardioSession(cmd, session.Id);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                connection.Close();
            }
            lstExersizes.DataSource = exersizes;
            if (exersizes.Count > 0)
            {
                lstExersizes.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Необходимо добавиь хотя бы одно кардио упражнение");
                this.Close();
            }
            if(session.StartTime > 0)
                txtBeginTime.Text = string.Format("{0:00}{1:00}", session.StartTime / 60, session.StartTime % 60);
            if(session.EndTime > 0)
                 txtEndTime.Text = string.Format("{0:00}{1:00}", session.EndTime / 60, session.EndTime % 60);
            if(session.StartTime > 0 && session.EndTime > 0)
                txtDuration.Text = string.Format("{0:00}{1:00}", (session.EndTime + session.StartTime) / 60, (session.EndTime + session.StartTime) % 60);
            gvMain.OnDurationChanged += new TrainingCatalog.Controls.CardioDataGridView.CustomCellValueChanged(DurationChanged);
            gvMain.OnDistanceChanged += new TrainingCatalog.Controls.CardioDataGridView.CustomCellValueChanged(DistanceChanged);
            gvMain.OnVelocityChanged += new TrainingCatalog.Controls.CardioDataGridView.CustomCellValueChanged(VelocityChanged);
            bs = new BindingSource();
            bs.DataSource = intervals;
            gvMain.DataSource = bs;
            
        }
        private void DistanceChanged(DataGridViewCell lastEditedCell)
        {

            double distance = Convert.ToInt32(lastEditedCell.Value);
            double velocity = Convert.ToDouble(gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Velocity].Value);
            double Time = Convert.ToDouble(gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Time].Value);
            if (distance > 0 && velocity == 0 && Time > 0)
            {
                velocity = distance / Time;
                gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Velocity].Value = Utils.RoundDouble2(velocity);
            }
            else if (distance > 0 && velocity > 0 && Time == 0)
            {
                Time = distance / velocity;
                gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Time].Value = Utils.RoundDouble2(Time);
            }
            RecalcDurationMain();
        }
        private void VelocityChanged(DataGridViewCell lastEditedCell)
        {
            double distance = Convert.ToInt32(gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Distance].Value);
            double velocity = Convert.ToDouble(lastEditedCell.Value);
            double Time = Convert.ToDouble(gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Time].Value);
            if (distance == 0 && velocity > 0 && Time > 0)
            {
                distance = velocity * Time;
                gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Distance].Value = Utils.RoundDouble2(distance);
            }
            else if (distance > 0 && velocity > 0 && Time == 0)
            {
                Time = distance / velocity;
                gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Time].Value = Time;
            }
            RecalcDurationMain();
        }
        private void DurationChanged(DataGridViewCell lastEditedCell)
        {
            double distance = Convert.ToInt32(gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Distance].Value);
            double velocity = Convert.ToDouble(gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Velocity].Value);
            double Time = Convert.ToDouble(lastEditedCell.Value);
            if (distance > 0 && velocity == 0 && Time > 0)
            {
                velocity = distance / Time;
                gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Velocity].Value = Utils.RoundDouble2(velocity);
            }
            else if (distance == 0 && velocity > 0 && Time > 0)
            {
                distance = velocity * Time;
                gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Distance].Value = Utils.RoundDouble2(distance);
            }
            RecalcDurationMain();
        }
        public CardioSession(int sid)
        {
            session = new CardioSessionType();
            session.Id = sid;

            InitializeComponent();
            
            
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            intervals.AddNew();
        }

        private void lstExersizes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gvMain_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int a;
            a = 0;
        }

        private void gvMain_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
            if (lstExersizes.SelectedItem != null)
            {
                if (intervals.Count > 0)
                {
                    CardioIntervalType i = intervals.Last();
                    if (i.Name == null || i.Name.Trim().Length == 0)
                    {
                        i.Name = (lstExersizes.SelectedItem as CardioExersizeType).Name;
                        i.CardioTypeId = Convert.ToInt32(lstExersizes.SelectedValue);
                    }
                    if (intervals.Count > 2)
                    {
                        var i2 = intervals[intervals.Count - 3];
                        i.HeartRate = i2.HeartRate;
                        i.Distance = i2.Distance;
                        i.Intensivity = i2.Intensivity;
                        i.Resistance = i2.Resistance;
                        i.Time = i2.Time;
                        i.Velocity = i2.Velocity;
                    }
                    RecalcDurationMain();
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DateTime start;
            DateTime end;
            bool IsStartEmpty = txtBeginTime.MaskedTextProvider.IsAvailablePosition(0)
                        && txtBeginTime.MaskedTextProvider.IsAvailablePosition(1)
                        && txtBeginTime.MaskedTextProvider.IsAvailablePosition(3)
                        && txtBeginTime.MaskedTextProvider.IsAvailablePosition(4);
            bool IsEndEmpty = txtEndTime.MaskedTextProvider.IsAvailablePosition(0)
                        && txtEndTime.MaskedTextProvider.IsAvailablePosition(1)
                        && txtEndTime.MaskedTextProvider.IsAvailablePosition(3)
                        && txtEndTime.MaskedTextProvider.IsAvailablePosition(4);
            if (!DateTime.TryParse(txtBeginTime.Text, out start) && !IsStartEmpty)
            {
                MessageBox.Show("Неправильное начальное время");
                return;
            }
            if (!DateTime.TryParse(txtEndTime.Text, out end) && !IsEndEmpty)
            {
                MessageBox.Show("Неправильное конечное время");
                return;
            }
            if (!IsStartEmpty && !IsEndEmpty)
            {
                if (end < start)
                {
                    MessageBox.Show("Начальное время больше чем конечное");
                    return;
                }
            }
            try
            {
                connection.Open();
                using (cmd = connection.CreateCommand())
                {
                    intervals = new BindingList<CardioIntervalType>(TrainingBusiness.SaveCardioIntervals(cmd, intervals.ToList(), session.Id));
                    bs.DataSource = intervals;
                    session.StartTime = IsStartEmpty ? 0 : start.Hour * 60 + start.Minute;
                    session.EndTime = IsEndEmpty ? 0 : end.Hour * 60 + end.Minute;
                    TrainingBusiness.SaveCardioSession(cmd, session);

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
        private void RecalcDurationMain()
        {
            int duration = Convert.ToInt32((from d in intervals
                                            select d.Time).Sum());

            txtDuration.Text = string.Format("{0:00}{1:00}", duration / 60, duration % 60);

            if (session.StartTime > 0)
            {
                session.EndTime = session.StartTime + duration;
                txtEndTime.Text = string.Format("{0:00}{1:00}", session.EndTime / 60, session.EndTime % 60);
            }
        }

        private void gvMain_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            //int a;
            //a = 0;
        }

        private void gvMain_KeyPress(object sender, KeyPressEventArgs e)
        {
           // if (e.KeyChar >= 96 && e.KeyChar <= 105) e.Handled = true;
        }

        private void gvMain_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            //double tmp;
            //e.Cancel = !double.TryParse((string)e.FormattedValue, out tmp);

        }

        private void gvMain_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //var ctl = e.Control as DataGridViewTextBoxEditingControl;
            //if (ctl == null)
            //{
            //    return;
            //}
            //ctl.KeyDown -= gvMain_ctl_KeyDown;
            //ctl.KeyDown += new KeyEventHandler(gvMain_ctl_KeyDown); 
        }
        private void gvMain_ctl_KeyDown(object sender, KeyEventArgs e) 
        {
 
        }

        private void gvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gvMain.BeginEdit(true);
        }

        private void gvMain_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gvMain.BeginEdit(true);
        }
    }
}
