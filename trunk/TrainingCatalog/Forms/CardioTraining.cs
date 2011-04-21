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
            if(lstSession.SelectedIndex >= 0) {
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
            }else {
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
                    bs.DataSource = sessions;
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
}
