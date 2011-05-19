using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using TrainingCatalog.BusinessLogic.Enums;
using System.ComponentModel;
using System.Globalization;

namespace TrainingCatalog.Controls
{
    public class CardioDataGridView : System.Windows.Forms.DataGridView
    {
        public delegate void CustomCellValueChanged(DataGridViewCell lastEditCell);
        public event CustomCellValueChanged OnDurationChanged;
        public event CustomCellValueChanged OnVelocityChanged;
        public event CustomCellValueChanged OnDistanceChanged;
        DataGridViewCell _lastEditedCell;
        DataGridViewCell lastEditedCell
        {
            get
            {
                return _lastEditedCell;
            }
            set
            {
                _lastEditedCell = value;
            }
        }
        private bool []ColumnChanged = new bool [7];

        public CardioDataGridView()
        {
            this.CellClick += new DataGridViewCellEventHandler(CellEvent);
            this.CellEnter += new DataGridViewCellEventHandler(CellEvent);
            lastEditedCell = this.CurrentCell;
        }
        // эта хрень вызывается когда просто в момент выделения юзвер давит на кнопку
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                MyProcessDataGridViewKey(Keys.Tab);
                return true;
            }
            return base.ProcessDataGridViewKey(e);
        }
        private void CellEvent(object sender, DataGridViewCellEventArgs e)
        {
            RaiseChangedEvents(); 
        }
        protected bool MyProcessDataGridViewKey(Keys keyData)
        {
            bool retValue = true; // base.ProcessTabKey(Keys.Tab);
            if ((this.CurrentCell is DataGridViewTextBoxCell))
            {
                this.CurrentCell = GetNextEditTextBox();
            }
            return retValue;
        }
        // эта хрень вызывается когда во время редактирования юзверь давит кнопку
        protected override bool ProcessDialogKey(Keys keyData)
        {

            if (keyData == Keys.Tab || keyData == Keys.Enter)
            {
                MyProcessDialogKey(keyData);
                return true;
            }
               
            return base.ProcessDialogKey(keyData);
            
        }
        protected bool MyProcessDialogKey(Keys keyData)
        {
            bool retValue = true;// base.ProcessDialogKey(Keys.Tab);
            if ((this.CurrentCell is DataGridViewTextBoxCell))
            {
                this.CurrentCell = GetNextEditTextBox();
            }
            return retValue;
        }
        private DataGridViewCell GetNextEditTextBox()
        {
            int rowIndex = this.CurrentCell.RowIndex;
            int colIndex = this.CurrentCell.ColumnIndex;
           // RaiseChangedEvents();

            colIndex++;
            if (colIndex >= this.Columns.Count)
            {
                colIndex = 1;
                rowIndex++;
            }
            if (colIndex == 0) colIndex++;
            if (rowIndex >= this.Rows.Count) rowIndex = 0;
            return this.Rows[rowIndex].Cells[colIndex];
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //hook pressing keys on grid
          //  Debug.WriteLine((int)keyData);
            
            if (keyData == Keys.Oemcomma || (int)keyData == 65727 /*rus comma*/)
            {
                string s = (this.CurrentCell.EditedFormattedValue as string);
                if (s.Contains(CultureInfo.InstalledUICulture.NumberFormat.CurrencyDecimalSeparator )) return true;
            }
            if (keyData == Keys.Tab || keyData == Keys.Enter || keyData == Keys.Back
                || keyData == Keys.Left || keyData == Keys.Right || keyData == Keys.Oemcomma 
                || (int)keyData == 65727 /*ru comma*/ || keyData == Keys.Delete || keyData == Keys.Up || keyData == Keys.Down)
            {
                string s = (this.CurrentCell.EditedFormattedValue as string);
                if (s == null || s.Trim().Length == 0) this.CurrentCell.Value = 0;
                ColumnChanged[this.CurrentCell.ColumnIndex] = true;
                this.lastEditedCell = this.CurrentCell;
                return base.ProcessCmdKey(ref msg, keyData);
            }
            if (!((int)keyData >= 96 && (int)keyData <= 105 || (int)keyData >= 48 && (int)keyData <= 57))
            {
                ColumnChanged[this.CurrentCell.ColumnIndex] = false;
                return true;
            }

            ColumnChanged[this.CurrentCell.ColumnIndex] = true;
            this.lastEditedCell = this.CurrentCell;
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void RaiseChangedEvents()
        {
            if (lastEditedCell == null || lastEditedCell.RowIndex < 0) return;
            if (ColumnChanged[CardioGridEnum.Time] && OnDurationChanged != null)
            {
                OnDurationChanged(lastEditedCell);
                ColumnChanged[CardioGridEnum.Time] = false;
            }
            if (ColumnChanged[CardioGridEnum.Velocity] && OnVelocityChanged != null)
            {
                OnVelocityChanged(lastEditedCell);
                ColumnChanged[CardioGridEnum.Velocity] = false;
            }
            if (ColumnChanged[CardioGridEnum.Distance] && OnDistanceChanged != null)
            {
                OnDistanceChanged(lastEditedCell);
                ColumnChanged[CardioGridEnum.Distance] = false;
            }

        }
    }
}
