using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingCatalog.Forms
{
    public class BaseForm : System.Windows.Forms.Form
    {
      
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "BaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }
    }
}
