using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TrainingCatalog.Controls
{
    public class BaseTextBox : System.Windows.Forms.TextBox
    {
        private string _text = string.Empty;
        private string _NullableText = string.Empty;
        private bool IsTextNullable;
        public string NullableText
        {
            get {
                return _NullableText;
            }
            set {
                if (value == null) value = string.Empty;
                _NullableText = value;
                if (IsTextNullable)
                {
                    SetNullableText();
                    base.Text = value;
                }
            }
        }
        public BaseTextBox()
        {
            this.Enter += new System.EventHandler(this.OnEnter);
            this.Leave += new System.EventHandler(this.OnLeave);
            this.IsTextNullable = true;
            SetNullableText();
        }

        private void OnEnter(object sender, EventArgs e)
        {
            if (IsTextNullable)
            {
                ClearNullableText();
                base.Text = string.Empty;
            }
        }

        private void OnLeave(object sender, EventArgs e)
        {
            string txt = base.Text.Trim();
            if (string.IsNullOrEmpty(txt))
            {
                SetNullableText();
                base.Text = this.NullableText;
            }
        }
        private void SetNullableText()
        {
            IsTextNullable = true;
            this.ForeColor = Color.Gray;
 
        }
        private void ClearNullableText()
        {
            IsTextNullable = false;
            this.ForeColor = Color.Black;
        }
        public override string Text
        {
            get
            {
                if (IsTextNullable) return string.Empty;
                return base.Text;
            }
            set
            {
                if(value == null) value = string.Empty;
                if (value.Trim().Length == 0)
                {
                    SetNullableText();
                    base.Text = this.NullableText;
                }
                else
                {
                    ClearNullableText();
                    base.Text = value;
                }
                this._text = value;
                
            }
        }
    }
}
