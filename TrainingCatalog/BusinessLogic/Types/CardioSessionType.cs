﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingCatalog.BusinessLogic.Types
{
    public class CardioSessionType
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public DateTime Date { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public string Name
        {
            get
            {
                return string.Format("{0:00}:{1:00}", StartTime / 60, StartTime % 60);
            }
        }
        public static bool operator >(CardioSessionType x, CardioSessionType y)
        {

            return x.Id > y.Id;
        }
        public static bool operator <(CardioSessionType x, CardioSessionType y)
        {
            return x.Id < y.Id;
        }
    }
}
