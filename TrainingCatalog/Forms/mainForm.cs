using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrainingCatalog.Forms;

namespace TrainingCatalog
{
    public partial class mainForm : BaseForm
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Training().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ExersizeForm().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Perfomance().Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new ExersizesList().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            new Report().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Templates().Show();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            new Statistics().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new DayComment().Show();
        }
    }
}
