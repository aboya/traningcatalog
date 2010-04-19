using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrainingCatalog
{
    public partial class Form1 : Form
    {
        public Form1()
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
    }
}
