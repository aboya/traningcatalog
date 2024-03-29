﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrainingCatalog.Controls
{
    class PostiveIntegerTextBox : BaseTextBox
    {
        public PostiveIntegerTextBox()
        {
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Event);
        }
        private void KeyDown_Event(object sender, KeyEventArgs e)
        {
            //8-backspace
            // 46 - delete
            // 37 - left arrow
            // 39 - right arrow
            // 188 - comma
            // 190 - point

            if (e.KeyValue != 8 && e.KeyValue != 46 && e.KeyValue != 37 && e.KeyValue != 39)
            {
                if (e.KeyValue < '0' || e.KeyValue > '9') e.SuppressKeyPress = true;
                if (e.KeyValue >= 96 && e.KeyValue <= 105) e.SuppressKeyPress = false;
            }
            //  CultureInfo.InstalledUICulture.NumberFormat.CurrencyDecimalSeparator = ",";
            //  CultureInfo.InstalledUICulture.NumberFormat.CurrencyDecimalSeparator
        }
    }
}
