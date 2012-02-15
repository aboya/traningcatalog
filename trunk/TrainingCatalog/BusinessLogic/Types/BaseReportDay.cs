using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingCatalog.BusinessLogic.Types
{
    public class BaseReportDay
    {
       public  List<ReportExersizeType> exersizes;
       public double bodyWeight;
       public DateTime date;
       protected string[,] GetTable()
       {

           Dictionary<int, int> LineForExersize = new Dictionary<int, int>();
           int avaibleLine = 0;
           foreach (ReportExersizeType e in exersizes)
           {
               if (!LineForExersize.ContainsKey(e.Id))
               {
                   LineForExersize[e.Id] = ++avaibleLine;

               }
           }
           string[,] resulst = new string[LineForExersize.Count + 1, 2];
           foreach (ReportExersizeType e in exersizes)
           {
               int row = LineForExersize[e.Id];
               resulst[row, 1] += string.Format("{0}({1})x", e.weight, e.count);
               resulst[row, 0] = e.Name;
           }
           for (int i = 1, n = resulst.GetLength(0); i < n; i++)
           {
               resulst[i, 1] = resulst[i, 1].Remove(resulst[i, 1].Length - 1);
           }
           resulst[0, 0] = string.Format("Дата:{0} ({1})", date.ToString("dd/MM/yyyy"), date.DayOfWeek);
           resulst[0, 1] = "Вес:" + bodyWeight.ToString(); ;
           return resulst;
       }
    }
}
