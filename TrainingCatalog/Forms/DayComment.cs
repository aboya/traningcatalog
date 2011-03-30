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
using TrainingCatalog.BusinessLogic;

namespace TrainingCatalog.Forms
{
    public partial class DayComment : BaseForm
    {
        /// <summary>
        /// indicate when comment is changes
        /// </summary>
        bool saved;
        /// <summary>
        /// disable fires from code when datetime chaged in mounthCalendar
        /// </summary>
        bool fromCode;
        /// <summary>
        /// store last selected date for rollback if unsaved data exists
        /// </summary>
        DateTime lastDate;
        SqlCeConnection connection;
        public DayComment()
        {
            connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            InitializeComponent();
            AddCommentDays();
            saved = true;
            fromCode = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    TrainingBusiness.SaveComments(cmd, monthCalendar.SelectionStart, txtComments.Text);
                    saved = true;
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
            AddCommentDays();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (fromCode) return;
            if (!saved && txtComments.Text.Trim().Length > 0)
            {
                var result = MessageBox.Show(this, "Вы не сохранили комментарий. \n\t Желаете продолжить ?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    fromCode = true;
                    monthCalendar.SelectionStart = monthCalendar.SelectionEnd = lastDate;
                    fromCode = false;
                    return;
                }
            }
            try
            {
              
                connection.Open();
                SelectionRange range = monthCalendar.GetDisplayRange(false);
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    txtComments.Text = TrainingBusiness.GetComment(cmd, monthCalendar.SelectionStart);
                    lastDate = monthCalendar.SelectionStart;
                    saved = true;
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
            AddCommentDays();
            fromCode = false;
        }
        

        private void DayComment_FormClosed(object sender, FormClosedEventArgs e)
        {
            connection.Dispose();
            connection = null;
        }
        private void AddCommentDays()
        {
            try
            {
                connection.Open();
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    monthCalendar.BoldedDates = TrainingBusiness.GetCommentDays(cmd).ToArray();
                    monthCalendar.AddBoldedDate(DateTime.MaxValue);
                    monthCalendar.AddBoldedDate(DateTime.MinValue);
                }
                monthCalendar.UpdateBoldedDates();
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

        private void txtComments_KeyPress(object sender, KeyPressEventArgs e)
        {
            saved = false;
        }

        private void DayComment_Load(object sender, EventArgs e)
        {
            this.btnSave.Image = TrainingCatalog.AppResources.AppResources.save_48x48;
            lastDate = monthCalendar.SelectionStart;
            btnNext.Image = TrainingCatalog.AppResources.AppResources.right_48x48;
            btnPrev.Image = TrainingCatalog.AppResources.AppResources.left_48x48;
            try
            {

                connection.Open();
                SelectionRange range = monthCalendar.GetDisplayRange(false);
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    txtComments.Text = TrainingBusiness.GetComment(cmd, monthCalendar.SelectionStart);
                    lastDate = monthCalendar.SelectionStart;
                    saved = true;
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            DateTime dt = (from d in monthCalendar.BoldedDates
                           where d > monthCalendar.SelectionStart
                           select d).Min();
            if (dt < DateTime.MaxValue)
            {
                monthCalendar.SelectionStart = dt;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            DateTime dt = (from d in monthCalendar.BoldedDates
                           where d < monthCalendar.SelectionStart
                           select d).Max();
            if (dt > DateTime.MinValue)
            {
                monthCalendar.SelectionStart = dt;
            }
        }
    }
}
