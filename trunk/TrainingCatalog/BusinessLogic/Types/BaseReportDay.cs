using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Configuration;
using System.IO;

namespace TrainingCatalog.BusinessLogic.Types
{
    public class BaseReportDay
    {
       public  List<ReportExersizeType> exersizes;
       public double bodyWeight;
       public DateTime date;
       public delegate void ProcessIndicator(int completed);
       public event ProcessIndicator ProcessIndicatorEvent;
       protected Dictionary<int, int> LastMaximumExersizeWeight;
       protected int[] ProgressTable;
       string fileName;
       DateTime start;
       DateTime end;
        
        public BaseReportDay(string _fileName, DateTime _start, DateTime _end)
       {
           fileName = _fileName;
           start = _start;
           end = _end;
       }
       protected string[,] GetTable()
       {

           Dictionary<int, int> LineForExersize = new Dictionary<int, int>();
           Dictionary<int, int> ExersizeForLine = new Dictionary<int, int>();
           int avaibleLine = 0;
           foreach (ReportExersizeType e in exersizes)
           {
               if (!LineForExersize.ContainsKey(e.Id))
               {
                   ExersizeForLine[++avaibleLine] = e.Id;
                   LineForExersize[e.Id] = avaibleLine;
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

           //заполняем таблицу прогресса. Если 0 - прогреса нету, +1 есть, -1 регресс
           ProgressTable = new int[LineForExersize.Count+1];
           ProgressTable[0] = 0;
           for (int i = 1; i <= LineForExersize.Count; i++)
           {
               ProgressTable[i] = 0;

               int ExersizeId = ExersizeForLine[i];
               int LastWeight;
               LastMaximumExersizeWeight.TryGetValue(ExersizeId, out LastWeight);
               int MaxCurrentDay = (from e in exersizes
                                    where e.Id == ExersizeId
                                    select e.weight).Max();
               if (LastWeight > MaxCurrentDay) ProgressTable[i] = -1;
               else if (LastWeight < MaxCurrentDay) ProgressTable[i] = 1;

           }
           return resulst;
       }
       public void Add(ReportExersizeType exersizeItem)
       {
           exersizes.Add(exersizeItem);
       }
       protected virtual string GenerateHeader()
       {
           return string.Empty;
       }
       protected virtual string GenerateFooter()
       {
           return string.Empty;
       }
       public void GenerateReport()
       {
           using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.Default))
           {
               using (SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
               {
                   connection.Open();
                   using (SqlCeCommand command = new SqlCeCommand())
                   {
                       command.Connection = connection;
                       command.Parameters.Add("@start", System.Data.SqlDbType.DateTime).Value = start.Date;
                       command.Parameters.Add("@end", System.Data.SqlDbType.DateTime).Value = end.Date;
                       command.CommandText = @"select count(Day) from Training " +
                                               "where Day between @start and  @end ";

                       int total = Convert.ToInt32(command.ExecuteScalar());
                       int current = 0;
                       command.CommandText =
                                     "select Day,Weight,Count,BodyWeight,Exersize.ShortName, Exersize.ID as ExersizeID from (( Link " +
                                     "inner join Training on Training.ID = Link.TrainingID) " +
                                     "inner join Exersize on Exersize.ID = Link.ExersizeID ) " +
                                     "where  " +
                                     "Day between @start and  @end " +
                                     "order by Day asc";
                       sw.WriteLine(GenerateHeader());
                       using (SqlCeDataReader dr = command.ExecuteReader())
                       {
                           DateTime lastDate = DateTime.MinValue;
                           DateTime currentDate = DateTime.MinValue;
                           //хранит максимальный вес предыдущего упражения
                            LastMaximumExersizeWeight = new Dictionary<int, int>();
                           while (dr.Read())
                           {
                               currentDate = Convert.ToDateTime(dr["Day"]);
               
                               if (currentDate != lastDate)
                               {
                                   lastDate = currentDate;
                                   if (exersizes != null)
                                   {
                                       sw.WriteLine(this.ToString());
                                       if (ProcessIndicatorEvent != null)
                                       {
                                           ProcessIndicatorEvent(current * 100 / total);
                                       }
                                       current++;

                                       //сохраняем максимальный вес упражения за день
                                       
                                       //1. Очищаем список - убираем те упражнения которые использовались за текущий день, что бы они не влияли на результат максимума
                                       foreach (var e in exersizes)
                                       {
                                           LastMaximumExersizeWeight[e.Id] = 0;
                                       }

                                       //2. Заливаем максимальный вес по каждому упражнению
                                       foreach (var e in exersizes)
                                       {
                                           if (e.weight > LastMaximumExersizeWeight[e.Id]) LastMaximumExersizeWeight[e.Id] = e.weight;
                                       }

                                       System.Windows.Forms.Application.DoEvents();
                                   }
                                   if (dr["BodyWeight"] is DBNull) bodyWeight = 0;
                                   else bodyWeight = Convert.ToDouble(dr["BodyWeight"]);
                                   exersizes = new List<ReportExersizeType>();
                                   date = currentDate;
                                   
                               }
                               ReportExersizeType exersize = new ReportExersizeType(Convert.ToInt32(dr["ExersizeID"]), Convert.ToString(dr["ShortName"]), Convert.ToInt32(dr["Count"]), Convert.ToInt32(dr["Weight"]));
                               this.Add(exersize);
                           }
                           sw.WriteLine(this.ToString());
                       }
                       sw.WriteLine(GenerateFooter());
                   }
               }
           }
       }

    }
}
