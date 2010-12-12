using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;

namespace TrainingCatalog
{
    public partial class EditTemplate : Form
    {

        public EditTemplate()
        {
            InitializeComponent();
            templateViewerControl1.IsNewTemplate = true;
        }

        private void btnAddExersize_Click(object sender, EventArgs e)
        {
            templateViewerControl1.AddNewRow();
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }

        private void EditTemplate_Load(object sender, EventArgs e)
        {
            
        }
    }
}
