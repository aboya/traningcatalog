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
using System.Diagnostics;

namespace TrainingCatalog.Forms
{
    public partial class CardioSession : BaseForm
    {

     
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
            connection = new SqlCeConnection(dbBusiness.connectionString);
            cmd = connection.CreateCommand();
            List<CardioExersizeType> exersizes = null;
            List<CardioIntervalType> intervals = null;
            try
            {
                connection.Open();
                exersizes = TrainingBusiness.GetCardioExersizes(cmd);
                lstExersizes.ValueMember = "Id";
                lstExersizes.DisplayMember = "Name";
                session = TrainingBusiness.GetCardioSession(cmd, session.Id);
                intervals = TrainingBusiness.GetCardioIntervals(cmd, session.Id);
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
            if (session.StartTime > 0)
                txtBeginTime.Text = string.Format("{0:00}{1:00}", session.StartTime / 60, session.StartTime % 60);
            if (session.EndTime > 0)
                txtEndTime.Text = string.Format("{0:00}{1:00}", session.EndTime / 60, session.EndTime % 60);
            if (intervals != null) cardioExersizesControl.LoadCardioExersizes(intervals);

        }

        public CardioSession(int sid)
        {
            session = new CardioSessionType();
            session.Id = sid;

            InitializeComponent();
            
            
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            cardioExersizesControl.AddRow((CardioExersizeType)lstExersizes.SelectedItem);
        }

        private void lstExersizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstExersizes.SelectedItem != null)
            {
                CardioExersizeType i = (CardioExersizeType)lstExersizes.SelectedItem;
                cardioExersizesControl.DefaultCardioType = i;
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
                    cardioExersizesControl.LoadCardioExersizes(TrainingBusiness.SaveCardioIntervals(cmd, cardioExersizesControl.GetCardioExersizes(), session.Id));
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

        private void btnFromTemplate_Click(object sender, EventArgs e)
        {
            List<CardioIntervalType> res;
            new CardioAddFromTemplate(session, out res).ShowDialog(this);
            foreach(CardioIntervalType i in res) 
            {
                this.cardioExersizesControl.AddRow(i);  
            }
        }

        private void btnFromOtherDay_Click(object sender, EventArgs e)
        {
            List<CardioIntervalType> res;
            new CardioAddFromAnotherDay(out res).ShowDialog(this);
            foreach (CardioIntervalType i in res)
            {
                this.cardioExersizesControl.AddRow(i);
            }
        }



        //==========================================================================================================================

    }
}
