using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlServerCe;
using System.Data.OleDb;
using System.Data.Common;

namespace accdbTosdf
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

                using (OleDbConnection access = new OleDbConnection(ConfigurationManager.AppSettings["accdb"]))
                {
                    access.Open();
                    using (OleDbCommand accessCmd = access.CreateCommand())
                    {

                        using (SqlCeConnection sdfConnection = new SqlCeConnection(ConfigurationManager.AppSettings["sdf"]))
                        {
                            sdfConnection.Open();
                            //SqlCeTransaction transaction = sdfConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                            using (SqlCeCommand sdfCommand = sdfConnection.CreateCommand())
                            {
                                //sdfCommand.Transaction = transaction;
                                try
                                {
                                    Dictionary<int, int> Training = GetTraining(accessCmd, sdfCommand);
                                    Dictionary<int, int> Exersize = GetExersize(accessCmd, sdfCommand);
                                    Dictionary<int, int> ExersizeCategory = GetExersizeCategory(accessCmd, sdfCommand);
                                    Dictionary<int, int> Template = GetTemplate(accessCmd, sdfCommand);
                                    MoveLinkData(Training, Exersize, accessCmd, sdfCommand);
                                    MoveExersizeCategoryLink(ExersizeCategory, Exersize, accessCmd, sdfCommand);
                                    MoveTrainingTemplate(Template, Exersize, accessCmd, sdfCommand);
                                    //transaction.Commit();
                                    CheckCorrects(accessCmd, sdfCommand);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                    //transaction.Rollback();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private static int cmp(ExersizeInstance x, ExersizeInstance y)
        {
            if (x < y) return 1;
            if (x == y) return 0;
            return -1;
        }

        private static void CheckCorrects(OleDbCommand accessCmd, SqlCeCommand sdfCommand)
        {
            accessCmd.CommandText = @"select Day,Weight,Count,ShortName from (Training 
                                        inner join Link on Training.ID = Link.TrainingID )
                                        inner join Exersize on Exersize.ExersizeID = Link.ExersizeID
                                        Order by Day,ShortName, Weight, Count ";
            List<ExersizeInstance> source = new List<ExersizeInstance>();
            using (OleDbDataReader reader = accessCmd.ExecuteReader())
            {
                while (reader.Read())
                {

                    ExersizeInstance exersize = new ExersizeInstance()
                    {
                        Day = Convert.ToDateTime(reader["Day"]),
                        Count = Convert.ToInt32(reader["count"]),
                        Weight = Convert.ToInt32(reader["Weight"]),
                        name = Convert.ToString(reader["ShortName"]).Trim()
                    };
                    source.Add(exersize);

                }
            }
            sdfCommand.CommandText = @"select Day,Weight,Count,ShortName from (Training 
                                       inner join Link on Training.ID = Link.TrainingID )
                                       inner join Exersize on Exersize.ID = Link.ExersizeID
                                        Order by Day,ShortName, Weight, Count ";
            List<ExersizeInstance> desistation = new List<ExersizeInstance>();
            using (SqlCeDataReader reader = sdfCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    ExersizeInstance exersize = new ExersizeInstance()
                    {
                        Day = Convert.ToDateTime(reader["Day"]),
                        Count = Convert.ToInt32(reader["count"]),
                        Weight = Convert.ToInt32(reader["Weight"]),
                        name = Convert.ToString(reader["ShortName"]).Trim()
                    };
                    desistation.Add(exersize);
                }
            }

          //  source.Sort(cmp);
           // desistation.Sort(cmp);
            int n = source.Count;
            if (n != desistation.Count) throw new Exception("Length is different");
            for (int i = 0; i < n; i++)
            {
                if (source[i] != desistation[i]) throw new Exception(string.Format("Incorrect values at{0}", i));
            }
        }

        private static void MoveTrainingTemplate(Dictionary<int, int> Template, Dictionary<int, int> Exersize, OleDbCommand accessCmd, SqlCeCommand sdfCommand)
        {
            accessCmd.CommandText = "select * from TrainingTemplate";
            using (OleDbDataReader reader = accessCmd.ExecuteReader())
            {
                sdfCommand.Parameters.Clear();
                sdfCommand.CommandText = "insert into TrainingTemplate(TemplateID, ExersizeID, Weight, Count) values(@TemplateID, @ExersizeID, @Weight, @Count)";
                sdfCommand.Parameters.Add("@TemplateID", null);
                sdfCommand.Parameters.Add("@ExersizeID", null);
                sdfCommand.Parameters.Add("@Weight", null);
                sdfCommand.Parameters.Add("@Count", null);

                while (reader.Read())
                {
                    sdfCommand.Parameters["@TemplateID"].Value = Template[Convert.ToInt32(reader["TemplateID"])];
                    sdfCommand.Parameters["@ExersizeID"].Value = Exersize[Convert.ToInt32(reader["ExersizeID"])];
                    sdfCommand.Parameters["@Weight"].Value = reader["Weight"];
                    sdfCommand.Parameters["@Count"].Value = reader["Count"];
                    sdfCommand.ExecuteNonQuery();
                }
            }
        }

        private static void MoveExersizeCategoryLink(Dictionary<int, int> ExersizeCategory, Dictionary<int, int> Exersize, OleDbCommand accessCmd, SqlCeCommand sdfCommand)
        {
            accessCmd.CommandText = "select * from ExersizeCategoryLink";
            using (OleDbDataReader reader = accessCmd.ExecuteReader())
            {
                sdfCommand.Parameters.Clear();
                sdfCommand.CommandText = "insert into ExersizeCategoryLink(ExersizeID, ExersizeCategoryID) values(@ExersizeID, @ExersizeCategoryID)";
                sdfCommand.Parameters.Add("@ExersizeCategoryID", null);
                sdfCommand.Parameters.Add("@ExersizeID", null);

                while (reader.Read())
                {
                    sdfCommand.Parameters["@ExersizeCategoryID"].Value = ExersizeCategory[Convert.ToInt32(reader["ExersizeCategoryID"])];
                    sdfCommand.Parameters["@ExersizeID"].Value = Exersize[Convert.ToInt32(reader["ExersizeID"])];
                    sdfCommand.ExecuteNonQuery();
                }
            }
        }

        private static void MoveLinkData(Dictionary<int, int> Training, Dictionary<int, int> Exersize, OleDbCommand accessCmd, SqlCeCommand sdfCommand)
        {
            accessCmd.CommandText = "select * from Link";
            using (OleDbDataReader reader = accessCmd.ExecuteReader())
            {
                sdfCommand.Parameters.Clear();
                sdfCommand.CommandText = "insert into Link(TrainingID, ExersizeID, Weight, Count) values(@TrainingID, @ExersizeID, @Weight, @Count)";
                sdfCommand.Parameters.Add("@TrainingID", null);
                sdfCommand.Parameters.Add("@ExersizeID", null);
                sdfCommand.Parameters.Add("@Weight", null);
                sdfCommand.Parameters.Add("@Count", null);

                while (reader.Read())
                {
                    sdfCommand.Parameters["@TrainingID"].Value =  Training[Convert.ToInt32(reader["TrainingID"])];
                    sdfCommand.Parameters["@ExersizeID"].Value = Exersize[Convert.ToInt32(reader["ExersizeID"])];
                    sdfCommand.Parameters["@Weight"].Value = reader["Weight"];
                    sdfCommand.Parameters["@Count"].Value = reader["Count"];
                    sdfCommand.ExecuteNonQuery();
                }
            }
        }

        private static Dictionary<int, int> GetTraining(OleDbCommand accessCmd, SqlCeCommand sdfCommand)
        {
            accessCmd.CommandText = "select * from Training";
            return MoveData(accessCmd, sdfCommand, "Training", "ID");
        }

        private static Dictionary<int, int> GetExersize(OleDbCommand accessCmd, SqlCeCommand sdfCommand)
        {
            accessCmd.CommandText = "select * from Exersize";
            return MoveData(accessCmd, sdfCommand, "Exersize", "ExersizeID");
        }

        private static Dictionary<int, int> GetExersizeCategory(OleDbCommand accessCmd, SqlCeCommand sdfCommand)
        {
            accessCmd.CommandText = "select * from ExersizeCategory";
            return MoveData(accessCmd, sdfCommand, "ExersizeCategory", "ID");
        }

        private static Dictionary<int, int> GetTemplate(OleDbCommand accessCmd, SqlCeCommand sdfCommand)
        {
            Dictionary<int, int> res = new Dictionary<int, int>();
            accessCmd.CommandText = "select * from Template";
            return MoveData(accessCmd, sdfCommand, "Template", "ID");
        }
        public static List<string> GetFiledNames(OleDbDataReader reader)
        {
            List<string> res = new List<string>();
            int i, n = reader.FieldCount;
            for (i = 0; i < n; i++)
            {
                string name = reader.GetName(i);
                res.Add(name);

            }
            return res;
        }

        /// <summary>
        /// возвращает маппинг объектов id в старой базе и id в новой.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="table"></param>
        /// <param name="primaryKeyColumn"></param>
        /// <returns></returns>
        public static Dictionary<int, int> MoveData(OleDbCommand from, SqlCeCommand to, string table, string primaryKeyColumn)
        {
            Dictionary<int, int> res = new Dictionary<int, int>();
            from.Parameters.Clear();
            from.CommandText = "select * from " + table;
            using (OleDbDataReader reader = from.ExecuteReader())
            {
                reader.Read();
                if (reader.HasRows)
                {
                    List<string> fromFields = GetFiledNames(reader);
                    fromFields.Remove(primaryKeyColumn);
                    fromFields.Remove("Field1");
                    string insertStatement = GenerateInsert(fromFields, table);
                    to.CommandText = insertStatement;
                    do
                    {
                        to.CommandText = insertStatement;
                        FillParams(to.Parameters, fromFields, reader);
                        to.ExecuteNonQuery();
                        to.CommandText = "SELECT @@IDENTITY";
                        int toId = Convert.ToInt32(to.ExecuteScalar());
                        int fromId = (int)reader[primaryKeyColumn];
                        res[fromId] = toId;

                    } while (reader.Read());
                }
            }
            return res;
        }

        private static void FillParams(SqlCeParameterCollection sqlCeParameterCollection, List<string> fromFields, OleDbDataReader reader)
        {
            sqlCeParameterCollection.Clear();
            foreach (string par in fromFields)
            {
                object value = reader[par];
                if (value is DBNull) {
                    if(par == "Comment" || par == "Description") value = string.Empty;
                }
                sqlCeParameterCollection.AddWithValue(par, value);
            }
        }

        private static string GenerateInsert(List<string> fromFields, string table)
        {
            string insert = string.Format("insert into {0}  ({1})  values(", table, string.Join(",", fromFields.ToArray()));
            foreach (string par in fromFields)
            {
                insert += "@" + par + ",";
            }
            if (insert[insert.Length - 1] == ',') insert = insert.Substring(0, insert.Length - 1);
            insert += ")";
            return insert;
        }

        private static List<string> GetFields(Dictionary<string, object> fromValues)
        {
            throw new NotImplementedException();
        }
    }
}
