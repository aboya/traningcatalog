﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainingCatalog.BusinessLogic.Types;

namespace TrainingCatalog
{
    public class ReportDayType : BaseReportDay
    {
        private static string Delimetr = ";";

        public ReportDayType(DateTime _date, double _bodyWeight)
        {
            date = _date;
            bodyWeight = _bodyWeight;
            exersizes = new List<ReportExersizeType>();
        }
        public void Add(ReportExersizeType exersizeItem)
        {
            exersizes.Add(exersizeItem);
        }
        public override string ToString()
        {
            string result = string.Empty;
            int i, n, j,m;
            string[,] table = GetTable();
            n = table.GetLength(0);
            m = table.GetLength(1);
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m - 1; j++)
                {
                    result += string.Format("\"{0}\"{1}", table[i, j], Delimetr);
                }

                result += string.Format("\"{0}\"" + Environment.NewLine , table[i, j]);
            }
            return result;
        }


    }
}
    
