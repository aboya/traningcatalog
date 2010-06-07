using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

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
            dtpFrom.Value = MinDateTime;
            dtpTo.Value = MaxDateTime;
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value < MinDateTime) dtpFrom.Value = MinDateTime;
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTo.Value > MaxDateTime) dtpTo.Value = MaxDateTime;
        }
    }
}
