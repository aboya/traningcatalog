using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrainingCatalog.Forms;
using TrainingCatalog.BusinessLogic.Types;

namespace TrainingCatalog
{
    public partial class mainForm : BaseForm
    {
        public mainForm()
        {
            InitializeComponent();
            this.BackgroundImage = TrainingCatalog.AppResources.AppResources.kachok;
            this.BackgroundImageLayout = ImageLayout.Center;

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
            //new Statistics().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new DayComment().Show();
        }

        private void btnMeasurment_Click(object sender, EventArgs e)
        {
            new BodyMeasurements().Show();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            new Categories().Show();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F))
            {
                
                return true;
            }
            if (keyData == (Keys.Control | Keys.A))
            {
                using (about ab = new about())
                {
                    ab.ShowDialog(this);
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new CardioTraining().Show();
        }

        private void btnCardioExersizes_Click(object sender, EventArgs e)
        {
            new CardioEdit().Show();
        }

        private void btnCardioTemplates_Click(object sender, EventArgs e)
        {
            new CardioTemplateSelector().Show();
        }

        private void btnCardioResults_Click(object sender, EventArgs e)
        {
            new CardioResults().Show();
        }


    }
}
