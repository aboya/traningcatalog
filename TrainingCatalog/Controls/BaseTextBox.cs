using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingCatalog.Controls
{
    public class BaseTextBox : System.Windows.Forms.TextBox
    {
        public BaseTextBox()
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }
    }
}
