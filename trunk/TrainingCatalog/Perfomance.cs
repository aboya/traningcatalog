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
namespace TrainingCatalog
{
    public partial class Perfomance : Form
    {
        OleDbConnection connection;
        OleDbDataAdapter table = new OleDbDataAdapter();
        DataSet Exersizes = new DataSet();
        public Perfomance()
        {
            InitializeComponent();
        }

        private void Perfomance_Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database2.accdb");
            ExersizeLoad();
            CreateGraph(zedGraphControl1);
            

        }
        private void SetSize()
        {
            zedGraphControl1.Location = new Point(10, 10);
            // Leave a small margin around the outside of the control

            zedGraphControl1.Size = new Size(ClientRectangle.Width - 20,
                                    ClientRectangle.Height - 45);
        }
        private void CreateGraph(ZedGraphControl zgc)
        {
            // get a reference to the GraphPane
            int ExersizeId = (int)Exersizes.Tables[0].Rows[TrainingList.SelectedIndex]["ExersizeID"];
            try
            {
                
                connection.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = connection;
                cmd.CommandText =
                    String.Format("select Day,Weight,Count from Link inner join Training on Training.ID = Link.TrainingID where ExersizeID = {0} order by Day, Weight * Count", ExersizeId);
                OleDbDataReader reader = cmd.ExecuteReader();
                GraphPane myPane = zgc.GraphPane;
                myPane.XAxis.Type = AxisType.Date;
                // Set the Titles
                
                myPane.Title.Text = "Perfomance";
                myPane.XAxis.Title.Text = "Date";
                myPane.YAxis.Title.Text = "Weight";

                // Make up some data arrays based on the Sine function

                //double x, y1, y2;
                PointPairList list1 = new PointPairList();
                PointPairList list2 = new PointPairList();
                while(reader.Read())
                {
                    DateTime t;
                    t =  (DateTime)reader["Day"];
                    list1.Add(t.ToOADate(), (int) reader["Weight"] * (int)reader["Count"] );
                    list2.Add(t.ToOADate(), (int)reader["Weight"] * 7);
                }

                // Generate a red curve with diamond

                // symbols, and "Porsche" in the legend
                myPane.CurveList.Clear();
                LineItem myCurve = myPane.AddCurve("Weight * Count",
                      list1, Color.Red, SymbolType.Circle);


                // Generate a blue curve with circle

                // symbols, and "Piper" in the legend

                LineItem myCurve2 = myPane.AddCurve("Weight",
                     list2, Color.Blue, SymbolType.Circle);

                // Tell ZedGraph to refigure the

                // axes since the data have changed

                
                zgc.AxisChange();
                zgc.Refresh();
                
                //zgc.Refresh();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            connection.Close();
        }

        private void Perfomance_Resize(object sender, EventArgs e)
        {
            SetSize();
            TrainingList.Top = this.Height - 65;
        }
        public void ExersizeLoad()
        {
            try
            {
                connection.Open();

                OleDbCommand cmd = new OleDbCommand("select * from Exersize order by ShortName", connection);
                cmd.Connection = connection;
                //OleDbDataReader reader = cmd.ExecuteReader();

                table.SelectCommand = cmd;

                table.Fill(Exersizes);
                for (int i = 0; i < Exersizes.Tables[0].Rows.Count; i++)
                {
                    TrainingList.Items.Add(Exersizes.Tables[0].Rows[i]["ShortName"]);
                }

                
                TrainingList.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            connection.Close();
            TrainingList.SelectedIndex = 0;
        }

        private void TrainingList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CreateGraph(zedGraphControl1);
        }

    }
}
