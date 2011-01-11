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
            string tableName = "Exersize";
            string IdColumn = "ExersizeID";
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
                            SqlCeTransaction transaction = sdfConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                            using (SqlCeCommand sdfCommand = sdfConnection.CreateCommand())
                            {
                                sdfCommand.Transaction = transaction;
                                try
                                {
                                    Dictionary<int, int> Training = GetTraining(accessCmd, sdfCommand);
                                    Dictionary<int, int> Exersize = GetExersize(accessCmd, sdfCommand);
                                    Dictionary<int, int> ExersizeCategory = GetExersizeCategory(accessCmd, sdfCommand);
                                    Dictionary<int, int> Template = GetTemplate(accessCmd, sdfCommand);
                                    MoveLinkData(Training, Exersize, accessCmd, sdfCommand);
                                    MoveExersizeCategoryLink(ExersizeCategory, Exersize, accessCmd, sdfCommand);
                                    MoveTrainingTemplate(Template, accessCmd, sdfCommand);
                                    transaction.Commit();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                    transaction.Rollback();
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

        private static void MoveTrainingTemplate(Dictionary<int, int> Template, OleDbCommand accessCmd, SqlCeCommand sdfCommand)
        {
            throw new NotImplementedException();
        }

        private static void MoveExersizeCategoryLink(Dictionary<int, int> ExersizeCategory, Dictionary<int, int> Exersize, OleDbCommand accessCmd, SqlCeCommand sdfCommand)
        {
            throw new NotImplementedException();
        }

        private static void MoveLinkData(Dictionary<int, int> Training, Dictionary<int, int> Exersize, OleDbCommand accessCmd, SqlCeCommand sdfCommand)
        {
            throw new NotImplementedException();
        }

        private static Dictionary<int, int> GetTraining(OleDbCommand accessCmd, SqlCeCommand sdfCommand)
        {
            accessCmd.CommandText = "select * from Training";
            return MoveData(accessCmd, sdfCommand, "Training", "ID");
        }

        private static Dictionary<int, int> GetExersize(OleDbCommand accessCmd, SqlCeCommand sdfCommand)
        {
            accessCmd.CommandText = "select * from Exersize";
            return MoveData(accessCmd, sdfCommand, "Exersize", "ID");
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
                List<string> fromFields = GetFiledNames(reader);
                fromFields.Remove(primaryKeyColumn);
                string insertStatement = GenerateInsert(fromFields, table);
                to.CommandText = insertStatement;
                do
                {
                    FillParams(to.Parameters, fromFields, reader);
                    to.ExecuteNonQuery();
                    to.CommandText = "Select @@Identity";
                    int toId = (int)to.ExecuteScalar();
                    int fromId = (int)reader[primaryKeyColumn];
                    res[fromId] = toId;

                } while (reader.Read());
            }
            return res;
        }

        private static void FillParams(SqlCeParameterCollection sqlCeParameterCollection, List<string> fromFields, OleDbDataReader reader)
        {
            sqlCeParameterCollection.Clear();
            foreach (string par in fromFields)
            {
                sqlCeParameterCollection.AddWithValue(par, reader[par]);
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
