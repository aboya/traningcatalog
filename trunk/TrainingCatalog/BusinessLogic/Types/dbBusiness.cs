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
        public static object GetObject(SqlCeCommand cmd, object o)
        {

            return new object();
        }
        public static void UpdateBase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            string path = Application.StartupPath + "\\" + ConfigurationManager.AppSettings["databasePath"];

            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.NumberDecimalSeparator = "_";
            try
            {
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
                                cmd.CommandText = "insert into version_info (version) values(3)";
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                List<double> versions = GetVersionProperties(connectionString);
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

        public static List<double> GetVersionProperties(string connectionString)
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


    }
}
