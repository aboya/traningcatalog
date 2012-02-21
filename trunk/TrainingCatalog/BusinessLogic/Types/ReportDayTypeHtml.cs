using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingCatalog.BusinessLogic.Types
{
    public class ReportHtml : BaseReportDay
    {
        public ReportHtml(string _fileName, DateTime _start, DateTime _end)
            : base(_fileName, _start, _end)
        {
 
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            int i, n, j, m;
            string[,] table = GetTable();
            n = table.GetLength(0);
            m = table.GetLength(1);
            
            for (i = 0; i < n; i++)
            {
                result.AppendFormat("<tr style=\"{0}\">",GetColumnStyle());
                for (j = 0; j < m; j++)
                {
                    result.AppendFormat("<td style=\"{0}\">",GetCellStyle());
                    result.Append(table[i, j]);
                    result.Append("</td>");
                }
                result.Append("</tr>");
            }
            result.AppendFormat("<tr><td colspan=\"{0}\"> <hr> </td></tr>", m);

            
           
            return result.ToString();
        }
        private string GetColumnStyle()
        {
            return @"
                width:100px;

";
        }
        private string GetCellStyle()
        {
            return @" 
               ";
        }
        private string GetTableBorderStyle()
        {
            return @"
            border: 1px outset gray;
            border-collapse: separate;
            border-spacing: 2px;
            background-color: white;
            border-image: initial;
            border-width: 1px;
            border-color: gray;
            border-style: outset;
            border-bottim: none;
";
        }
        protected override string GenerateHeader()
        {
            StringBuilder result = new StringBuilder();
            result.Append("<html>");
            result.Append("<body>");

            result.AppendFormat("<table style=\"{0}\">", GetTableBorderStyle());
            return result.ToString();
        }
        protected override string GenerateFooter()
        {
            StringBuilder result = new StringBuilder();
            result.Append("</table>");
            result.Append("</body>");
            result.Append("</html>");
            return result.ToString();
        }
        
    }
}
