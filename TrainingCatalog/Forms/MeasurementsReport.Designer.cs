namespace TrainingCatalog.Forms
{
    partial class MeasurementsReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbBodyPart = new TrainingCatalog.Controls.BaseComboBox();
            this.bntClear = new TrainingCatalog.Controls.BaseButton();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.mainGraphControl = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // cbBodyPart
            // 
            this.cbBodyPart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBodyPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBodyPart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbBodyPart.FormattingEnabled = true;
            this.cbBodyPart.Location = new System.Drawing.Point(12, 322);
            this.cbBodyPart.Name = "cbBodyPart";
            this.cbBodyPart.Size = new System.Drawing.Size(460, 21);
            this.cbBodyPart.TabIndex = 21;
            this.cbBodyPart.SelectionChangeCommitted += new System.EventHandler(this.cbBodyPart_SelectionChangeCommitted);
            // 
            // bntClear
            // 
            this.bntClear.Location = new System.Drawing.Point(304, 6);
            this.bntClear.Name = "bntClear";
            this.bntClear.Size = new System.Drawing.Size(36, 20);
            this.bntClear.TabIndex = 20;
            this.bntClear.Text = "C";
            this.bntClear.UseVisualStyleBackColor = true;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(156, 6);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(142, 20);
            this.dtpTo.TabIndex = 19;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(12, 6);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(138, 20);
            this.dtpFrom.TabIndex = 18;
            // 
            // mainGraphControl
            // 
            this.mainGraphControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainGraphControl.Location = new System.Drawing.Point(12, 34);
            this.mainGraphControl.Name = "mainGraphControl";
            this.mainGraphControl.ScrollGrace = 0D;
            this.mainGraphControl.ScrollMaxX = 0D;
            this.mainGraphControl.ScrollMaxY = 0D;
            this.mainGraphControl.ScrollMaxY2 = 0D;
            this.mainGraphControl.ScrollMinX = 0D;
            this.mainGraphControl.ScrollMinY = 0D;
            this.mainGraphControl.ScrollMinY2 = 0D;
            this.mainGraphControl.Size = new System.Drawing.Size(460, 282);
            this.mainGraphControl.TabIndex = 17;
            // 
            // MeasurementsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 355);
            this.Controls.Add(this.cbBodyPart);
            this.Controls.Add(this.bntClear);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.mainGraphControl);
            this.IsShown = true;
            this.Name = "MeasurementsReport";
            this.Text = "MeasurementsReport";
            this.Load += new System.EventHandler(this.MeasurementsReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.BaseComboBox cbBodyPart;
        private Controls.BaseButton bntClear;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private ZedGraph.ZedGraphControl mainGraphControl;
    }
}