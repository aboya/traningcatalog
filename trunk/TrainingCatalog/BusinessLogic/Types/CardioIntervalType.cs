using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingCatalog.BusinessLogic.Types
{
    public class CardioIntervalType
    {
        public int Id;
        public int CardioTypeId;
        public string Name { get; set; }
        public double Velocity { get; set; }
        public double Time { get; set; }
        public double Distance { get; set; }
        public double Intensivity { get; set; }
        public double Resistance { get; set; }
        public double HeartRate { get; set; }
    }
}
