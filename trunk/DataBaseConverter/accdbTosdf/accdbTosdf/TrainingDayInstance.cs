using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace accdbTosdf
{
    public class TrainingDayInstance
    {
        public DateTime day;
        public List<ExersizeInstance> exersizes;
        public static bool operator ==(TrainingDayInstance a, TrainingDayInstance b)
        {
            if (a.day != b.day) return false;

            int n = a.exersizes.Count;
            if (n != b.exersizes.Count) return false;
            a.exersizes.Sort();
            for (int i = 0; i < n; i++)
            {
                if (a.exersizes[i] != b.exersizes[i]) return false;
            }
            return true; 
        }

        public static bool operator !=(TrainingDayInstance a, TrainingDayInstance b)
        {
            
            return !(a == b);
        }
        public override bool Equals(object obj)
        {
            if (obj is TrainingDayInstance) return (TrainingDayInstance)obj == this;
            return false;
        }
    }
  

}
