using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Globalization;
using System.Data;

namespace TrainingCatalog.BusinessLogic.Types
{
    public class dbBusiness
    {
        private static string _connstring;
        private static string connectionString
        {
            get
            {
                
                if (_connstring == null && ConfigurationManager.ConnectionStrings["db"] != null) _connstring = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
                return _connstring;
            }
        }

        public static void UpdateBase()
        {
           // string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            string path = String.Format("{0}\\{1}", Application.StartupPath, ConfigurationManager.AppSettings["databasePath"]);
            try
            {
                // create new db if not exist
                if (!File.Exists(path))
                {
                    using (SqlCeEngine en = new SqlCeEngine(connectionString))
                    {
                        en.CreateDatabase();
                        using (SqlCeConnection connection = new SqlCeConnection(connectionString))
                        {
                            connection.Open();
                            using (SqlCeCommand cmd = connection.CreateCommand())
                            {
                                cmd.CommandText = "create table version_info ( version float )";
                                cmd.ExecuteNonQuery();
                                cmd.CommandText = "insert into version_info (version) values(0)";
                                cmd.ExecuteNonQuery();
                            }
                        }
                         
                    }
                }
                // update databse
                List<double> versions = GetVersionProperties();
                //need update
                if (versions.Count > 0)
                {
                    string backupPath = path + ".backup";
                    
                    if (File.Exists(backupPath))
                    {
                        backupPath = String.Format("{0}.{1:yyyy-MM-dd_hh-mm-ss_fff}", path, DateTime.Now);
                    }
                    File.Copy(path, backupPath, true);
                    using (SqlCeConnection connection = new SqlCeConnection(connectionString))
                    {
                        using (SqlCeCommand cmd = connection.CreateCommand())
                        {
                            connection.Open();
                            cmd.CommandText = "select version from version_info";
                            foreach (double version in versions)
                            {
                               
                                string sql = UpdateDatabase.GetSql(version);
                                if (sql != null && sql.Trim().Length > 0)
                                {
                                    cmd.CommandText = sql.Trim();
                                    cmd.ExecuteNonQuery();

                                    cmd.CommandText = "update version_info set version = @ver";
                                    cmd.Parameters.Add("@ver", SqlDbType.Float).Value = version;
                                    cmd.ExecuteNonQuery();
                                    cmd.Parameters.Clear();

                                }
                            }
                        }
                    }
                    //shrink db
                    string date;
                    const string key = "LastShrinkDate";
                    if (CheckValue(key) == 0)
                    {
                        AddValue(key, DateTime.Now.ToString());
                    }

                    date = GetValue(key);
                    if (!string.IsNullOrEmpty(date))
                    {
                        DateTime dt;
                        if (DateTime.TryParse(date, out dt))
                        {
                            if (DateTime.Now.Subtract(dt).TotalDays > 90)
                            {
                                using (SqlCeEngine en = new SqlCeEngine(connectionString))
                                {
                                    en.Shrink();
                                }
                                SetValue(key, DateTime.Now.ToString());
                            }
                        }
                    }

                    File.Delete(backupPath);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                TrainingCatalog.AppResources.SqlUpdate.ResourceManager.ReleaseAllResources();
            }

        }

        public static List<double> GetVersionProperties()
        {
            double currentVersion;
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = "select version from version_info";
                    currentVersion = Convert.ToDouble(cmd.ExecuteScalar());
                }
            }
            return UpdateDatabase.GetVersionsUpdate(currentVersion);
        }
        private static bool CheckKey(string key)
        {
            if (key == null) return false;
            if(key.Contains("'")) return false;
            if (key.Length == 0) return false;
            return true;
        }
        public static string GetValue(string key)
        {
            string res = string.Empty;
            if (connectionString == null) return string.Empty;
            if (!CheckKey(key)) return res;
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = "select value from Settings where [Key] = @k";
                    cmd.Parameters.Add("@k", SqlDbType.NVarChar).Value = key;
                    object o = cmd.ExecuteScalar();
                    if (o is DBNull) res = null;
                    else res = Convert.ToString(o);
                }
            }
            return res + string.Empty;
        }
        public static void SetValue(string key, string value)
        {
            if (!CheckKey(key)) return;
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = "update Settings set Value = @val where [Key] = @k";
                    cmd.Parameters.Add("@k", SqlDbType.NVarChar).Value = key;
                    cmd.Parameters.Add("@val", SqlDbType.NVarChar).Value = value == null ? DBNull.Value : (object)value;
                    cmd.ExecuteNonQuery();
                }
            }

        }
        public static void AddValue(string key, string value)
        {
            if (!CheckKey(key)) return;
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = "insert into Settings ([Key],value) values (@k,@val)";
                    cmd.Parameters.Add("@k", SqlDbType.NVarChar).Value = key;
                    cmd.Parameters.Add("@val", SqlDbType.NVarChar).Value = value == null ? DBNull.Value : (object)value;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// saves value. if value not exist creating new
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SaveValue(string key, string value)
        {
            try
            {
                if (!CheckKey(key)) return;
                using (SqlCeConnection connection = new SqlCeConnection(connectionString))
                {
                    using (SqlCeCommand cmd = connection.CreateCommand())
                    {
                        connection.Open();
                        cmd.CommandText = "select count(*) from Settings where [Key] = @k";
                        cmd.Parameters.Add("@k", SqlDbType.NVarChar).Value = key;
                        int cnt = Convert.ToInt32(cmd.ExecuteScalar());
                        cmd.Parameters.Clear();
                        if (cnt > 0)
                        {
                            cmd.CommandText = "update Settings set Value = @val where [Key] = @k";
                        }
                        else
                        {

                            cmd.CommandText = "insert into Settings ([Key],value) values (@k,@val)";
                        }
                        cmd.Parameters.Add("@k", SqlDbType.NVarChar).Value = key;
                        cmd.Parameters.Add("@val", SqlDbType.NVarChar).Value = value == null ? DBNull.Value : (object)value;
                        cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        /// <summary>
        /// returns count of keys
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int CheckValue(string key)
        {
            if (!CheckKey(key)) return -1;
            using (SqlCeConnection connection = new SqlCeConnection(connectionString))
            {
                using (SqlCeCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = "select count(*) from Settings where [Key] = @k";
                    cmd.Parameters.Add("@k", SqlDbType.NVarChar).Value = key;
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

    }
}
