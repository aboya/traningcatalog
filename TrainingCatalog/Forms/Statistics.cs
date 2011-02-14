using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrainingCatalog.Forms
{
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
            lstParams.FullRowSelect = true;
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            string [] arr = new string[4];
            arr[0] = "1";
            arr[1] = "2";
            arr[2] = "3";
            arr[3] = "4";
            ListViewItem i = new ListViewItem(arr);
            lstParams.Items.Add(i);
        }

    }
}
