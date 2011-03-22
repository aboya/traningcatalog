using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingCatalog.Controls
{
    public class BaseMaskedTextBox : System.Windows.Forms.MaskedTextBox
    {
        public BaseMaskedTextBox()
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }
    }
}
