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
            Dictionary<int, int> res = new Dictionary<int, int>();
            return res;
        }

        private static Dictionary<int, int> GetExersize(OleDbCommand accessCmd, SqlCeCommand sdfCommand)
        {
            Dictionary<int, int> res = new Dictionary<int, int>();
            return res;
        }

        private static Dictionary<int, int> GetExersizeCategory(OleDbCommand accessCmd, SqlCeCommand sdfCommand)
        {
            Dictionary<int, int> res = new Dictionary<int, int>();
            return res;
        }

        private static Dictionary<int, int> GetTemplate(OleDbCommand accessCmd, SqlCeCommand sdfCommand)
        {
            Dictionary<int, int> res = new Dictionary<int, int>();
            accessCmd.CommandText = "select * from Template";
            return MoveData(accessCmd, sdfCommand, "Template", "ID");
        }
        public static Dictionary<string, object> GetValues(OleDbDataReader reader)
        {
            Dictionary<string, object> res = new Dictionary<string, object>();
            int i, n = reader.FieldCount;
            for (i = 0; i < n; i++)
            {
                string name = reader.GetName(i);
                object val = reader.GetValue(i);
                res.Add(name, val);

            }
            return res;
        }
        public static string GenerateInsert(DbDataReader reader)
        {
            return string.Empty;
        }
        public static Dictionary<int, int> MoveData(DbCommand from, DbCommand to, string table, string primaryKeyColumn)
        {
            Dictionary<int, int> res = new Dictionary<int, int>();
            from.Parameters.Clear();
            from.CommandText = "select * from " + table;
            using (DbDataReader reader = from.ExecuteReader())
            {
                GenerateCommand(reader, to);
                while (reader.Read())
                {
                    DbParameter p = new DbParameter();

                     //to.Parameters.Add(
                }
            }
            return res;
        }

        private static void GenerateCommand(DbDataReader reader, DbCommand to)
        {
           
        }
    }
}
