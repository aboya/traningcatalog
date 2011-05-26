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

namespace TrainingCatalog.Forms
{
    public partial class CardioAddFromAnotherDay : BaseForm
    {
        Dictionary<CardioSessionType, List<CardioIntervalType>> data = new Dictionary<CardioSessionType, List<CardioIntervalType>>();
        List<CardioIntervalType> exersizes = new List<CardioIntervalType>();
        public CardioAddFromAnotherDay()
        {
            InitializeComponent();
        }
        public CardioAddFromAnotherDay(out List<CardioIntervalType> res)
        {
            InitializeComponent();
            exersizes = new List<CardioIntervalType>();
            res = exersizes;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            DateTime dt = (from d in mc.BoldedDates
                           where d < mc.SelectionStart
                           select d).Max();
            if (dt > DateTime.MinValue)
            {
                mc.SelectionStart = dt;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            DateTime dt = (from d in mc.BoldedDates
                           where d > mc.SelectionStart
                           select d).Min();
            if (dt < DateTime.MaxValue)
            {
                mc.SelectionStart = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            exersizes.Clear();
            var list = cardioExersizesControl.GetCardioExersizes();
            foreach (var item in list)
            {
                item.Id = 0;
            }
            exersizes.AddRange(list);
            this.Close();
        }

        private void mc_DateChanged(object sender, DateRangeEventArgs e)
        {
            DataBind();
        }

        private void CardioAddFromAnotherDay_Load(object sender, EventArgs e)
        {
            btnAdd.Image = TrainingCatalog.AppResources.AppResources.Plus_green_32x32;
            btnNext.Image = TrainingCatalog.AppResources.AppResources.right_48x48;
            btnPrev.Image = TrainingCatalog.AppResources.AppResources.left_48x48;

            cbSessions.ValueMember = "Id";
            cbSessions.DisplayMember = "Name";
            
            DataBind();
            if (data.Count == 0)
            {
                MessageBox.Show("Вы не провели ниодной кардио тренировки");
                this.Close();
            }
        }
        private void DataBind()
        {
            data = GetCardioSession(mc.SelectionStart.Date);
            if (data.Count > 0)
            {
                cbSessions.DataSource = data.Keys.ToList();
                if (cbSessions.Items.Count > 0)
                {
                    cbSessions.SelectedIndex = 0;
                    cbSessions_SelectionChangeCommitted(cbSessions, null);
                }
            }
        }
        private Dictionary<CardioSessionType,List<CardioIntervalType>> GetCardioSession(DateTime dt)
        {
            Dictionary<CardioSessionType, List<CardioIntervalType>> res = new Dictionary<CardioSessionType, List<CardioIntervalType>>();
            try
            {
                connection.Open();
                using (cmd = connection.CreateCommand())
                {
                    foreach (var session in TrainingBusiness.GetCardioSessions(cmd, dt))
                    {
                        res[session] = TrainingBusiness.GetCardioIntervals(cmd, session.Id);
                    }

                    if (mc.BoldedDates.Length == 0)
                    {
                        List<DateTime> dates = TrainingBusiness.GetCardioTrainingDays(cmd);

                        var q = (from d in dates
                                 select d);
                        mc.MaxDate = q.Max();
                        mc.MinDate = q.Min();
                        dates.Add(DateTime.MaxValue);
                        dates.Add(DateTime.MinValue);
                        mc.BoldedDates = dates.ToArray();
                    }
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
            return res;
        }

        private void cbSessions_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cardioExersizesControl.LoadCardioExersizes(data[(CardioSessionType)cbSessions.SelectedItem]);
        }
    }
}
