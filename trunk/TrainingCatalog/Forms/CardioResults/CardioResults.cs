using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TrainingCatalog.BusinessLogic;

namespace TrainingCatalog.Forms
{
    public partial class CardioResults : BaseForm
    {
        public CardioResults()
        {
            InitializeComponent();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            new CardioResultsOptions().ShowDialog();
        }

        private void CardioResults_Load(object sender, EventArgs e)
        {
            cbType.SelectedIndex = 0;
         //   TrainingBusiness.GetCardioResults();
        }
    }
}
