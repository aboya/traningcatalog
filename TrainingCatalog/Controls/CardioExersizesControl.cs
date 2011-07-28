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
        BindingList<CardioIntervalType> intervals;
        DistanceUnit LastSpeedDistance;
        TimeUnit LastSpeedTime ;
        DistanceUnit LastDistance;
        TimeUnit LastTime;
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

            cbDistance.DataSource = DistanceDataSource.Create();
            cbTime.DataSource = TimeDataSource.Create();
            cbSpeedDistance.DataSource = DistanceDataSource.Create();
            cbSpeedTime.DataSource = TimeDataSource.Create();

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
            
        }
        
        private void gvMain_DistanceChanged(DataGridViewCell lastEditedCell)
        {

            double distance = Convert.ToDouble(lastEditedCell.Value);
            double velocity = Convert.ToDouble(gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Velocity].Value);
            double Time = Convert.ToDouble(gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Time].Value);
            if (distance > 0 && Utils.IsZero(velocity) && Time > 0)
            {
                velocity = Utils.RoundDouble2(CalcVelocity(distance, Time));
                gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Velocity].Value = velocity;
                if (VelocityChanged != null) VelocityChanged(velocity);
            }
            else if (distance > 0 && velocity > 0 && Utils.IsZero(Time))
            {
                Time =  Utils.RoundDouble2(CalcTime(velocity, distance));
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
                distance = Utils.RoundDouble2(CalcDistance(velocity, Time));
                gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Distance].Value = distance;
                if (DistanceChanged != null) DistanceChanged(distance);
            }
            else if (distance > 0 && velocity > 0 && Utils.IsZero(Time))
            {
                Time = Utils.RoundDouble2(CalcTime(velocity, distance));
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
                velocity = Utils.RoundDouble2(CalcVelocity(distance, Time));
                gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Velocity].Value = velocity;
                if (VelocityChanged != null) VelocityChanged(velocity);
            }
            else if (Utils.IsZero(distance) && velocity > 0 && Time > 0)
            {
                distance = Utils.RoundDouble2(CalcDistance(velocity, Time));
                gvMain.Rows[lastEditedCell.RowIndex].Cells[CardioGridEnum.Distance].Value = distance;
                if (DistanceChanged != null) DistanceChanged(distance);
            }
        }
        public void LoadCardioExersizes(IList<CardioIntervalType> input) 
        {
            try
            {
                intervals = new BindingList<CardioIntervalType>(ConvertToUnits(input));
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
            return ConvertFromUnits(intervals.ToList()).Where(i => i.CardioTypeId > 0).ToList();
        }
        public void AddRow(CardioExersizeType i)
        {
            if (i == null || i.Id <= 0 || i.Name == null) return;
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
        public void AddRow(CardioIntervalType i)
        {
            if (i == null || i.Name == null || i.CardioTypeId == 0) return;
            List<CardioIntervalType> t = new List<CardioIntervalType>();
            t.Add(i);
            intervals.Add(ConvertToUnits(t)[0]);
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
        private void cbSpeedDistance_SelectedIndexChanged(object sender, EventArgs e)
        {
            LastSpeedDistance = (DistanceUnit)cbSpeedDistance.SelectedValue;
           
        }
        private void cbTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            LastTime = (TimeUnit)cbTime.SelectedValue;
        }
        private void cbDistance_SelectedIndexChanged(object sender, EventArgs e)
        {
            LastDistance = (DistanceUnit)cbDistance.SelectedValue;
        }
        private void cbSpeedTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            LastSpeedTime = (TimeUnit)cbSpeedTime.SelectedValue;
        }

        //----------------------------------------------------------------------------------------------------------------------
        private void cbDistance_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DistanceUnit current = (DistanceUnit)cbDistance.SelectedValue;
            double s = GetDistanceKoefficient(LastDistance, current);
            DoConvert(intervals, s, 1, 1);
            bs.ResetBindings(false);
            dbBusiness.SaveValue("DistanceUnit", Convert.ToString((int)current));
        }
        private void cbTime_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TimeUnit current = (TimeUnit)cbTime.SelectedValue;
            double t = GetTimeKoefficient(LastTime, current);
            DoConvert(intervals, 1, 1, t);
            bs.ResetBindings(false);
            dbBusiness.SaveValue("TimeUnit", Convert.ToString((int)current));
        }
        private void cbSpeedDistance_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            DistanceUnit current = (DistanceUnit)cbSpeedDistance.SelectedValue;
            double v = GetDistanceKoefficient(LastSpeedDistance, current);
            DoConvert(intervals, 1, v, 1);
            bs.ResetBindings(false);
            dbBusiness.SaveValue("Velocity_DistanceUnit", Convert.ToString((int)current));
            
        }
        private void cbSpeedTime_SelectionChangeCommitted(object sender, EventArgs e)
        {
            TimeUnit current = (TimeUnit)cbSpeedTime.SelectedValue;
            double v = 1.0 / GetTimeKoefficient(LastSpeedTime, current);
            DoConvert(intervals, 1, v, 1);
            bs.ResetBindings(false);
            dbBusiness.SaveValue("Velocity_TimeUnit", Convert.ToString((int)current));
        }
        //==========================================================================================================================
        #endregion

        #region BusinessLogic
        private static double GetTimeKoefficient(TimeUnit From, TimeUnit To)
        {
            double t = 1;
            if (From == TimeUnit.Hour)
            {
                t = 3600;
            }
            else if (From == TimeUnit.Minute)
            {
                t = 60;
            }

            if (To == TimeUnit.Minute)
            {
                t /= 60.0;
            }
            else if (To == TimeUnit.Hour)
            {
                t /= 3600.0;
            }
            return t;
        }
        private static double GetDistanceKoefficient(DistanceUnit From, DistanceUnit To)
        {
            double s = 1.0;
            if (From == DistanceUnit.Kilometrs)
            {
                s = 1000.0;
            }

            if (To == DistanceUnit.Kilometrs)
            {
                s /= 1000.0;
            }
            return s;
        }
        public enum TimeUnit
        {
            Second,
            Minute,
            Hour
        }
        public enum DistanceUnit
        {
            Meters,
            Kilometrs
        }
        public class DistanceDataSource
        {
            public DistanceUnit Type { get; set; }
            public string Name { get; set; }
            public static List<DistanceDataSource> Create()
            {
                List<DistanceDataSource> res = new List<DistanceDataSource>();
                res.Add(new DistanceDataSource()
                {
                    Type = DistanceUnit.Meters,
                    Name = "M"
                });
                res.Add(new DistanceDataSource()
                {
                    Type = DistanceUnit.Kilometrs,
                    Name = "Km"
                });
                return res;
            }

        }
        public class TimeDataSource
        {
            public TimeUnit Type { get; set; }
            public string Name { get; set; }
            public static List<TimeDataSource> Create()
            {
                List<TimeDataSource> res = new List<TimeDataSource>();
                res.Add(new TimeDataSource()
                {
                    Type = TimeUnit.Second,
                    Name = "Sec"
                });
                res.Add(new TimeDataSource()
                {
                    Type = TimeUnit.Minute,
                    Name = "Min"
                });
                res.Add(new TimeDataSource()
                {
                    Type = TimeUnit.Hour,
                    Name = "Hour"
                });
                return res;
            }
        }
        /// <summary>
        /// Convert from Input in (sec,metrs) to units selected
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public IList<CardioIntervalType> ConvertToUnits(IList<CardioIntervalType> input)
        {
            DistanceUnit speedDistance = (DistanceUnit)cbSpeedDistance.SelectedValue;
            TimeUnit speedTime = (TimeUnit)cbSpeedTime.SelectedValue;
            DistanceUnit distance = (DistanceUnit)cbDistance.SelectedValue;
            TimeUnit time = (TimeUnit)cbTime.SelectedValue;
            double s = 1, v = 1, t = 1;
            // ConvertSpeed
            if (speedTime == TimeUnit.Minute)
            {
                v = 60;
            }
            else if (speedTime == TimeUnit.Hour)
            {
                v = 3600;
            }
            if (speedDistance == DistanceUnit.Kilometrs)
            {
                v /= 1000.0;
            }
            // Convert Time
            if (time == TimeUnit.Minute)
            {
                t /= 60.0;
            }
            else if (time == TimeUnit.Hour)
            {
                t /= 3600.0;
            }

            // Convert Distance 
            if (distance == DistanceUnit.Kilometrs)
            {
                s /= 1000.0;
            }
            return DoConvert(input, s, v, t);
        }
        /// <summary>
        /// Convert input from units into (sec, metrs)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private IList<CardioIntervalType> ConvertFromUnits(IList<CardioIntervalType> input)
        {
            DistanceUnit speedDistance = (DistanceUnit)cbSpeedDistance.SelectedValue;
            TimeUnit speedTime = (TimeUnit)cbSpeedTime.SelectedValue;
            DistanceUnit distance = (DistanceUnit)cbDistance.SelectedValue;
            TimeUnit time = (TimeUnit)cbTime.SelectedValue;
            double s = 1, v = 1, t = 1;
            // ConvertSpeed
            if (speedDistance == DistanceUnit.Kilometrs)
            {
                v = 1000.0;
            }
            if (speedTime == TimeUnit.Minute)
            {
                v /= 60;
            }
            else if (speedTime == TimeUnit.Hour)
            {
                v /= 3600;
            }

            // Convert Time
            if (time == TimeUnit.Minute)
            {
                t = 60.0;
            }
            else if (time == TimeUnit.Hour)
            {
                t = 3600.0;
            }

            // Convert Distance 
            if (distance == DistanceUnit.Kilometrs)
            {
                s = 1000.0;
            }
            return DoConvert(input, s, v, t);

        }
        private static IList<CardioIntervalType> DoConvert(IList<CardioIntervalType> input, double s, double v, double t)
        {
            foreach (CardioIntervalType i in input)
            {
                i.Distance = Utils.RoundDouble2(i.Distance * s);
                i.Time = Utils.RoundDouble2(i.Time * t);
                i.Velocity = Utils.RoundDouble2(i.Velocity * v);
            }
            return input;

        }
        private double CalcVelocity(double s, double t)
        {
            double sk = GetDistanceKoefficient((DistanceUnit)cbDistance.SelectedValue, (DistanceUnit)cbSpeedDistance.SelectedValue);
            double tk = GetTimeKoefficient((TimeUnit)cbTime.SelectedValue, (TimeUnit)cbSpeedTime.SelectedValue);
            return (s * sk) / (t * tk);
        }
        private double CalcTime(double v, double s)
        {
            double sk = GetDistanceKoefficient((DistanceUnit)cbDistance.SelectedValue, (DistanceUnit)cbSpeedDistance.SelectedValue);
            double tk = GetTimeKoefficient((TimeUnit)cbSpeedTime.SelectedValue, (TimeUnit)cbTime.SelectedValue);
            return s * sk * tk / v;
        }
        private double CalcDistance(double v, double t)
        {
            double sk = GetDistanceKoefficient((DistanceUnit)cbSpeedDistance.SelectedValue, (DistanceUnit)cbDistance.SelectedValue);
            double tk = GetTimeKoefficient((TimeUnit)cbSpeedTime.SelectedValue, (TimeUnit)cbTime.SelectedValue);
            return v * t * sk / tk;

        }
        #endregion

        private void gvMain_DataSourceChanged(object sender, EventArgs e)
        {

        }

    }
}
