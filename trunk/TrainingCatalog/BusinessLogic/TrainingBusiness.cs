using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using TrainingCatalog.BusinessLogic.Types;

namespace TrainingCatalog.BusinessLogic
{
    public class TrainingBusiness
    {
        public static int GetTrainingDayId(DateTime date, SqlCeCommand cmd)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "select ID from Training where Day = @date";
            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = date.Date;

            object o = cmd.ExecuteScalar();
            if (o == null || o is DBNull)
            {
                cmd.Parameters.Clear();
                // создаем новый тренировочный день
                cmd.CommandText = "insert into Training (Day, Comment, BodyWeight) values(@date,@comment, @bodyWeight)";
                cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = date.Date;
                cmd.Parameters.Add("@comment", SqlDbType.NVarChar).Value = string.Empty;
                cmd.Parameters.Add("@bodyWeight", SqlDbType.Float).Value = 0;
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.CommandText = "Select @@Identity";
                o = cmd.ExecuteScalar();
            }
            cmd.Parameters.Clear();
            return Convert.ToInt32(o);
        }

        public static void AddExersize(SqlCeCommand cmd, int TrainingId, int ExersizeId, int weight, int count)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = String.Format("insert into Link (TrainingId, ExersizeId, Weight,[Count]) values({0},{1},{2},{3})", TrainingId, ExersizeId, weight, count);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }


        public static void SaveComments(SqlCeCommand cmd, DateTime dateTime, string p)
        {
            cmd.Parameters.Clear();
            int dayId = GetTrainingDayId(dateTime, cmd);
            cmd.Parameters.Clear();
            cmd.CommandText = "update Training set Comment = @comment where Id = @id";
            cmd.Parameters.Add("@comment", SqlDbType.NVarChar).Value = p;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = dayId;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public static string GetComment(SqlCeCommand cmd, DateTime dateTime)
        {
            string comment;
            cmd.Parameters.Clear();
            cmd.CommandText = "select Comment from Training where Day = @day";
            cmd.Parameters.Add("@day", SqlDbType.DateTime).Value = dateTime;
            comment = Convert.ToString(cmd.ExecuteScalar());
            cmd.Parameters.Clear();
            return comment;
        }
        public static DateTime GetStartTrainingDay(SqlCeCommand cmd)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "select min(Day) from Training";
            object o = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            if (o is DBNull) return DateTime.MinValue;
            return Convert.ToDateTime(o);
        }
        public static DateTime GetEndTrainingDay(SqlCeCommand cmd)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "select max(Day) from Training";
            object o = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            if (o is DBNull) return DateTime.Today;
            return Convert.ToDateTime(o);
        }
        public static List<DateTime> GetTrainingDays(SqlCeCommand cmd, DateTime start, DateTime end)
        {
            List<DateTime> res = new List<DateTime>();
            cmd.Parameters.Clear();
            cmd.CommandText = "select Day from Training where Day Between @start and @end";
            cmd.Parameters.Add("@start", SqlDbType.DateTime).Value = start;
            cmd.Parameters.Add("@end", SqlDbType.DateTime).Value = end;
            using (SqlCeDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    res.Add(Convert.ToDateTime(reader["Day"]));
                }
            }
            cmd.Parameters.Clear();
            return res;
        }
        public static List<DateTime> GetCommentDays(SqlCeCommand cmd, DateTime start, DateTime end)
        {
            List<DateTime> res = new List<DateTime>();
            cmd.Parameters.Clear();
            cmd.CommandText = "select Day from Training where Day Between @start and @end and Len(Comment) > 0";
            cmd.Parameters.Add("@start", SqlDbType.DateTime).Value = start;
            cmd.Parameters.Add("@end", SqlDbType.DateTime).Value = end;
            using (SqlCeDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    res.Add(Convert.ToDateTime(reader["Day"]));
                }
            }
            cmd.Parameters.Clear();
            return res;
        }
        public static void UpdateBase()
        {
            string path = ConfigurationManager.AppSettings["db"];
            string backupPath = path + ".backup";
            try
            {

                File.Copy(path, path + ".backup");
                using (SqlCeConnection connection = new SqlCeConnection(path))
                {
                    using (SqlCeCommand cmd = connection.CreateCommand())
                    {
                        connection.Open();
                        
                    }
                }
                File.Delete(backupPath);
            }
            catch (Exception e)
            {
                File.Delete(path);
                File.Copy(backupPath, path);
                throw e; 
            }

        }
        public static MeasurementType GetMeasurement(SqlCeCommand cmd, DateTime date)
        {
            MeasurementType res = new MeasurementType();
            cmd.Parameters.Clear();
            cmd.CommandText = "select ID from Training where Day = @date";
            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = date.Date;

            object o = cmd.ExecuteScalar();
            if (o == null || o is DBNull)
            {
                res.TrainingId = 0;
                return res;
            }
            res.TrainingId = Convert.ToInt32(o);
            cmd.Parameters.Clear();
            cmd.CommandText = "select * from BodyMeasurement where TrainingId = @trId";
            cmd.Parameters.Add("@trId", SqlDbType.Int).Value = res.TrainingId;
            using (SqlCeDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    res.Biceps_h = Convert.ToSingle(reader["Biceps_h"]);
                    res.Biceps_l = Convert.ToSingle(reader["Biceps_l"]);
                    res.BodyFat = Convert.ToSingle(reader["BodyFat"]);
                    res.Chest_h = Convert.ToSingle(reader["Chest_h"]);
                    res.Chest_l = Convert.ToSingle(reader["Chest_l"]);
                    res.date = date;
                    res.Hip_h = Convert.ToSingle(reader["Hip_h"]);
                    res.Hip_l = Convert.ToSingle(reader["Hip_l"]);
                    res.Midarm_h = Convert.ToSingle(reader["Midarm_h"]);
                    res.Midarm_l = Convert.ToSingle(reader["Midarm_l"]);
                    res.Waistline_h = Convert.ToSingle(reader["Waistline_h"]);
                    res.Waistline_l = Convert.ToSingle(reader["Waistline_l"]);
                }
            }
            res.BodyWeight = GetBodyWeight(cmd, date);
            cmd.Parameters.Clear();
            return res;
        }
        public static void SaveMeasurement(SqlCeCommand cmd, MeasurementType m)
        {
            cmd.Parameters.Clear();
            m.TrainingId = GetTrainingDayId(m.date, cmd);
            cmd.CommandText = "select count(Id) from BodyMeasurement where TrainingId = @trId";
            cmd.Parameters.Add("@trId", SqlDbType.Int).Value = m.TrainingId;
            bool isExist = Convert.ToBoolean(cmd.ExecuteScalar());
            cmd.Parameters.Clear();
            if (!isExist)
            {
                
                cmd.CommandText = @"insert into BodyMeasurement(TrainingId,Biceps_h, Biceps_l, BodyFat, Chest_h, Chest_l, Hip_h, Hip_l, Midarm_h, Midarm_l, Waistline_h, Waistline_l)
                                   values(@trId,@Biceps_h, @Biceps_l, @BodyFat, @Chest_h, @Chest_l, @Hip_h, @Hip_l, @Midarm_h, @Midarm_l, @Waistline_h, @Waistline_l)";
                cmd.Parameters.Add("@Biceps_h", SqlDbType.Float).Value = m.Biceps_h;
                cmd.Parameters.Add("@Biceps_l", SqlDbType.Float).Value = m.Biceps_l;
                cmd.Parameters.Add("@BodyFat", SqlDbType.Float).Value = m.BodyFat;
                cmd.Parameters.Add("@Chest_h", SqlDbType.Float).Value = m.Chest_h;
                cmd.Parameters.Add("@Chest_l", SqlDbType.Float).Value = m.Chest_l;
                cmd.Parameters.Add("@Hip_h", SqlDbType.Float).Value = m.Hip_h;
                cmd.Parameters.Add("@Hip_l", SqlDbType.Float).Value = m.Hip_l;
                cmd.Parameters.Add("@Midarm_h", SqlDbType.Float).Value = m.Midarm_h;
                cmd.Parameters.Add("@Midarm_l", SqlDbType.Float).Value = m.Midarm_l;
                cmd.Parameters.Add("@Waistline_h", SqlDbType.Float).Value = m.Waistline_h;
                cmd.Parameters.Add("@Waistline_l", SqlDbType.Float).Value = m.Waistline_l;
                cmd.Parameters.Add("@trId", SqlDbType.Int).Value = m.TrainingId;
                cmd.ExecuteNonQuery();
            }
            else
            {
                cmd.CommandText = @"update BodyMeasurement set
                                      Biceps_h = @Biceps_h,
                                      Biceps_l = @Biceps_l,
                                      BodyFat = @BodyFat,
                                      Chest_h = @Chest_h,
                                      Chest_l = @Chest_l,
                                      Hip_h = @Hip_h,
                                      Hip_l = @Hip_l,
                                      Midarm_h = @Midarm_h,
                                      Midarm_l = @Midarm_l,
                                      Waistline_h = @Waistline_h,
                                      Waistline_l = @Waistline_l
                                      where TrainingId = @trId
                            ";
                cmd.Parameters.Add("@Biceps_h", SqlDbType.Float).Value = m.Biceps_h;
                cmd.Parameters.Add("@Biceps_l", SqlDbType.Float).Value = m.Biceps_l;
                cmd.Parameters.Add("@BodyFat", SqlDbType.Float).Value = m.BodyFat;
                cmd.Parameters.Add("@Chest_h", SqlDbType.Float).Value = m.Chest_h;
                cmd.Parameters.Add("@Chest_l", SqlDbType.Float).Value = m.Chest_l;
                cmd.Parameters.Add("@Hip_h", SqlDbType.Float).Value = m.Hip_h;
                cmd.Parameters.Add("@Hip_l", SqlDbType.Float).Value = m.Hip_l;
                cmd.Parameters.Add("@Midarm_h", SqlDbType.Float).Value = m.Midarm_h;
                cmd.Parameters.Add("@Midarm_l", SqlDbType.Float).Value = m.Midarm_l;
                cmd.Parameters.Add("@Waistline_h", SqlDbType.Float).Value = m.Waistline_h;
                cmd.Parameters.Add("@Waistline_l", SqlDbType.Float).Value = m.Waistline_l;
                cmd.Parameters.Add("@trId", SqlDbType.Int).Value = m.TrainingId;
                cmd.ExecuteNonQuery();
            }
            SaveBodyWeight(cmd, m.date, m.BodyWeight);
            cmd.Parameters.Clear();
   
        }
        public static List<DateTime> GetMeasurementDays(SqlCeCommand cmd)
        {
            List<DateTime> res = new List<DateTime>();
            cmd.Parameters.Clear();
            cmd.CommandText = "select Day from BodyMeasurement inner join Training on BodyMeasurement.TrainingId = Training.Id";
            using (SqlCeDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    res.Add(Convert.ToDateTime(reader["Day"])); 
                }
            }
            cmd.Parameters.Clear();
            return res;
        }
        public static float GetBodyWeight(SqlCeCommand cmd, DateTime date)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = @"select BodyWeight from Training 
                                    where Day = @Day";
            cmd.Parameters.Add("@Day", SqlDbType.DateTime).Value = date;
            object bodyWeight = (object)cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            if (bodyWeight == null || bodyWeight is DBNull) return 0;
            return Convert.ToSingle(bodyWeight);
        }
        public static int SaveBodyWeight(SqlCeCommand cmd, DateTime date, float bodyWeight)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "UPDATE Training set BodyWeight = @bodyWeight where Day = @day";
            cmd.Parameters.Add("@day", SqlDbType.DateTime).Value = date;
            cmd.Parameters.Add("@bodyWeight", SqlDbType.Float).Value = bodyWeight;
            int rowsAffected = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return rowsAffected;
        }

      
    }
}
