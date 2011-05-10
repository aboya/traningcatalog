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
        public static int GetTrainingDayId(SqlCeCommand cmd, DateTime date)
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
            int dayId = GetTrainingDayId(cmd, dateTime);
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
            cmd.CommandText = @"SELECT Training.Day
                                    FROM  Training INNER JOIN
                                    Link ON Training.Id = Link.TrainingId
                                    where Day Between @start and @end
                                    GROUP BY Training.Day  ";
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
        public static List<DateTime> GetCommentDays(SqlCeCommand cmd)
        {
            List<DateTime> res = new List<DateTime>();
            cmd.Parameters.Clear();
            cmd.CommandText = "select Day from Training where Len(Comment) > 0";
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
            m.TrainingId = GetTrainingDayId(cmd, m.date);
            cmd.CommandText = "select count(Id) from BodyMeasurement where TrainingId = @trId";
            cmd.Parameters.Add("@trId", SqlDbType.Int).Value = m.TrainingId;
            bool isExist = Convert.ToBoolean(cmd.ExecuteScalar());
            cmd.Parameters.Clear();
            if (!isExist)
            {
                if (!m.IsEmpty)
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
                
            }
            else
            {
                if (!m.IsEmpty)
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
                else
                {
                    cmd.CommandText = "delete from BodyMeasurement where TrainingId = @trId";
                    cmd.Parameters.Add("@trId", SqlDbType.Int).Value = m.TrainingId;
                    cmd.ExecuteNonQuery();
                }
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
        public static List<CategoryType> GetCategories(SqlCeCommand cmd)
        {
            List<CategoryType> res = new List<CategoryType>();
            cmd.Parameters.Clear();
            cmd.CommandText = "select Id,Name from ExersizeCategory order by Name";
            using (SqlCeDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    res.Add(new CategoryType()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = Convert.ToString(reader["Name"])
                    });
                }
            }
            cmd.Parameters.Clear();
            return res;
            
        }
        public static List<ExersizeSource> GetExersizes(SqlCeCommand cmd)
        {
            return GetExersizes(cmd, -1);
        }
        public static List<ExersizeSource> GetExersizes(SqlCeCommand cmd, int categoryId)
        {
            if (categoryId <= 0)
            {
                cmd.CommandText = "select * from Exersize order by ShortName";
            }
            else
            {

                cmd.CommandText = @"select Exersize.ID, Exersize.ShortName from Exersize 
                                        inner join ExersizeCategoryLink on
                                        ExersizeCategoryLink.ExersizeID = Exersize.ID
                                        where  ExersizeCategoryLink.ExersizeCategoryID = @exersizeCategoryId   
                                        order by ShortName";
                cmd.Parameters.Add("@exersizeCategoryId", SqlDbType.Int).Value = categoryId;

            }
            List<ExersizeSource> Exersizes = new List<ExersizeSource>();
            using (SqlCeDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Exersizes.Add(new ExersizeSource()
                    {
                        ExersizeID = Convert.ToInt32(dr["ID"]),
                        ShortName = Convert.ToString(dr["ShortName"])

                    });
                }
            }
            return Exersizes;
        }
        
        public static void AddCategory(SqlCeCommand cmd, string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "insert into ExersizeCategory (Name) values(@name)";
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
        }
        /// <summary>
        /// returns true if category is used otherwise false
        /// </summary>
        /// <returns></returns>
        public static bool CheckCategory(SqlCeCommand cmd, int CategoryId)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "select count(*) from ExersizeCategoryLink where ExersizeCategoryId = @categoryId";
            cmd.Parameters.Add("@categoryId", SqlDbType.Int).Value = CategoryId;
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Parameters.Clear();
            return count > 0;
        }
        public static void DeleteCategory(SqlCeCommand cmd, int CategoryId)
        {
            cmd.Parameters.Clear();

            using (SqlCeTransaction transaction = cmd.Connection.BeginTransaction())
            {
                try
                {
                    cmd.CommandText = "delete from ExersizeCategoryLink where ExersizeCategoryId = @categoryId";
                    cmd.Parameters.Add("@categoryId", SqlDbType.Int).Value = CategoryId;
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "update TrainingTemplate set ExersizeCategoryId = null where ExersizeCategoryId = @categoryId";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "delete from ExersizeCategory where Id = @categoryId";
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
                finally
                {
                    cmd.Parameters.Clear();
                }
            }
       
        }


        public static void UpdateCategory(SqlCeCommand cmd, CategoryType category)
        {
            if (!string.IsNullOrEmpty(category.Name))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "update ExersizeCategory set Name = @name where Id =@Id";
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = category.Name;
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = category.Id;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
        }


        public static void SaveTemplate(SqlCeConnection connection, List<TemplateExersizesType> list, int _TemplateID, string name)
        {
            if (list == null || list.Count == 0) return;
            SqlCeTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                try
                {
                    using (SqlCeCommand cmd = connection.CreateCommand())
                    {
                        cmd.Transaction = transaction;
                        if (name != null && name.Trim().Length > 0)
                        {
                            //if exists
                            if (_TemplateID > 0)
                            {
                                cmd.CommandText = string.Format("update Template set Name='{0}' where ID={1}", name.Replace("'", "").Trim(), _TemplateID);
                                cmd.ExecuteNonQuery();
                            }
                            else
                            {
                                cmd.CommandText = "insert into Template (Name) values(@name)";
                                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name.Replace("'", "").Trim();
                                cmd.ExecuteNonQuery();

                                cmd.CommandText = "select @@Identity";
                                _TemplateID = Convert.ToInt32(cmd.ExecuteScalar());
                            }
                            
                        }
                        foreach (TemplateExersizesType exersize in list)
                        {
                            cmd.Parameters.Clear();
                            if (exersize.ID == 0)
                            {
                                cmd.CommandText = "insert into TrainingTemplate (TemplateID, ExersizeID, Weight, [Count],ExersizeCategoryId) values(@TemplateID, @ExersizeID, @Weight, @cnt, @ExersizeCategoryId) ";
                                cmd.Parameters.Add("@TemplateID", SqlDbType.Int).Value = _TemplateID;
                            }
                            else
                            {
                                cmd.CommandText = "update TrainingTemplate set ExersizeID=@ExersizeID, Weight=@Weight, [Count]=@cnt,ExersizeCategoryId=@ExersizeCategoryId   where ID=@ID";
                                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = exersize.ID;
                            }
                            cmd.Parameters.Add("@ExersizeID", SqlDbType.Int).Value = exersize.ExersizeID;
                            cmd.Parameters.Add("@Weight", SqlDbType.Int).Value = exersize.Weight;
                            cmd.Parameters.Add("@cnt", SqlDbType.Int).Value = exersize.Count;
                            cmd.Parameters.Add("@ExersizeCategoryId", SqlDbType.Int).Value = exersize.ExersizeCategoryID.HasValue ? (object)exersize.ExersizeCategoryID.Value : DBNull.Value;
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            if (exersize.ID == 0)
                            {
                                cmd.CommandText = "select @@Identity";
                                exersize.ID = Convert.ToInt32(cmd.ExecuteScalar());
                            }
                        }
                        // deleting exersizes witch user delete
                        if (_TemplateID > 0)
                        {
                            string existsid = string.Join(",", (from ex in list select ex.ID.ToString()).ToArray());
                            cmd.CommandText = string.Format("delete from TrainingTemplate where TemplateID={0} and ID not in({1})", _TemplateID, existsid);
                            cmd.ExecuteNonQuery();
                        }

                    }
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    MessageBox.Show(e.Message);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static List<TemplateExersizesType> GetTemplateExersizes(SqlCeConnection connection, int templateId)
        {
            List<TemplateExersizesType> res = new List<TemplateExersizesType>();
            try
            {
                connection.Open();
                using (SqlCeCommand cmd = connection.CreateCommand())
                {

                    cmd.CommandText = string.Format(@"select tt.Id,tt.TemplateId,
                                                        tt.ExersizeId,tt.ExersizeCategoryId,
                                                        tt.Weight,tt.[Count],
                                                        ec.ExersizeCategoryId as exCategoryId
                                                        from trainingtemplate tt
                                                      
                                                    left join exersizecategorylink ec 
                                                    on
                                                    tt.exersizecategoryid = ec.exersizecategoryid
                                                    and tt.exersizeid = ec.exersizeid where TemplateID={0}", templateId);
                    using (SqlCeDataReader dr = cmd.ExecuteReader())
                    {
                        for (int i = 0; dr.Read(); i++)
                        {
                            // check if category in template not exist or refference to another exersize(if user reassing category of exersize)
                            int? exersizeCategoryId;
                            if (dr["ExersizeCategoryId"] is DBNull) exersizeCategoryId = null;
                            else
                            {
                                exersizeCategoryId = Convert.ToInt32(dr["ExersizeCategoryId"]);
                                if (dr["exCategoryId"] is DBNull || Convert.ToInt32(dr["exCategoryId"]) != exersizeCategoryId)
                                {
                                    exersizeCategoryId = null;
                                }
                            }
                            res.Add(new TemplateExersizesType()
                            {
                                ID = Convert.ToInt32(dr["ID"]),
                                Count = Convert.ToInt32(dr["Count"]),
                                Weight = Convert.ToInt32(dr["Weight"]),
                                ExersizeID = Convert.ToInt32(dr["ExersizeID"]),
                                ExersizeCategoryID = exersizeCategoryId
                            });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return res;
        }

        public static List<TemplateExersizesType> GetExersizes(SqlCeCommand cmd, DateTime date)
        {
            cmd.Parameters.Clear();
            List<TemplateExersizesType> res = new List<TemplateExersizesType>();
            cmd.CommandText = @"select Link.ID as ID, Exersize.ID as ExersizeID, ShortName,Weight, [Count] from  Link 
                                    inner join Training on Training.ID = Link.TrainingID  
                                    inner  join Exersize on Exersize.ID = Link.ExersizeID
                                    where Day = @day order by Link.ID";
            cmd.Parameters.Add("@Day", SqlDbType.DateTime).Value = date;
            using (SqlCeDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!(reader["ID"] is DBNull))
                    {
                        res.Add(new TemplateExersizesType()
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            ExersizeID = Convert.ToInt32(reader["ExersizeID"]),
                            Count = Convert.ToInt32(reader["Count"]),
                            Weight = Convert.ToInt32(reader["Weight"])
                        });
                    }
                }
            }
            cmd.Parameters.Clear();
            return res;
        }


        public static List<CardioExersizeType> GetCardioExersizes(SqlCeCommand cmd)
        {
            List<CardioExersizeType> res = new List<CardioExersizeType>();
            cmd.Parameters.Clear();
            cmd.CommandText = "select Id, Name from CardioType";
            using (SqlCeDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    res.Add(new CardioExersizeType()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = Convert.ToString(reader["Name"])
                    });
                }
            }
            cmd.Parameters.Clear();
            return res;
        }
        public static CardioSessionType CreateCardioSession(SqlCeCommand cmd, DateTime date)
        {
            CardioSessionType res = new CardioSessionType();
            int trainingId = GetTrainingDayId(cmd, date);
            cmd.CommandText = "insert into CardioSession (TrainingId) values(@trId)";
            cmd.Parameters.Add("@trId", SqlDbType.Int).Value = trainingId;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select @@Identity";
            int sessionId = Convert.ToInt32(cmd.ExecuteScalar());
            cmd.Parameters.Clear();
            res.Id = sessionId;
            res.TrainingId = trainingId;
            res.Date = date;
            return res;
        }
        public static void SaveCardioSession(SqlCeCommand cmd, CardioSessionType session)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "update CardioSession " +
                                " set StartTime = @StartTime, EndTime = @EndTime " +
                                  " where Id = @sid";
            cmd.Parameters.Add("@sid", SqlDbType.Int).Value = session.Id;
            cmd.Parameters.Add("@StartTime", SqlDbType.Int).Value = session.StartTime == 0 ? DBNull.Value : (object)session.StartTime;
            cmd.Parameters.Add("@EndTime", SqlDbType.Int).Value = session.EndTime == 0 ? DBNull.Value : (object)session.EndTime;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }
        public static void DeleteCardioSession(SqlCeCommand cmd, int SessionId)
        {
            cmd.Parameters.Clear();
            using (SqlCeTransaction transaction = cmd.Connection.BeginTransaction())
            {
                try
                {
                    cmd.CommandText = "delete from CardioInterval " +
                                      "where CardioSessionId = @sid";
                    cmd.Parameters.Add("@sid", SqlDbType.Int).Value = SessionId;
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "delete CardioSession " +
                                        "where Id = @sid";
                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
                finally
                {
                    cmd.Parameters.Clear();
                }
            }
        }
        public static CardioSessionType GetCardioSession(SqlCeCommand cmd, int SessionId)
        {
            CardioSessionType res = new CardioSessionType();
            cmd.Parameters.Clear();
            cmd.CommandText = "select Id, TrainingId, StartTime, EndTime from CardioSession where Id = @Id";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = SessionId;
            using (SqlCeDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    res.Id = SessionId;
                    res.StartTime = reader["StartTime"] is DBNull ? 0: Convert.ToInt32(reader["StartTime"]);
                    res.EndTime = reader["EndTime"] is DBNull ? 0: Convert.ToInt32(reader["EndTime"]);
                    res.TrainingId = Convert.ToInt32(reader["TrainingId"]);
                }
            }
            cmd.Parameters.Clear();
            return res;
        }
        public static List<CardioSessionType> GetCardioSessions(SqlCeCommand cmd, DateTime dt)
        {
            List<CardioSessionType> res = new List<CardioSessionType>();
            
            cmd.Parameters.Clear();
            cmd.CommandText = "select Id from Training where Day = @day";
            cmd.Parameters.Add("@day", SqlDbType.DateTime).Value = dt.Date;
            object o = cmd.ExecuteScalar();
            if (o is DBNull || o == null) return res;
            int TrainingId = Convert.ToInt32(o);
            cmd.Parameters.Clear();
            cmd.CommandText = "select Id,StartTime,EndTime,TrainingId from CardioSession where TrainingId = @trId";
            cmd.Parameters.Add("@trId", SqlDbType.Int).Value = TrainingId;
            using (SqlCeDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    res.Add(new CardioSessionType()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        StartTime = reader["StartTime"] is DBNull ? 0 : Convert.ToInt32(reader["StartTime"]),
                        EndTime = reader["EndTime"] is DBNull ? 0 : Convert.ToInt32(reader["EndTime"]),
                        TrainingId = Convert.ToInt32(reader["TrainingId"]),
                        Date = dt.Date
                    });
                }
            }
            cmd.Parameters.Clear();
            return res;
        }
        /// <summary>
        /// saves exersize. if id = 0 add new exersize else update exists
        /// </summary>
        /// <returns></returns>
        public static void SaveCardioExersize(SqlCeCommand cmd, CardioExersizeType exersize, Dictionary<int, bool> cardioTypes)
        {
            // Velocity 
            //Time 
            //Distance  
            //Intensivity 
            //Resistance  
            cmd.Parameters.Clear();
            if (exersize.Id == 0)
            {
                cmd.CommandText = "insert into CardioType (Name,Intensivity,Resistance,Velocity,[Time],Distance,HeartRate) " +
                                   "values(@name,@Intensivity, @Resistance, @Velocity, @Time, @Distance,@HeartRate) ";
            }
            else
            {
                cmd.CommandText = "update CardioType set Name = @name,Intensivity = @Intensivity,Resistance = @Resistance,Velocity = @Velocity,Time = @Time,Distance = @Distance, HeartRate=@HeartRate " +
                                        "where ID = @id;";
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = exersize.Id;
            }
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = exersize.Name;
            cmd.Parameters.Add("@Intensivity", SqlDbType.Bit).Value =cardioTypes[1];
            cmd.Parameters.Add("@Resistance", SqlDbType.Bit).Value =cardioTypes[2];
            cmd.Parameters.Add("@Velocity", SqlDbType.Bit).Value = cardioTypes[3];
            cmd.Parameters.Add("@Time", SqlDbType.Bit).Value = cardioTypes[4];
            cmd.Parameters.Add("@Distance", SqlDbType.Bit).Value = cardioTypes[5];
            cmd.Parameters.Add("@HeartRate", SqlDbType.Bit).Value = cardioTypes[6];
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();


        }
        public static List<CardioIntervalType> GetCardioIntervals(SqlCeCommand cmd, int sessionId)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = @"SELECT CardioInterval.Id, CardioInterval.CardioSessionId, CardioInterval.CardioTypeId,
                                        CardioInterval.Velocity, CardioInterval.Time, CardioInterval.Distance, 
                                        CardioInterval.Intensivity, CardioInterval.Resistance, CardioInterval.HeartRate, 
                                        CardioType.Name
                          FROM CardioInterval INNER JOIN
                            CardioType ON CardioInterval.CardioTypeId = CardioType.Id  
                          WHERE CardioSessionId = @sid 
                          order by CardioInterval.Id ";
            cmd.Parameters.Add("@sid", SqlDbType.Int).Value = sessionId;
            List<CardioIntervalType> res = new List<CardioIntervalType>();
            using (SqlCeDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    res.Add(new CardioIntervalType()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        CardioTypeId = Convert.ToInt32(reader["CardioTypeId"]),
                        Distance = reader["Distance"] is DBNull ? 0 : Convert.ToDouble(reader["Distance"]),
                        HeartRate = reader["HeartRate"] is DBNull ? 0 : Convert.ToDouble(reader["HeartRate"]),
                        Intensivity = reader["Intensivity"] is DBNull ? 0 : Convert.ToDouble(reader["Intensivity"]),
                        Name = reader["Name"]  is DBNull ? string.Empty : Convert.ToString(reader["Name"]),
                        Resistance = reader["Resistance"] is DBNull ? 0 : Convert.ToDouble(reader["Resistance"]),
                        Time = reader["Time"] is DBNull ? 0 : Convert.ToDouble(reader["Time"]),
                        Velocity = reader["Velocity"] is DBNull ?  0 : Convert.ToDouble(reader["Velocity"])
                    });
                }
            }
           
            cmd.Parameters.Clear();
            return res;
        }
        public static IList<CardioIntervalType> SaveCardioIntervals(SqlCeCommand cmd, IList<CardioIntervalType> intervals, int CardioSessionId)
        {
            
            using (SqlCeTransaction transaction = cmd.Connection.BeginTransaction())
            {
                try
                {

                    foreach (CardioIntervalType i in intervals)
                    {
                        cmd.Parameters.Clear();
                        if (i.Id == 0)
                        {
                            cmd.CommandText = "insert into CardioInterval (CardioTypeId,CardioSessionId, Distance, HeartRate,Intensivity,Resistance,Time,Velocity)" +
                                                "values(@CardioTypeId, @CardioSessionId, @Distance, @HeartRate,@Intensivity,@Resistance,@Time,@Velocity)";
                            cmd.Parameters.Add("@CardioSessionId", SqlDbType.Int).Value = CardioSessionId;
                        }
                        else
                        {
                            cmd.CommandText = "update CardioInterval set CardioTypeId=@CardioTypeId, Distance = @Distance, HeartRate = @HeartRate,Intensivity = @Intensivity,Resistance = @Resistance,Time = @Time,Velocity = @Velocity " +
                                               "where Id = @Id";
                            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = i.Id;
                        }
                        cmd.Parameters.Add("@CardioTypeId", SqlDbType.Int).Value = i.CardioTypeId == 0 ? DBNull.Value : (object)i.CardioTypeId;
                        cmd.Parameters.Add("@Distance", SqlDbType.Float).Value = i.Distance == 0 ? DBNull.Value : (object)i.Distance;
                        cmd.Parameters.Add("@HeartRate", SqlDbType.Float).Value = i.HeartRate == 0 ? DBNull.Value : (object)i.HeartRate;
                        cmd.Parameters.Add("@Intensivity", SqlDbType.Float).Value = i.Intensivity == 0 ? DBNull.Value : (object)i.Intensivity;
                        cmd.Parameters.Add("@Resistance", SqlDbType.Float).Value = i.Resistance == 0 ? DBNull.Value : (object)i.Resistance;
                        cmd.Parameters.Add("@Time", SqlDbType.Float).Value = i.Time == 0 ? DBNull.Value : (object)i.Time;
                        cmd.Parameters.Add("@Velocity", SqlDbType.Float).Value = i.Velocity == 0 ? DBNull.Value : (object)i.Velocity;
                        cmd.ExecuteNonQuery();
                        if(i.Id == 0) 
                        {
                            cmd.Parameters.Clear();
                            cmd.CommandText = "select @@Identity";
                            i.Id = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }
                    // deleting intervals that not exists
                    cmd.Parameters.Clear();
                    string idList = string.Join(",", (from ci in intervals select ci.Id.ToString()).ToArray());
                    cmd.CommandText = "delete from CardioInterval " + 
                                       " where CardioSessionId = @CardioSessionId " +
                                        (idList.Length  > 0 ? " and Id not in (" + idList + ") " : string.Empty);
                    cmd.Parameters.Add("@CardioSessionId", SqlDbType.Int).Value = CardioSessionId;

                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    
                }
                return intervals;


            }
        }
        public static Dictionary<int, string> GetCardioTypes()
        {
            Dictionary<int, string> res = new Dictionary<int, string>();
            res[1] = "Интенсивность";
            res[2] = "Нагрузка";
            res[3] = "Скорость";
            res[4] = "Время";
            res[5] = "Расстояние";
            res[6] = "Пульс";
            return res;
        }

        public static void DeleteCardioExersize(SqlCeCommand cmd, int Id)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "delete from CardioType where Id = @Id";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

        }

        public static Dictionary<int, bool> GetCardioTypesForExersize(SqlCeCommand cmd, int exersizeId)
        {
            Dictionary<int, bool> res = new Dictionary<int, bool>();
            cmd.Parameters.Clear();
            cmd.CommandText = "select Intensivity,Resistance,Velocity,Time,Distance,HeartRate from CardioType where Id = @Id";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = exersizeId;
            using (SqlCeDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    res[1] = Convert.ToBoolean(reader["Intensivity"]);
                    res[2] = Convert.ToBoolean(reader["Resistance"]);
                    res[3] = Convert.ToBoolean(reader["Velocity"]);
                    res[4] = Convert.ToBoolean(reader["Time"]);
                    res[5] = Convert.ToBoolean(reader["Distance"]);
                    res[6] = Convert.ToBoolean(reader["HeartRate"]);
                }
            }
            cmd.Parameters.Clear();
            return res;
        }

        public static List<TemplateType> GetCardioTemplates(SqlCeCommand cmd)
        {
            List<TemplateType> res = new List<TemplateType>();
            cmd.Parameters.Clear();
            cmd.CommandText = "select t.Id,t.Name from Template t inner join CardioTemplate ct on t.Id = ct.TemplateId group by t.Id,t.Name";
            using(SqlCeDataReader reader = cmd.ExecuteReader()) 
            {
                while(reader.Read())
                {
                    res.Add(new TemplateType() {
                         Id = Convert.ToInt32(reader["Id"]),
                         Name = Convert.ToString(reader["Name"])
                    });
                }
            }
            cmd.Parameters.Clear();
            return res;
        }
        public static List<TemplateType> GetWeightLigtingTemplates(SqlCeCommand cmd)
        {
            List<TemplateType> res = new List<TemplateType>();
            cmd.Parameters.Clear();
            cmd.CommandText = "select t.Id,t.Name from Template t inner join TrainingTemplate tt on t.Id = tt.TemplateId group by t.Id,t.Name";
            using (SqlCeDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    res.Add(new TemplateType()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = Convert.ToString(reader["Name"])
                    });
                }
            }
            cmd.Parameters.Clear();
            return res;
        }
        public static void SaveTemplate(SqlCeCommand cmd, TemplateType template)
        {
            cmd.Parameters.Clear();
            if (template.Name.Length > 100) template.Name = template.Name.Substring(0, 100);
            if (template.Id <= 0)
            {
                cmd.CommandText = "insert into Template (Name) values (@name)";
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = template.Name.Replace("'", string.Empty).Trim();
                cmd.ExecuteNonQuery();
                cmd.CommandText = "select @@Identity";
                template.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            else
            {
                cmd.CommandText = "update Template set Name = @name where Id = @Id";
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = template.Name.Replace("'", string.Empty).Trim();
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = template.Id;
                cmd.ExecuteNonQuery();
            }
            cmd.Parameters.Clear();
        }
        public static TemplateType SaveCardioTemplatesExersizes(SqlCeCommand cmd, TemplateType template, IList<CardioIntervalType> intervals)
        {
            cmd.Parameters.Clear();
            using (SqlCeTransaction transaction = cmd.Connection.BeginTransaction())
            {
                try
                {
                    if (template != null)
                    {
                        SaveTemplate(cmd, template);                       
                    }
                    if (intervals != null)
                    {
                        foreach (CardioIntervalType i in intervals)
                        {
                            cmd.Parameters.Clear();
                            if (i.Id == 0)
                            {
                                cmd.CommandText = "insert into CardioTemplate(CardioTypeId,TemplateId, Distance, HeartRate,Intensivity,Resistance,Time,Velocity)" +
                                                    "values(@CardioTypeId, @CardioSessionId, @Distance, @HeartRate,@Intensivity,@Resistance,@Time,@Velocity)";
                                cmd.Parameters.Add("@CardioSessionId", SqlDbType.Int).Value = template.Id;
                            }
                            else
                            {
                                cmd.CommandText = "update CardioTemplate set CardioTypeId=@CardioTypeId, Distance = @Distance, HeartRate = @HeartRate,Intensivity = @Intensivity,Resistance = @Resistance,Time = @Time,Velocity = @Velocity " +
                                                   "where Id = @Id";
                                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = i.Id;
                            }
                            cmd.Parameters.Add("@CardioTypeId", SqlDbType.Int).Value = i.CardioTypeId == 0 ? DBNull.Value : (object)i.CardioTypeId;
                            cmd.Parameters.Add("@Distance", SqlDbType.Float).Value = i.Distance == 0 ? DBNull.Value : (object)i.Distance;
                            cmd.Parameters.Add("@HeartRate", SqlDbType.Float).Value = i.HeartRate == 0 ? DBNull.Value : (object)i.HeartRate;
                            cmd.Parameters.Add("@Intensivity", SqlDbType.Float).Value = i.Intensivity == 0 ? DBNull.Value : (object)i.Intensivity;
                            cmd.Parameters.Add("@Resistance", SqlDbType.Float).Value = i.Resistance == 0 ? DBNull.Value : (object)i.Resistance;
                            cmd.Parameters.Add("@Time", SqlDbType.Float).Value = i.Time == 0 ? DBNull.Value : (object)i.Time;
                            cmd.Parameters.Add("@Velocity", SqlDbType.Float).Value = i.Velocity == 0 ? DBNull.Value : (object)i.Velocity;
                            cmd.ExecuteNonQuery();
                            if (i.Id == 0)
                            {
                                cmd.Parameters.Clear();
                                cmd.CommandText = "select @@Identity";
                                i.Id = Convert.ToInt32(cmd.ExecuteScalar());
                            }
                        }
                        // deleting intervals that not exists
                        cmd.Parameters.Clear();
                        string idList = string.Join(",", (from ci in intervals select ci.Id.ToString()).ToArray());
                        cmd.CommandText = "delete from CardioTemplate " +
                                           " where TemplateId = @TemplateId " +
                                            (idList.Length > 0 ? " and Id not in (" + idList + ") " : string.Empty);
                        cmd.Parameters.Add("@TemplateId", SqlDbType.Int).Value = template.Id;

                        cmd.ExecuteNonQuery();

                    }
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
                finally
                {
                    cmd.Parameters.Clear();
                }
            }
           
            return new TemplateType();
        }
        public static void DeleteCardioTemplate(SqlCeCommand cmd, TemplateType i)
        {
            cmd.Parameters.Clear();
            using (SqlCeTransaction transaction = cmd.Connection.BeginTransaction())
            {
                try
                {
                    cmd.CommandText = "delete from CardioTemplate where TemplateId = @Id";
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = i.Id;
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "delete from Template where Id = @Id";
                    cmd.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
                finally
                {
                    cmd.Parameters.Clear();
                }
                
            }
            
        }

        public static TemplateType GetTemplate(SqlCeCommand cmd, int TemplateId)
        {
            cmd.Parameters.Clear();
            TemplateType res = new TemplateType();
            cmd.CommandText = "select Id,Name from Template where Id = @id";
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = TemplateId;
            using (SqlCeDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    res.Id = TemplateId;
                    res.Name = Convert.ToString(reader["Name"]);
                }
            }
            cmd.Parameters.Clear();
            return res;
        }

        public static List<CardioIntervalType> GetCardioTemplateExersizes(SqlCeCommand cmd, TemplateType template)
        {
            List<CardioIntervalType> res = new List<CardioIntervalType>();
            cmd.Parameters.Clear();
            cmd.CommandText = @"select CardioTemplate.Id, CardioTemplate.CardioTypeId,
                                        CardioTemplate.Velocity, CardioTemplate.Time, CardioTemplate.Distance, 
                                        CardioTemplate.Intensivity, CardioTemplate.Resistance, CardioTemplate.HeartRate, 
                                        CardioType.Name
                                        from CardioTemplate  
                                        INNER JOIN CardioType ON CardioTemplate.CardioTypeId = CardioType.Id
                                        where TemplateId = @id 
                                ";   
                                
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = template.Id;
            using (SqlCeDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    res.Add(new CardioIntervalType()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        CardioTypeId = Convert.ToInt32(reader["CardioTypeId"]),
                        Distance = reader["Distance"] is DBNull ? 0 : Convert.ToDouble(reader["Distance"]),
                        HeartRate = reader["HeartRate"] is DBNull ? 0 : Convert.ToDouble(reader["HeartRate"]),
                        Intensivity = reader["Intensivity"] is DBNull ? 0 : Convert.ToDouble(reader["Intensivity"]),
                        Resistance = reader["Resistance"] is DBNull ? 0 : Convert.ToDouble(reader["Resistance"]),
                        Name = reader["Name"] is DBNull ? string.Empty : Convert.ToString(reader["Name"]),
                        Time = reader["Time"] is DBNull ? 0 : Convert.ToDouble(reader["Time"]),
                        Velocity = reader["Velocity"] is DBNull ? 0 : Convert.ToDouble(reader["Velocity"])
                         
                    });
                }
            }
            cmd.Parameters.Clear();
            return res;
        }

        public static List<DateTime> GetCardioTrainingDays(SqlCeCommand cmd)
        {
            List<DateTime> res = new List<DateTime>();
            cmd.Parameters.Clear();
            cmd.CommandText = @"SELECT Training.Day
                                    FROM  Training INNER JOIN
                                    CardioSession ON Training.Id = CardioSession.TrainingId
                                    GROUP BY Training.Day  ";
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
    }
}
