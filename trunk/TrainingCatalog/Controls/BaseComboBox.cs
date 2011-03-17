using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingCatalog.Controls
{
    public class BaseComboBox : System.Windows.Forms.ComboBox
    {
        public BaseComboBox()
        {
            this.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        }
    }
}
