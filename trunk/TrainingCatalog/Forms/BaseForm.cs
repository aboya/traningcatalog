using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrainingCatalog.Forms
{
    public class BaseForm : System.Windows.Forms.Form
    {
        public bool IsShown
        {
            get;
            set;
        }

        public BaseForm()
        {
            IsShown = false;
            this.Icon = AppResources.AppResources.dumbbells;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseForm_FormClosing);
            this.Load += new System.EventHandler(this.BaseForm_Load);
            this.Shown += new System.EventHandler(this.Form_Shown);
            
        }
        private void Form_Shown(object sender, EventArgs e)
        {
            IsShown = true;
        }
        private void BaseForm_Load(object sender, EventArgs e)
        {
            Form mainForm = Application.OpenForms["mainForm"];
            if (mainForm != null)
                this.Location = mainForm.Location;
            
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "BaseForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseForm_FormClosing);
            this.ResumeLayout(false);

        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Name != "mainForm")
            {
                Form mainForm = Application.OpenForms["mainForm"];
                if (mainForm != null)
                    mainForm.Focus();
            }
        }

        
    }
}
