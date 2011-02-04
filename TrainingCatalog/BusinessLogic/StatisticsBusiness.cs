using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;

namespace TrainingCatalog.BusinessLogic
{
    public class StatisticsBusiness
    {
        // прибавка в массе
        public static List<double> MassAdded(SqlCeConnection connection, DateTime start, DateTime end)
        {
            List<double> res = new List<double>();
            try
            {
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = "select BodyWeight,Day from Training where BodyWeight is not null and BodyWeight > 0";
                    using (SqlCeDataReader reader = cmd.ExecuteReader())
                    { 
                    }

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
            return res;
 
        }
      //  Количество работы за день
        public static List<int> TotalWorkOfDay(SqlCeConnection connection, DateTime start, DateTime end)
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
            return new List<int>();
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
