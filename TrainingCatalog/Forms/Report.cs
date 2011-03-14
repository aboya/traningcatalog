using System;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.IO;
using System.Configuration;
using TrainingCatalog.Forms;
using TrainingCatalog.BusinessLogic;


namespace TrainingCatalog
{
    public partial class Report : BaseForm
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
                        connection.Open();
                        using (SqlCeCommand cmd = connection.CreateCommand())
                        {
                            _minDateTime = TrainingBusiness.GetStartTrainingDay(cmd);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        _minDateTime = DateTime.Today;
                    }
                    finally
                    {
                        connection.Close();
                    }
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

        private SqlCeConnection _connection;
        protected SqlCeConnection connection
        {
            get
            {
                if (_connection == null)
                {
                    try
                    {
                        _connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
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
            System.Windows.Forms.Application.DoEvents();
            try
            {
                
                DateTime start = dtpStart.Value;
                DateTime end = dtpEnd.Value;
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel CSV File|*.csv";
                    if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string path = saveFileDialog.FileName;
                        GenerateReport(path, start, end);
                        MessageBox.Show("Отчет Создан");
                    }
                }

                
                pbProgress.Value = 0;
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
                using (SqlCeConnection connection = new SqlCeConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString))
                {
                    connection.Open();
                    using (SqlCeCommand command = new SqlCeCommand())
                    {
                        command.Connection = connection;
                        command.Parameters.Add("@start", System.Data.SqlDbType.DateTime).Value = start.Date;
                        command.Parameters.Add("@end", System.Data.SqlDbType.DateTime).Value = end.Date;
                        command.CommandText = @"select count(Day) from Training " +
                                                "where Day between @start and  @end ";

                        pbProgress.Maximum = Convert.ToInt32(command.ExecuteScalar());
                        pbProgress.Minimum = 0;
                        command.CommandText =
                                      "select Day,Weight,Count,BodyWeight,Exersize.ShortName, Exersize.ID as ExersizeID from (( Link " +
                                      "inner join Training on Training.ID = Link.TrainingID) " +
                                      "inner join Exersize on Exersize.ID = Link.ExersizeID ) " +
                                      "where  " +
                                      "Day between @start and  @end " +
                                      "order by Day asc";

                        using (SqlCeDataReader dr = command.ExecuteReader())
                        {
                            DateTime lastDate = DateTime.MinValue;
                            DateTime currentDate = DateTime.MinValue;
                            ReportDayType reportDay = null;
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
                                         pbProgress.Value++;
                                         System.Windows.Forms.Application.DoEvents();
                                    }
                                    reportDay = new ReportDayType(currentDate, bodyWeight);
                                }
                                ReportExersizeType exersize = new ReportExersizeType(Convert.ToInt32(dr["ExersizeID"]),Convert.ToString(dr["ShortName"]), Convert.ToInt32(dr["Count"]), Convert.ToInt32(dr["Weight"]));
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
        private void WriteDayToStream(StreamWriter sw, ReportDayType day)
        {
            //Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();

            //xla.Visible = true;
            //Workbook wb = xla.Workbooks.Add(XlSheetType.xlWorksheet);
            //Worksheet ws = (Worksheet)xla.ActiveSheet;
            //ws.Cells[0, 2] = "234";
            

        }


    }
}
