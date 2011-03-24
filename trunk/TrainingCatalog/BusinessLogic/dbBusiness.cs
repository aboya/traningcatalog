using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                if (_connstring == null) _connstring = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
                return _connstring;
            }
        }
        public static object GetObject(SqlCeCommand cmd, object o)
        {

            return new object();
        }
        public static void UpdateBase()
        {
           // string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            string path = Application.StartupPath + "\\" + ConfigurationManager.AppSettings["databasePath"];

            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.NumberDecimalSeparator = "_";
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
                        backupPath = path + "." + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss_fff");
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
                                string sql = TrainingCatalog.AppResources.SqlUpdate.ResourceManager.GetString("v"+version.ToString(nfi));
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
                    string key = "LastShrinkDate";
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
            List<string> res = new List<string>();
            List<double> versions = new List<double>();
            double v;
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.NumberDecimalSeparator = "_";
            nfi.PositiveSign = "v";
            foreach (PropertyInfo field in typeof(TrainingCatalog.AppResources.SqlUpdate).GetProperties())
            {
                if (double.TryParse(field.Name, NumberStyles.Float, nfi, out v))
                {
                    if (v > currentVersion)
                    {
                        versions.Add(v);
                    }
                }

            }
            
            versions.Sort();
            return versions;
        }
        private static bool CheckKey(string key)
        {
            if (key == null) return false;
            if(key.Contains('\'')) return false;
            if (key.Length == 0) return false;
            return true;
        }
        public static string GetValue(string key)
        {
            string res = string.Empty;
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
            return res;
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
