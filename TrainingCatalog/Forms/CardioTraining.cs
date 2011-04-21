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
            chkGraph_CheckedChanged(null, null);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new CardioSession(0).ShowDialog(this);
        }

        private void chkGraph_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGraph.Checked)
            {
                zedGraphControl.Visible = true;
                this.MinimumSize = new System.Drawing.Size(465, 426);
                this.MaximumSize = new Size(0, 0);
            }
            else
            {
                zedGraphControl.Visible = false;
                this.MaximumSize = this.MinimumSize = new System.Drawing.Size(465, 228);
            }
        }

    }
}
