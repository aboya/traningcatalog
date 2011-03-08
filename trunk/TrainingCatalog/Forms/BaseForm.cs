using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrainingCatalog.Forms
{
    public class BaseForm : System.Windows.Forms.Form
    {
        

        public BaseForm()
        {
            this.Icon = AppResources.AppResources.dumbbells;

            this.Load += new System.EventHandler(this.BaseForm_Load);
        }
        private void BaseForm_Load(object sender, EventArgs e)
        {
            Form mainForm = Application.OpenForms["mainForm"];
            if (mainForm != null)
                this.Location = mainForm.Location;
        }

        
    }
}
