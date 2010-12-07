using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using System.Data.OleDb;
using System.Configuration;
namespace TrainingCatalog
{
    public partial class Perfomance : Form
    {
        OleDbConnection connection;
        OleDbDataAdapter table = new OleDbDataAdapter();
        DataSet Exersizes = new DataSet();
        protected DateTime MinDateTime;
        protected DateTime MaxDateTime;
        public Perfomance()
        {
            InitializeComponent();
        }

        private void Perfomance_Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            this.MinimumSize = new Size(475, 319);
 
            ExersizeLoad();
            CreateGraph(zedGraphControl1);

        }
        private void SetSize()
        {
            zedGraphControl1.Location = new Point(10, 36);
            // Leave a small margin around the outside of the control

            zedGraphControl1.Size = new Size(ClientRectangle.Width - 20,
                                    ClientRectangle.Height - 65);
        }
        private void CreateGraph(ZedGraphControl zgc)
        {
            // get a reference to the GraphPane
           
            try
            {
                int ExersizeId = (int)Exersizes.Tables[0].Rows[TrainingList.SelectedIndex]["ExersizeID"];
                connection.Open();
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText =
                        String.Format("select Day,Weight,Count,BodyWeight from Link " +
                                      "inner join Training on Training.ID = Link.TrainingID " +
                                      "where ExersizeID = {0} " +
                                      "and Day between DateValue(\"{1}\") and  DateValue(\"{2}\") " +
                                      "order by Day, Weight * Count", ExersizeId, dtpFrom.Value.ToString("dd/MM/yyyy"),
                                                                    dtpTo.Value.ToString("dd/MM/yyyy"));
                    OleDbDataReader reader = cmd.ExecuteReader();
                    GraphPane myPane = zgc.GraphPane;
                    myPane.XAxis.Type = AxisType.Date;
                    // Set the Titles

                    myPane.Title.Text = "Perfomance";
                    myPane.XAxis.Title.Text = "Date";
                    myPane.YAxis.Title.Text = "Weight";

                    // Make up some data arrays based on the Sine function

                    //double x, y1, y2;
                    PointPairList pointWeightCount = new PointPairList();
                    PointPairList pointBodyWeight = new PointPairList();
                    PointPairList pointWeight = new PointPairList();
                    while (reader.Read())
                    {
                        DateTime t;
                        t = (DateTime)reader["Day"];
                        if (chkWeighCount.Checked)
                        {
                            pointWeightCount.Add(t.ToOADate(), (int)reader["Weight"] * (int)reader["Count"]);
                        }
                        if (chkBodyWeight.Checked)
                        {
                            if (!(reader["BodyWeight"] is DBNull || Convert.ToInt32(reader["BodyWeight"])==0)) 
                                pointBodyWeight.Add(t.ToOADate(), Convert.ToDouble(reader["BodyWeight"]));
                        }
                        if (chkWeight.Checked)
                        {
                            pointWeightCount.Add(t.ToOADate(), (int)reader["Weight"]);
                        }
                    }

                    // Generate a red curve with diamond

                    // symbols, and "Porsche" in the legend
                    myPane.CurveList.Clear();
                    LineItem myCurve = myPane.AddCurve("Weight * Count",
                          pointWeightCount, Color.Red, SymbolType.Circle);


                    // Generate a blue curve with circle

                    // symbols, and "Piper" in the legend

                    LineItem myCurve2 = myPane.AddCurve("BodyWeight",
                         pointBodyWeight, Color.Blue, SymbolType.Circle);


                    myPane.AddCurve("Weight", pointWeight, Color.Brown, SymbolType.Circle);
                    // Tell ZedGraph to refigure the

                    // axes since the data have changed


                    zgc.AxisChange();
                    zgc.Refresh();
                }

                //zgc.Refresh();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void Perfomance_Resize(object sender, EventArgs e)
        {
            //SetSize();
            //TrainingList.Top = this.Height - 65;
        }
        public void ExersizeLoad()
        {
            try
            {
                connection.Open();
                using (OleDbCommand cmd = new OleDbCommand("select * from Exersize order by ShortName", connection))
                {
                    // fill exersizes
                    cmd.Connection = connection;
                    table.SelectCommand = cmd;

                    table.Fill(Exersizes);
                    for (int i = 0; i < Exersizes.Tables[0].Rows.Count; i++)
                    {
                        TrainingList.Items.Add(Exersizes.Tables[0].Rows[i]["ShortName"]);
                    }


                    TrainingList.DropDownStyle = ComboBoxStyle.DropDownList;

                    // get min and max datevalue for datetime 
                    cmd.CommandText = "select max(Day) from Training";
                    MaxDateTime = Convert.ToDateTime(cmd.ExecuteScalar());
                    cmd.CommandText = "select min(Day) from Training";
                    MinDateTime = Convert.ToDateTime(cmd.ExecuteScalar());
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            finally
            {
                connection.Close();
            }
            TrainingList.SelectedIndex = 0;
            dtpFrom.Value = MinDateTime;
            dtpTo.Value = MaxDateTime;
        }

        private void TrainingList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateGraph(zedGraphControl1);
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value < MinDateTime) dtpFrom.Value = MinDateTime;
            CreateGraph(zedGraphControl1);

        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            if (dtpTo.Value > MaxDateTime) dtpTo.Value = MaxDateTime;
            CreateGraph(zedGraphControl1);
        }

        private void bntClear_Click(object sender, EventArgs e)
        {
            dtpTo.Value = MaxDateTime;
            dtpFrom.Value = MinDateTime;
        }

        private void chkBodyWeight_CheckedChanged(object sender, EventArgs e)
        {
            CreateGraph(zedGraphControl1);
        }

        private void chkWeighCount_CheckedChanged(object sender, EventArgs e)
        {
            CreateGraph(zedGraphControl1);
        }

        private void chkWeight_CheckedChanged(object sender, EventArgs e)
        {
            CreateGraph(zedGraphControl1);
        }

    }
}
