using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrainingCatalog.Controls
{
    public class CustomDataGridView : DataGridView
    {
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                MyProcessDataGridViewKey(Keys.Tab);
                return true;
            }
            return base.ProcessDataGridViewKey(e);
        }
        protected bool MyProcessDataGridViewKey(Keys keyData)
        {
            bool retValue = true;// base.ProcessTabKey(Keys.Tab);
            if (!(this.CurrentCell is DataGridViewTextBoxCell))
            {
                this.CurrentCell = GetNextEditTextBox(); 
            }
            return retValue;
        }
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
            bool retValue = base.ProcessDialogKey(Keys.Tab);
            if (!(this.CurrentCell is DataGridViewTextBoxCell))
            {
                this.CurrentCell = GetNextEditTextBox();
            }
            return retValue;
        }
        private DataGridViewCell GetNextEditTextBox()
        {
            int rowIndex = this.CurrentCell.RowIndex;
            int colIndex = this.CurrentCell.ColumnIndex;
            if (colIndex > 3)
            {
                colIndex = 2;
                rowIndex++;
            }
            if (rowIndex >= this.Rows.Count) rowIndex = 0;
            if (colIndex < 2) colIndex = 2;
            return this.Rows[rowIndex].Cells[colIndex];
        }
    }
}
