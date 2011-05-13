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
    public partial class AddFromOtherDay : BaseForm
    {
        DateTime trainingDate;
        public AddFromOtherDay()
        {
            InitializeComponent();
        }
        public AddFromOtherDay(DateTime dt)
        {
            trainingDate = dt;
            InitializeComponent();
            btnAdd.Image = TrainingCatalog.AppResources.AppResources.Plus_green_32x32;
            btnNext.Image = TrainingCatalog.AppResources.AppResources.right_48x48;
            btnPrev.Image = TrainingCatalog.AppResources.AppResources.left_48x48;

        }
        private void AddFromOtherDay_Load(object sender, EventArgs e)
        {
            using (cmd = connection.CreateCommand())
            {
                try
                {
                    connection.Open();
                    mc.MinDate = TrainingBusiness.GetStartTrainingDay(cmd);
                    mc.MaxDate = TrainingBusiness.GetEndTrainingDay(cmd);
                    mc.BoldedDates = TrainingBusiness.GetTrainingDays(cmd).ToArray();
                    mc.AddBoldedDate(DateTime.MaxValue);
                    mc.AddBoldedDate(DateTime.MinValue);
                    if (mc.BoldedDates.Contains(mc.SelectionStart))
                    {
                        templateViewerControl.LoadTemplateExersizes(TrainingBusiness.GetExersizes(cmd, mc.SelectionStart));
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

        private void mc_DateChanged(object sender, DateRangeEventArgs e)
        {

            try
            {
                connection.Open();
                using (cmd = connection.CreateCommand())
                {
                    templateViewerControl.LoadTemplateExersizes(TrainingBusiness.GetExersizes(cmd, mc.SelectionStart));
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                using (SqlCeTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (cmd = connection.CreateCommand())
                        {
                            cmd.Transaction = transaction;
                            List<TemplateExersizesType> list = templateViewerControl.GetTemplateExersizes();
                            int trainingDayId = TrainingBusiness.GetTrainingDayId(cmd, trainingDate);

                            foreach (TemplateExersizesType exersize in list)
                            {
                                TrainingBusiness.AddExersize(cmd, trainingDayId, exersize.ExersizeID, exersize.Weight, exersize.Count);
                            }
                            transaction.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show(ex.Message);
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
                this.Close();
            }
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
    }
}
