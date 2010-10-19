using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Office.Interop.Excel;

namespace TrainingCatalog
{
    public partial class Report : Form
    {
       
        private DateTime _minDateTime;
        protected DateTime MinDateTime
        {
            get
            {
                if (_minDateTime == DateTime.MinValue)
                {
                    try
                    {
                        using (OleDbCommand cmd = new OleDbCommand())
                        {
                            cmd.Connection = connection;
                            cmd.Connection.Open();
                            cmd.CommandText = "select min(Day) from Training";
                            _minDateTime =  Convert.ToDateTime(cmd.ExecuteScalar());
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        _minDateTime =  DateTime.Today;
                    }
                    connection.Close();
                }
                return _minDateTime;
            }
        }
        protected DateTime MaxDateTime
        {
            get
            {
                return DateTime.Today;
            }
        }

        private OleDbConnection _connection;
        protected OleDbConnection connection
        {
            get
            {
                if (_connection == null)
                {
                    try
                    {
                        _connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database2.accdb");
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message);
                    }
                }
                return _connection;
            }
        }
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            dtpStart.Value = MinDateTime;
            dtpEnd.Value = MaxDateTime;
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStart.Value < MinDateTime) dtpStart.Value = MinDateTime;
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEnd.Value > MaxDateTime) dtpEnd.Value = MaxDateTime;
        }

        private void lblReport_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime start = dtpStart.Value;
                DateTime end = dtpEnd.Value;
                string s;
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel CSV File|*.csv";
                    if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string path = saveFileDialog.FileName;
                        GenerateReport(path, start, end);
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            
        }
        private void GenerateReport(string filePath, DateTime start, DateTime end)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.Default))
            {
                using (OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
                {
                    connection.Open();
                    using (OleDbCommand command = new OleDbCommand())
                    {
                        command.Connection = connection;
                        command.CommandText =
                        String.Format("select Day,Weight,Count,BodyWeight,Exersize.ShortName, Exersize.ExersizeID from (( Link " +
                                      "inner join Training on Training.ID = Link.TrainingID) " +
                                      "inner join Exersize on Exersize.ExersizeID = Link.ExersizeID ) " +
                                      "where  " +
                                      "Day between DateValue(\"{0}\") and  DateValue(\"{1}\") " +
                                      "order by Day asc", start.ToString("dd/MM/yyyy"),
                                                                    end.ToString("dd/MM/yyyy"));
                        using (OleDbDataReader dr = command.ExecuteReader())
                        {
                            DateTime lastDate = DateTime.MinValue;
                            DateTime currentDate = DateTime.MinValue;
                            ReportDay reportDay = null;
                            double bodyWeight;
                            while (dr.Read())
                            {
                                currentDate = Convert.ToDateTime(dr["Day"]);
                                if (dr["BodyWeight"] is DBNull) bodyWeight = 0;
                                else bodyWeight = Convert.ToDouble(dr["BodyWeight"]);
                                if (currentDate != lastDate)
                                {
                                    lastDate = currentDate;
                                    if (reportDay != null)
                                    {
                                        
                                         sw.WriteLine(reportDay.ToString());
                                    }
                                    reportDay = new ReportDay(currentDate, bodyWeight);
                                }
                                ReportExersize exersize = new ReportExersize(Convert.ToInt32(dr["ExersizeID"]),Convert.ToString(dr["ShortName"]), Convert.ToInt32(dr["Count"]), Convert.ToInt32(dr["Weight"]));
                                reportDay.Add(exersize);
                            }
                            if (reportDay != null)
                            {
                                sw.WriteLine(reportDay.ToString());
                            }

                        }
                    }
                }
            }
        }
        private void WriteDayToStream(StreamWriter sw, ReportDay day)
        {
            //Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();

            //xla.Visible = true;
            //Workbook wb = xla.Workbooks.Add(XlSheetType.xlWorksheet);
            //Worksheet ws = (Worksheet)xla.ActiveSheet;
            //ws.Cells[0, 2] = "234";
            

        }


    }
}
