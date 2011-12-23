using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using TrainingCatalog.BusinessLogic.Types;
using TrainingCatalog.BusinessLogic.Enums;
using TrainingCatalog.BusinessLogic;
using System.Configuration;

namespace TrainingCatalog.Controls
{
    public partial class CardioExersizesControl : UserControl
    {

        public delegate void DistanceChangedHandler(double distance);
        public event DistanceChangedHandler DistanceChanged;
        
        public delegate void VelocityChangedHandler(double velocity);
        public event VelocityChangedHandler VelocityChanged;

        public delegate void TimeChangedHandler(double Time);
        public event TimeChangedHandler TimeChanged;

        BindingSource bs;
        BindingList<CardioIntervalType> _intervals;
        BindingList<CardioIntervalType> intervals
        {
            get
            {
                return _intervals;
            }
            set
            {
                _intervals = value;
            }
        }


        Units units;
        CardioExersizeType _defaultCardioType;
        private Dictionary<int, bool> visibleColumns = new Dictionary<int, bool>();
        SqlCeConnection connection;
        SqlCeCommand cmd;
        public CardioExersizeType DefaultCardioType
        {
            get
            {
                return _defaultCardioType;
            }
            set
            {
               // if (value == null || value.CardioTypeId <= 0) throw new Exception("DefaultCardioType incorrect");
                _defaultCardioType = value;
            }
        }
        public CardioExersizesControl()
        {
            InitializeComponent();
        }
        private void CardioExersizesControl_Load(object sender, EventArgs e)
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

            gvMain.OnDurationChanged += new TrainingCatalog.Controls.CardioDataGridView.CustomCellValueChanged(gvMain_DurationChanged);
            gvMain.OnDistanceChanged += new TrainingCatalog.Controls.CardioDataGridView.CustomCellValueChanged(gvMain_DistanceChanged);
            gvMain.OnVelocityChanged += new TrainingCatalog.Controls.CardioDataGridView.CustomCellValueChanged(gvMain_VelocityChanged);
            bs = new BindingSource();
            intervals = new BindingList<CardioIntervalType>();
            bs.DataSource = intervals;
            gvMain.DataSource = bs;

            string o;
            o = dbBusiness.GetValue("DistanceUnit");
            if (!string.IsNullOrEmpty(o)) cbDistance.SelectedIndex = Convert.ToInt32(o);
            o = dbBusiness.GetValue("TimeUnit");
            if (!string.IsNullOrEmpty(o)) cbTime.SelectedIndex = Convert.ToInt32(o);
            o = dbBusiness.GetValue("Velocity_DistanceUnit");
            if (!string.IsNullOrEmpty(o)) cbSpeedDistance.SelectedIndex = Convert.ToInt32(o);
            o = dbBusiness.GetValue("Velocity_TimeUnit");
            if (!string.IsNullOrEmpty(o)) cbSpeedTime.SelectedIndex = Convert.ToInt32(o);
            if (ConfigurationManager.ConnectionStrings["db"] != null)
            {
                connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            }
            units = new Units((Units.DistanceUnit)cbSpeedDistance.SelectedValue,
                                (Units.TimeUnit)cbSpeedTime.SelectedValue,
                                (Units.DistanceUnit)cbDistance.SelectedValue,
                                (Units.TimeUnit)cbTime.SelectedValue);
        }
        
        private void gvMain_DistanceChanged(DataGridViewCell lastEditedCell)
        {

            double distance = Convert.ToDouble(lastEditedCell.Value);
            double velocity = Convert.ToDouble(gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Velocity].Value);
            double Time = Convert.ToDouble(gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Time].Value);
            if (distance > 0 && Utils.IsZero(velocity) && Time > 0)
            {
                velocity = Utils.RoundDouble2(units.CalcVelocity(distance, Time));
                gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Velocity].Value = velocity;
                if (VelocityChanged != null) VelocityChanged(velocity);
            }
            else if (distance > 0 && velocity > 0 && Utils.IsZero(Time))
            {
                Time = Utils.RoundDouble2(units.CalcTime(velocity, distance));
                gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Time].Value = Time;
                if (TimeChanged != null) TimeChanged(Time);
            }
            
             
        }
        private void gvMain_VelocityChanged(DataGridViewCell lastEditedCell)
        {
            double distance = Convert.ToDouble(gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Distance].Value);
            double velocity = Convert.ToDouble(lastEditedCell.Value);
            double Time = Convert.ToDouble(gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Time].Value);
            if (Utils.IsZero(distance) && velocity > 0 && Time > 0)
            {
                distance = Utils.RoundDouble2(units.CalcDistance(velocity, Time));
                gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Distance].Value = distance;
                if (DistanceChanged != null) DistanceChanged(distance);
            }
            else if (distance > 0 && velocity > 0 && Utils.IsZero(Time))
            {
                Time = Utils.RoundDouble2(units.CalcTime(velocity, distance));
                gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Time].Value = Time;
                if (TimeChanged != null) TimeChanged(Time);
            }
        }
        private void gvMain_DurationChanged(DataGridViewCell lastEditedCell)
        {
            double distance = Convert.ToDouble(gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Distance].Value);
            double velocity = Convert.ToDouble(gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Velocity].Value);
            double Time = Convert.ToDouble(lastEditedCell.Value);
            if (distance > 0 && Utils.IsZero(velocity) && Time > 0)
            {
                velocity = Utils.RoundDouble2(units.CalcVelocity(distance, Time));
                gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Velocity].Value = velocity;
                if (VelocityChanged != null) VelocityChanged(velocity);
            }
            else if (Utils.IsZero(distance) && velocity > 0 && Time > 0)
            {
                distance = Utils.RoundDouble2(units.CalcDistance(velocity, Time));
                gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Distance].Value = distance;
                if (DistanceChanged != null) DistanceChanged(distance);
            }
        }
        public void LoadCardioExersizes(IList<CardioIntervalType> input) 
        {
            try
            {
                
                intervals = new BindingList<CardioIntervalType>(units.ConvertToUnits(input));
                bs.DataSource = intervals;

                using (cmd = connection.CreateCommand())
                {
                    connection.Open();
                    if (intervals.Count > 0)
                    {
                        TrainingBusiness.GetVisibleType(cmd, ref visibleColumns,(from a in input
                                                                               group a by a.CardioTypeId into g
                                                                               select g.Key).ToList());
                    }
                    foreach (int key in visibleColumns.Keys)
                    {
                        gvMain.Columns[key].Visible = visibleColumns[key];
                    }
                }

            }
            finally
            {
                connection.Close();
            }
            
        }
        public IList<CardioIntervalType> GetCardioExersizes()
        {
            return  units.ConvertFromUnits(intervals.ToList()).Where(i => i.CardioTypeId > 0).ToList();
        }
        public void AddRow(CardioExersizeType i)
        {
            if (i == null || i.Id <= 0 || i.Name == null) return;
            MagicHook();
            intervals.Add(new CardioIntervalType()
            {
                CardioTypeId = i.Id,
                Name = i.Name
            });
            if (intervals.Count > 2)
            {
                var i1 = intervals.Last();
                var i2 = intervals[intervals.Count - 3];
                if (i1.CardioTypeId == i2.CardioTypeId)
                {
                    i1.HeartRate = i2.HeartRate;
                    i1.Distance = i2.Distance;
                    i1.Intensivity = i2.Intensivity;
                    i1.Resistance = i2.Resistance;
                    i1.Time = i2.Time;
                    i1.Velocity = i2.Velocity;
                }
            }
            try
            {
                using (cmd = connection.CreateCommand())
                {
                    connection.Open();
                    if (intervals.Count > 0)
                    {
                        List<int> a = new List<int>();
                        a.Add(i.Id);
                        TrainingBusiness.GetVisibleType(cmd, ref visibleColumns, a);
                    }
                    foreach (int key in visibleColumns.Keys)
                    {
                        gvMain.Columns[key].Visible = visibleColumns[key];
                    }
                }

            }
            finally
            {
                connection.Close();
            }
            
        }
        /// <summary>
        /// this is voodoo magic.  http://code.google.com/p/traningcatalog/issues/detail?id=31
        /// </summary>
        private void MagicHook()
        {
            if (gvMain.Rows.Count == 1)
            {
                intervals = new BindingList<CardioIntervalType>();
                bs.DataSource = intervals;
            }
        }
        public void AddRow(CardioIntervalType i)
        {
            if (i == null || i.Name == null || i.CardioTypeId == 0) return;
            MagicHook();
            List<CardioIntervalType> t = new List<CardioIntervalType>();
            t.Add(i);
            intervals.Add(units.ConvertToUnits(t)[0]);
            try
            {
                using (cmd = connection.CreateCommand())
                {
                    connection.Open();
                    if (intervals.Count > 0)
                    {
                        List<int> a = new List<int>();
                        a.Add(i.CardioTypeId);
                        TrainingBusiness.GetVisibleType(cmd, ref visibleColumns, a);
                    }
                    foreach (int key in visibleColumns.Keys)
                    {
                        gvMain.Columns[key].Visible = visibleColumns[key];
                    }
                }

            }
            finally
            {
                connection.Close();
            }

        }
        private void lstExersizes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void gvMain_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // auto adding row
            if (intervals != null && intervals.Count > 0)
            {
                CardioIntervalType i = intervals.Last();
                if (i.CardioTypeId <= 0 && DefaultCardioType != null)
                {
                    i.CardioTypeId = DefaultCardioType.Id;
                    i.Name = DefaultCardioType.Name;
                }
            }

        }
        private void gvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gvMain.BeginEdit(true);
        }

        private void gvMain_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            gvMain.BeginEdit(true);
        }

        #region UnitsChangeEvents
        //----------==========================================================================================================
        //private void cbSpeedDistance_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    LastSpeedDistance = (DistanceUnit)cbSpeedDistance.SelectedValue;
           
        //}
        //private void cbTime_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    LastTime = (TimeUnit)cbTime.SelectedValue;
        //}
        //private void cbDistance_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    LastDistance = (DistanceUnit)cbDistance.SelectedValue;
        //}
        //private void cbSpeedTime_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    LastSpeedTime = (TimeUnit)cbSpeedTime.SelectedValue;
        //}

        //----------------------------------------------------------------------------------------------------------------------
        private void cbDistance_SelectionChangeCommitted(object sender, EventArgs e)
        {

            Units.DistanceUnit current = (Units.DistanceUnit)cbDistance.SelectedValue;
            units.DistanceChanged(current, intervals);
            bs.ResetBindings(false);
            dbBusiness.SaveValue("DistanceUnit", Convert.ToString((int)current));
        }
        private void cbTime_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Units.TimeUnit current = (Units.TimeUnit)cbTime.SelectedValue;
            units.TimeChanged(current, intervals);
            bs.ResetBindings(false);
            dbBusiness.SaveValue("TimeUnit", Convert.ToString((int)current));
        }
        private void cbSpeedDistance_SelectionChangeCommitted(object sender, EventArgs e)
        {

            Units.DistanceUnit current = (Units.DistanceUnit)cbSpeedDistance.SelectedValue;
            units.SpeedDistanceChanged(current, intervals);
            bs.ResetBindings(false);
            dbBusiness.SaveValue("Velocity_DistanceUnit", Convert.ToString((int)current));
            
        }
        private void cbSpeedTime_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Units.TimeUnit current = (Units.TimeUnit)cbSpeedTime.SelectedValue;
            units.SpeedTimeChanged(current, intervals);
            bs.ResetBindings(false);
            dbBusiness.SaveValue("Velocity_TimeUnit", Convert.ToString((int)current));
        }
        //==========================================================================================================================
        #endregion

        #region BusinessLogic

        #endregion

        private void gvMain_DataSourceChanged(object sender, EventArgs e)
        {

        }

        private void gvMain_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
           
            
        }

        private void gvMain_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void gvMain_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            //if (gvMain.Rows.Count == 2) // this is voodoo magic.  http://code.google.com/p/traningcatalog/issues/detail?id=31
            //{
            //    intervals = new BindingList<CardioIntervalType>();
            //    bs.DataSource = intervals;
            //}
             
        }

        private void gvMain_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
          
        }

        private void gpSettings_Enter(object sender, EventArgs e)
        {

        }

    }
}
