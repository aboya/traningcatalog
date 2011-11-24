using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TrainingCatalog.Controls
{
    public class CustomDataGridView : DataGridView
    {
        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;

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
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                // If the mouse moves outside the rectangle, start the drag.
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    // Proceed with the drag and drop, passing in the list item.                    
                    DragDropEffects dropEffect = this.DoDragDrop(
                    this.Rows[rowIndexFromMouseDown],
                    DragDropEffects.Move);
                }
            }
            base.OnMouseMove(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = this.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                // Remember the point where the mouse down occurred. 
                // The DragSize indicates the size that the mouse can move 
                // before a drag event should be started.                
                Size dragSize = SystemInformation.DragSize;
                // Create a rectangle using the DragSize, with the mouse position being
                // at the center of the rectangle.
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                e.Y - (dragSize.Height / 2)),
                dragSize);
            }
            else
            {
                // Reset the rectangle if the mouse is not over an item in the ListBox.
                dragBoxFromMouseDown = Rectangle.Empty;
            }

            base.OnMouseDown(e);
        }
        protected override void OnDragOver(DragEventArgs drgevent)
        {
            drgevent.Effect = DragDropEffects.Move;
            base.OnDragOver(drgevent);
        }

        protected override void OnDragDrop(DragEventArgs e)
        {
            // The mouse locations are relative to the screen, so they must be 
            // converted to client coordinates.
            Point clientPoint = this.PointToClient(new Point(e.X, e.Y));
            // Get the row index of the item the mouse is below. 
            rowIndexOfItemUnderMouseToDrop =
            this.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move)
            {
                DataGridViewRow rowToMove = e.Data.GetData(
                typeof(DataGridViewRow)) as DataGridViewRow;
                this.Rows.RemoveAt(rowIndexFromMouseDown);
                this.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);
            }
            base.OnDragDrop(e);
        }
        
        
    }
}
