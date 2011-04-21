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
            ;
            //gvMain.Rows.Add(
        }

        private void lstExersizes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gvMain_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gvMain_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if(lstExersizes.SelectedItem != null)
              intervals.Last().Name = (lstExersizes.SelectedItem as CardioExersizeType).Name;
        }
    }
}
