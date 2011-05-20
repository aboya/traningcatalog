using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingCatalog.BusinessLogic
{
    public class Utils
    {
        public static double RoundDouble2(double a)
        {
            return a;
            //return Convert.ToDouble(a.ToString("0.00"));
        }
        public static bool IsZero(double a)
        {
            
            return Math.Abs(a) < 0.0001; 
        }
    }
}
