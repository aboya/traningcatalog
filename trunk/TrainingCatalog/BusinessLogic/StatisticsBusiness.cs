using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using TimeHighway.BusinessLogic.Common.Types;

namespace TrainingCatalog.BusinessLogic
{
    public class StatisticsBusiness
    {
        // прибавка в массе
        public static List< pair<DateTime,double > > MassAdded(SqlCeConnection connection, DateTime start, DateTime end)
        {
            List<pair<DateTime, double> > res = new List<pair<DateTime, double>>();
            try
            {
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = "select BodyWeight,Day from Training where BodyWeight is not null and BodyWeight > 0";
                    using (SqlCeDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            res.Add(new pair<DateTime, double>(Convert.ToDateTime(reader["Day"]), Convert.ToDouble(reader["BodyWeight"])));
                        }
                    }
                }
            }
            finally
            {
                connection.Close();
            }
            return res;
 
        }
      //  Количество работы за день
        public static List<pair<DateTime,int> > TotalWorkOfDay(SqlCeConnection connection, DateTime start, DateTime end)
        {
            List<pair<DateTime, int>> res = new List<pair<DateTime, int>>();
            try
            {
                 connection.Open();
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "select Day, sum(Weight * count) from Training join Link on Training.Id = Link.TrainingId group by Day";
                }
            }
            finally
            {
                connection.Close();
            }
            return res;
        }
        //3) Средняя прибавка массы

        public static double AverageMassAdded(SqlCeConnection connection, DateTime start, DateTime end)
        {
            try
            {
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
            return 0;
        }
        //4) Средняя прибавка работы за день
        public static double AverageWorkAdded(SqlCeConnection connection, DateTime start, DateTime end)
        {
            try
            {
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
            return 0;
        }
        //6) прибавка в максимальных весах

        public static List<double> AverageMaxWeightForDay(SqlCeConnection connection, DateTime start, DateTime end)
        {
            try
            {
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
            return new List<double>();
        }
        //6) Средняя прибавка в максимальных весах
        public static double AverageMaxWeight(SqlCeConnection connection, DateTime start, DateTime end)
        {
            try
            {
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                connection.Close();
            }
            return 0;
        }

    }
}
