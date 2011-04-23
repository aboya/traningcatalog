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
            return Convert.ToDouble(a.ToString("0.00"));
        }
    }
}
