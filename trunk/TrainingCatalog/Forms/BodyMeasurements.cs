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

namespace TrainingCatalog.Forms
{
    public partial class BodyMeasurements : BaseForm
    {

        bool IsSaved = true;
        bool fromCode = false;
        DateTime lastDate;
        public BodyMeasurements()
        {
            InitializeComponent();
            connection = new SqlCeConnection(dbBusiness.connectionString);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    MeasurementType m = new MeasurementType();
                    m.Biceps_h = Convert.ToSingle(txtBiceps_h.Text);
                    m.Biceps_l = Convert.ToSingle(txtBiceps_l.Text);
                    m.BodyFat = Convert.ToSingle(txtBodyFat.Text);
                    m.BodyWeight = Convert.ToSingle(txtBodyWeight.Text);
                    m.Chest_h = Convert.ToSingle(txtChest_h.Text);
                    m.Chest_l = Convert.ToSingle(txtChest_l.Text);
                    m.Hip_h = Convert.ToSingle(txtHip_h.Text);
                    m.Hip_l = Convert.ToSingle(txtHip_l.Text);
                    m.Midarm_h = Convert.ToSingle(txtMidarm_h.Text);
                    m.Midarm_l = Convert.ToSingle(txtMidarm_l.Text);
                    m.Waistline_h = Convert.ToSingle(txtWaistline_h.Text);
                    m.Waistline_l = Convert.ToSingle(txtWaistline_l.Text);
                    m.Muscule = Convert.ToSingle(txtMuscule.Text);
                    m.Water = Convert.ToSingle(txtWater.Text);
                    m.date = mCalendar.SelectionStart.Date;
                    TrainingBusiness.SaveMeasurement(cmd, m);
                    BindBoldedDates(cmd);
                    IsSaved = true;
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

        private void BodyMeasurements_Load(object sender, EventArgs e)
        {
            BindData(mCalendar.SelectionStart.Date, true);
            btnPrev.Image = AppResources.AppResources.left_48x48;
            btnNext.Image = AppResources.AppResources.right_48x48;
            btnSave.Image = AppResources.AppResources.save_48x48;
            lastDate = mCalendar.SelectionStart;
            
        }
        private void BindBoldedDates(SqlCeCommand cmd)
        {
            mCalendar.BoldedDates = TrainingBusiness.GetMeasurementDays(cmd).ToArray();
            mCalendar.AddBoldedDate(DateTime.MaxValue);
            mCalendar.AddBoldedDate(DateTime.MinValue);
        }
        private void BindData(DateTime date, bool bindBoldDates)
        {
            try
            {
                connection.Open();
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    MeasurementType m = TrainingBusiness.GetMeasurement(cmd, date);
                    txtBiceps_h.Text = m.Biceps_h.ToString();
                    txtBiceps_l.Text = m.Biceps_l.ToString();
                    txtBodyFat.Text = m.BodyFat.ToString();
                    txtBodyWeight.Text = m.BodyWeight.ToString();
                    txtChest_h.Text = m.Chest_h.ToString();
                    txtChest_l.Text = m.Chest_l.ToString();
                    txtHip_h.Text = m.Hip_h.ToString();
                    txtHip_l.Text = m.Hip_l.ToString();
                    txtMidarm_h.Text = m.Midarm_h.ToString();
                    txtMidarm_l.Text = m.Midarm_l.ToString();
                    txtWaistline_h.Text = m.Waistline_h.ToString();
                    txtWaistline_l.Text = m.Waistline_l.ToString();
                    txtMuscule.Text = m.Muscule.ToString();
                    txtWater.Text = m.Water.ToString();
                    if (bindBoldDates)
                    {
                        BindBoldedDates(cmd);
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
        }

        private void mCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (fromCode) return;
            if (!IsSaved)
            {
                var res = MessageBox.Show(this, "Вы не сохранили данные. \n\t Желаете продолжить ?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == System.Windows.Forms.DialogResult.No)
                {
                    fromCode = true;
                    mCalendar.SelectionStart = lastDate;
                    fromCode = false;
                    return;
                }
            }
            IsSaved = true;
            lastDate = mCalendar.SelectionStart;
            BindData(mCalendar.SelectionStart.Date,false);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            DateTime dt = (from d in mCalendar.BoldedDates
                           where d > mCalendar.SelectionStart.Date
                           select d).Min();
            if (dt < DateTime.MaxValue && dt > DateTime.MinValue)
            {
              
                mCalendar.SelectionStart = dt;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            DateTime dt = (from d in mCalendar.BoldedDates
                           where d < mCalendar.SelectionStart.Date
                           select d).Max();
            if (dt > DateTime.MinValue && dt < DateTime.MaxValue)
            {
                
                mCalendar.SelectionStart = dt;
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            IsSaved = false;
        }

 
    }
}
