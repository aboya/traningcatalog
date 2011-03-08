using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TrainingCatalog.BusinessLogic;

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
            TrainingBusiness.UpdateBase();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            Application.Run(new mainForm());
        }
        private static void OnApplicationExit(object sender, EventArgs e)
        {
            try
            {
                // Ignore any errors that might occur while closing the file handle.
                 
            }
            catch { }
        }
    }
}
