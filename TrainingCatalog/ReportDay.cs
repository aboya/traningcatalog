using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingCatalog
{
    public class ReportDay
    {
        private static string Delimetr = ";";
        List<ReportExersize> exersizes;
        double bodyWeight;
        DateTime date;
        public ReportDay(DateTime _date, double _bodyWeight)
        {
            date = _date;
            bodyWeight = _bodyWeight;
            exersizes = new List<ReportExersize>();
        }
        public void Add(ReportExersize exersizeItem)
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
        private string[,] GetTable()
        {
            
            Dictionary <int, int> LineForExersize = new Dictionary<int,int>();
            int avaibleLine = 0;
            foreach(ReportExersize e in exersizes)
            {
                if(!LineForExersize.ContainsKey(e.Id))
                {
                   LineForExersize[e.Id] = ++avaibleLine;
                  
                }
            }
            string [,] resulst = new string[LineForExersize.Count + 1, 2];
            foreach(ReportExersize e in exersizes)
            {
                int row = LineForExersize[e.Id];
                resulst[row, 1] += string.Format("{0}({1})x", e.weight, e.count);
                resulst[row, 0] = e.Name;
            }
            for(int i = 1, n = resulst.GetLength(0); i < n; i++)
            {
                resulst[i, 1] =  resulst[i,1].Remove(resulst[i,1].Length - 1);
            }
            resulst[0,0] = "Дата:" + date.ToString("dd/MM/yyyy");
            resulst[0,1] = "Вес:" + bodyWeight.ToString();;
            return resulst;
        }

    }
}
    
