using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingCatalog.BusinessLogic.Types;

namespace TrainingCatalog.BusinessLogic
{
    public class Units
    {
        DistanceUnit SpeedDistance;
        TimeUnit SpeedTime;
        DistanceUnit Distance;
        TimeUnit Time;
        public Units(DistanceUnit speedDistance, TimeUnit speedTime, DistanceUnit distance, TimeUnit time)
        {
            this.SpeedDistance = speedDistance;
            this.SpeedTime = speedTime;
            this.Distance = distance;
            this.Time = time;
        }
        public static double GetTimeKoefficient(TimeUnit From, TimeUnit To)
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
        public static double GetDistanceKoefficient(DistanceUnit From, DistanceUnit To)
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
            //DistanceUnit speedDistance = (DistanceUnit)cbSpeedDistance.SelectedValue;
            //TimeUnit speedTime = (TimeUnit)cbSpeedTime.SelectedValue;
            //DistanceUnit distance = (DistanceUnit)cbDistance.SelectedValue;
            //TimeUnit time = (TimeUnit)cbTime.SelectedValue;
            double s = 1, v = 1, t = 1;
            // ConvertSpeed
            if (SpeedTime == TimeUnit.Minute)
            {
                v = 60;
            }
            else if (SpeedTime == TimeUnit.Hour)
            {
                v = 3600;
            }
            if (SpeedDistance == DistanceUnit.Kilometrs)
            {
                v /= 1000.0;
            }
            // Convert Time
            if (Time == TimeUnit.Minute)
            {
                t /= 60.0;
            }
            else if (Time == TimeUnit.Hour)
            {
                t /= 3600.0;
            }

            // Convert Distance 
            if (Distance == DistanceUnit.Kilometrs)
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
        public IList<CardioIntervalType> ConvertFromUnits(IList<CardioIntervalType> input)
        {
            //DistanceUnit speedDistance = (DistanceUnit)cbSpeedDistance.SelectedValue;
            //TimeUnit speedTime = (TimeUnit)cbSpeedTime.SelectedValue;
            //DistanceUnit distance = (DistanceUnit)cbDistance.SelectedValue;
            //TimeUnit time = (TimeUnit)cbTime.SelectedValue;
            double s = 1, v = 1, t = 1;
            // ConvertSpeed
            if (SpeedDistance == DistanceUnit.Kilometrs)
            {
                v = 1000.0;
            }
            if (SpeedTime == TimeUnit.Minute)
            {
                v /= 60;
            }
            else if (SpeedTime == TimeUnit.Hour)
            {
                v /= 3600;
            }

            // Convert Time
            if (Time == TimeUnit.Minute)
            {
                t = 60.0;
            }
            else if (Time == TimeUnit.Hour)
            {
                t = 3600.0;
            }

            // Convert Distance 
            if (Distance == DistanceUnit.Kilometrs)
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
        public double CalcVelocity(double s, double t)
        {
            double sk = GetDistanceKoefficient(Distance, SpeedDistance);
            double tk = GetTimeKoefficient(Time, SpeedTime);
            return (s * sk) / (t * tk);
        }
        public double CalcTime(double v, double s)
        {
            double sk = GetDistanceKoefficient(Distance, SpeedDistance);
            double tk = GetTimeKoefficient(SpeedTime, Time);
            return s * sk * tk / v;
        }
        public double CalcDistance(double v, double t)
        {
            double sk = GetDistanceKoefficient(SpeedDistance, Distance);
            double tk = GetTimeKoefficient(SpeedTime, Time);
            return v * t * sk / tk;

        }

        public IList<CardioIntervalType> DistanceChanged(DistanceUnit newDistance, IList<CardioIntervalType> input)
        {
            double s = GetDistanceKoefficient(this.Distance, newDistance);
            this.Distance = newDistance;
            return DoConvert(input, s, 1, 1);
        }
        public IList<CardioIntervalType> TimeChanged(TimeUnit newTime, IList<CardioIntervalType> input)
        {
            double t = GetTimeKoefficient(this.Time, newTime);
            this.Time = newTime;
            return DoConvert(input, 1, 1, t);
        }
        public IList<CardioIntervalType> SpeedDistanceChanged(DistanceUnit newSpeedDistance, IList<CardioIntervalType> input)
        {
            double v = GetDistanceKoefficient(this.SpeedDistance, newSpeedDistance);
            this.SpeedDistance = newSpeedDistance;
            return DoConvert(input, 1, v, 1);
        }
        public IList<CardioIntervalType> SpeedTimeChanged(TimeUnit newSpeedTime, IList<CardioIntervalType> input)
        {
            double v = 1.0 / GetTimeKoefficient(this.SpeedTime, newSpeedTime);
            this.SpeedTime = newSpeedTime;
            return DoConvert(input, 1, v, 1);
        }
    }
}
