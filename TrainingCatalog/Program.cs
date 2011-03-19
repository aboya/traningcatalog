using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TrainingCatalog.BusinessLogic;
using System.Threading;
using TrainingCatalog.BusinessLogic.Types;
using System.Configuration;

namespace TrainingCatalog
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]
        static void Main()
        {
            appGuid = appGuid.Replace("\\", "_");
            using (Mutex mutex = new Mutex(false, @"Global\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    MessageBox.Show("Training Catalog already running");
                    return;
                }
                try
                {
                    dbBusiness.UpdateBase();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Datebase Update Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ApplicationExit += new EventHandler(OnApplicationExit);
                Application.Run(new mainForm());

            }
        }
        private static void OnApplicationExit(object sender, EventArgs e)
        {
            try
            {
                // Ignore any errors that might occur while closing the file handle.
                 
            }
            catch { }
        }
        private static string appGuid = Application.StartupPath + "\\" + ConfigurationManager.AppSettings["databasePath"];

    }
}
