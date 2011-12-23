using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrainingCatalog.BusinessLogic.Types;
using System.Configuration;
using System.Data.SqlServerCe;
using TrainingCatalog.BusinessLogic;

namespace TrainingCatalog.Forms
{
    public partial class CardioResultsOptions : BaseForm
    {
        Dictionary<int, List<CardioIntervalType> > cardioReport ;
        Units units;
        public CardioResultsOptions(Dictionary<int, List<CardioIntervalType> > cardioRpr)
        {
            cardioReport = cardioRpr;
            
            InitializeComponent();
        }

        private void CardioResultsOptions_Load(object sender, EventArgs e)
        {
            cbDistance.ValueMember = "Type";
            cbDistance.DisplayMember = "Name";

            cbSpeedTime.ValueMember = "Type";
            cbSpeedTime.DisplayMember = "Name";

            cbSpeedDistance.ValueMember = "Type";
            cbSpeedDistance.DisplayMember = "Name";

            cbTime.ValueMember = "Type";
            cbTime.DisplayMember = "Name";

            cbDistance.DataSource = Units.DistanceDataSource.Create();
            cbTime.DataSource = Units.TimeDataSource.Create();
            cbSpeedDistance.DataSource = Units.DistanceDataSource.Create();
            cbSpeedTime.DataSource = Units.TimeDataSource.Create();

          
            string o;
            o = dbBusiness.GetValue("DistanceUnit");
            if (!string.IsNullOrEmpty(o)) cbDistance.SelectedIndex = Convert.ToInt32(o);
            o = dbBusiness.GetValue("TimeUnit");
            if (!string.IsNullOrEmpty(o)) cbTime.SelectedIndex = Convert.ToInt32(o);
            o = dbBusiness.GetValue("Velocity_DistanceUnit");
            if (!string.IsNullOrEmpty(o)) cbSpeedDistance.SelectedIndex = Convert.ToInt32(o);
            o = dbBusiness.GetValue("Velocity_TimeUnit");
            if (!string.IsNullOrEmpty(o)) cbSpeedTime.SelectedIndex = Convert.ToInt32(o);
            units = new Units((Units.DistanceUnit)cbSpeedDistance.SelectedValue,
                    (Units.TimeUnit)cbSpeedTime.SelectedValue,
                    (Units.DistanceUnit)cbDistance.SelectedValue,
                    (Units.TimeUnit)cbTime.SelectedValue);
        }

        private void cbDistance_SelectionChangeCommitted(object sender, EventArgs e)
        {
            List<CardioIntervalType> ll = new List<CardioIntervalType>();
            Units.DistanceUnit current = (Units.DistanceUnit)cbDistance.SelectedValue;
            foreach (var l in cardioReport.Values)
            {
                ll.AddRange(l);
               
            }
            units.DistanceChanged(current, ll);
            dbBusiness.SaveValue("DistanceUnit", Convert.ToString((int)current));
        }
        private void cbTime_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Units.TimeUnit current = (Units.TimeUnit)cbTime.SelectedValue;
            List<CardioIntervalType> ll = new List<CardioIntervalType>();
            foreach (var l in cardioReport.Values)
            {
                ll.AddRange(l);
                
            }
            units.TimeChanged(current, ll);
            dbBusiness.SaveValue("TimeUnit", Convert.ToString((int)current));
        }
        private void cbSpeedDistance_SelectionChangeCommitted(object sender, EventArgs e)
        {

            Units.DistanceUnit current = (Units.DistanceUnit)cbSpeedDistance.SelectedValue;
            List<CardioIntervalType> ll = new List<CardioIntervalType>();
            foreach (var l in cardioReport.Values)
            {
                ll.AddRange(l);
            }
            units.SpeedDistanceChanged(current, ll);
            dbBusiness.SaveValue("Velocity_DistanceUnit", Convert.ToString((int)current));

        }
        private void cbSpeedTime_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Units.TimeUnit current = (Units.TimeUnit)cbSpeedTime.SelectedValue;
            List<CardioIntervalType> ll = new List<CardioIntervalType>();
            foreach (var l in cardioReport.Values)
            {
                ll.AddRange(l);
                
            }
            units.SpeedTimeChanged(current, ll);
            dbBusiness.SaveValue("Velocity_TimeUnit", Convert.ToString((int)current));
        }
    }
}
