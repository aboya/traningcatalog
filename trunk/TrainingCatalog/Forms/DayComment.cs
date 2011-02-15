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
    public partial class DayComment : Form
    {
        SqlCeConnection connection;
        public DayComment()
        {
            connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            InitializeComponent();
            AddCommentDays();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    TrainingBusiness.SaveComments(cmd, monthCalendar.SelectionStart, txtComments.Text);
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

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            try
            {
                connection.Open();
                SelectionRange range = monthCalendar.GetDisplayRange(false);
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    txtComments.Text = TrainingBusiness.GetComment(cmd, monthCalendar.SelectionStart);
                    foreach (DateTime day in TrainingBusiness.GetCommentDays(cmd, range.Start, range.End))
                    {
                        monthCalendar.AddBoldedDate(day);
                    }
                    monthCalendar.UpdateBoldedDates();
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
                 SelectionRange range =   monthCalendar.GetDisplayRange(false);
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                     foreach(DateTime day in TrainingBusiness.GetCommentDays(cmd,range.Start, range.End))
                     {
                         monthCalendar.AddBoldedDate(day);
                     }
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
    }
}
