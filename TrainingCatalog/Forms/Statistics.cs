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
    public partial class Statistics : Form
    {
        SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
        public Statistics()
        {
            InitializeComponent();
            lstParams.FullRowSelect = true;
           // mcEnd.WarningDates.Add(DateTime.Today.AddDays(1));
          //  mcEnd.WarningDates.Add(DateTime.Today.AddDays(3));
          //  mcEnd.WarningDates.Add(DateTime.Today.AddDays(-3));
            AddTrainingDays(connection, mcStart);
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            BodyWeightAdd();
        }
        private void BodyWeightAdd()
        {
            string[] arr = new string[2];
            arr[0] = "Прибавка в массе";
            arr[1] = "3";
            ListViewItem i = new ListViewItem(arr, "BodyWeight");
            lstParams.Items.Add(i);
        }

        private void mcStart_DateChanged(object sender, DateRangeEventArgs e)
        {
            AddTrainingDays(connection, mcStart);
        }
        public static void AddTrainingDays(SqlCeConnection connection, MonthCalendar mc)
        {
            SelectionRange range = mc.GetDisplayRange(false);
            try
            {
                connection.Open();
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    //foreach (DateTime day in TrainingBusiness.GetTrainingDays(cmd, range.Start, range.End))
                    //{
                    //    mc.AddBoldedDate(day);
                    //}
                }
                mc.UpdateBoldedDates();
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
