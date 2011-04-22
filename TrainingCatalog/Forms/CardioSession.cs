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
    public partial class CardioSession : BaseForm
    {
        SqlCeConnection connection;
        SqlCeCommand cmd;
        BindingSource bs;
        BindingList<CardioIntervalType> intervals;
        int sessionId;
        private void CardioSession_Load(object sender, EventArgs e)
        {
            if (sessionId == 0)
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
                intervals = new BindingList<CardioIntervalType>(TrainingBusiness.GetCardioIntervals(cmd, sessionId));
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

            
            bs = new BindingSource();
            bs.DataSource = intervals;
            gvMain.DataSource = bs;
            
        }
        public CardioSession(int sid)
        {
            sessionId = sid;


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
                    RecalcDuration();
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                using (cmd = connection.CreateCommand())
                {
                    intervals = new BindingList<CardioIntervalType>(TrainingBusiness.SaveCardioIntervals(cmd, intervals.ToList(), sessionId));
                    bs.DataSource = intervals;
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
        private void RecalcDuration()
        {
            int duration = Convert.ToInt32((from d in intervals
                                            select d.Time).Sum());
            
            txtDuration.Text = string.Format("{0:00}{1:00}", duration/60, duration % 60);

        }
    }
}
