using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingCatalog.BusinessLogic.Types
{
    public class ReportDayTypeHtml : BaseReportDay
    {
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("<table>");
            int i, n, j, m;
            string[,] table = GetTable();
            n = table.GetLength(0);
            m = table.GetLength(1);
            for (i = 0; i < n; i++)
            {
                result.Append("<tr>");
                for (j = 0; j < m; j++)
                {
                    result.Append("<td>");
                    result.Append(table[i, j]);
                    result.Append("</td>");
                }
                result.Append("</tr>");
            }
            result.Append("</table>");
            return result.ToString();
            
        }
        
    }
}
