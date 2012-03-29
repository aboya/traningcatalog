using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace TrainingCatalog.Controls
{
    public class FloatNumberTextBox : BaseTextBox
    {
        public FloatNumberTextBox()
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

            if (e.KeyValue != 8 && e.KeyValue != 46 && e.KeyValue != 37 && e.KeyValue != 39 && e.KeyValue != 188 && e.KeyValue != 190)
            {
                if (e.KeyValue < '0' || e.KeyValue > '9') e.SuppressKeyPress = true;
                if (e.KeyValue >= 96 && e.KeyValue <= 105) e.SuppressKeyPress = false;
            }
          //  CultureInfo.InstalledUICulture.NumberFormat.CurrencyDecimalSeparator = ",";
          //  CultureInfo.InstalledUICulture.NumberFormat.CurrencyDecimalSeparator
        }
        public override string Text
        {
            get
            {
                if (base.Text != null)
                    return base.Text.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator).
                                     Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                return null;
            }
            set
            {
              //  if (value != null) value = value.Replace(".",CultureInfo.InstalledUICulture.NumberFormat.CurrencyDecimalSeparator).Replace(",",CultureInfo.InstalledUICulture.NumberFormat.CurrencyDecimalSeparator);
                base.Text = value;
            }
        }


    }
}
