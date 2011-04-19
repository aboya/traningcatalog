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
    public partial class CardioTraining : BaseForm
    {
        public CardioTraining()
        {
            InitializeComponent();
        }

        private void baseButton1_Click(object sender, EventArgs e)
        {
            new CardioSession().Show();
            //new CardioSession().ShowDialog(this);
        }

    }
}
