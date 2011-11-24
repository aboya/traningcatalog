namespace TrainingCatalog.Forms
{
    partial class CardioResults
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
            this.mainGraphControl = new ZedGraph.ZedGraphControl();
            this.bntClear = new TrainingCatalog.Controls.BaseButton();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.TrainingList = new TrainingCatalog.Controls.BaseComboBox();
            this.cbType = new TrainingCatalog.Controls.BaseComboBox();
            this.btnOptions = new TrainingCatalog.Controls.BaseButton();
            this.SuspendLayout();
            // 
            // mainGraphControl
            // 
            this.mainGraphControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainGraphControl.Location = new System.Drawing.Point(9, 38);
            this.mainGraphControl.Name = "mainGraphControl";
            this.mainGraphControl.ScrollGrace = 0D;
            this.mainGraphControl.ScrollMaxX = 0D;
            this.mainGraphControl.ScrollMaxY = 0D;
            this.mainGraphControl.ScrollMaxY2 = 0D;
            this.mainGraphControl.ScrollMinX = 0D;
            this.mainGraphControl.ScrollMinY = 0D;
            this.mainGraphControl.ScrollMinY2 = 0D;
            this.mainGraphControl.Size = new System.Drawing.Size(593, 345);
            this.mainGraphControl.TabIndex = 1;
            // 
            // bntClear
            // 
            this.bntClear.Location = new System.Drawing.Point(301, 12);
            this.bntClear.Name = "bntClear";
            this.bntClear.Size = new System.Drawing.Size(36, 20);
            this.bntClear.TabIndex = 12;
            this.bntClear.Text = "C";
            this.bntClear.UseVisualStyleBackColor = true;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(153, 12);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(142, 20);
            this.dtpTo.TabIndex = 11;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(9, 12);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(138, 20);
            this.dtpFrom.TabIndex = 10;
            // 
            // TrainingList
            // 
            this.TrainingList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TrainingList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TrainingList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TrainingList.FormattingEnabled = true;
            this.TrainingList.Location = new System.Drawing.Point(144, 389);
            this.TrainingList.Name = "TrainingList";
            this.TrainingList.Size = new System.Drawing.Size(458, 21);
            this.TrainingList.TabIndex = 13;
            // 
            // cbType
            // 
            this.cbType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Speed",
            "Time",
            "Distance"});
            this.cbType.Location = new System.Drawing.Point(12, 389);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(126, 21);
            this.cbType.TabIndex = 14;
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(343, 12);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(69, 20);
            this.btnOptions.TabIndex = 15;
            this.btnOptions.Text = "Options";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // CardioResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 422);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.TrainingList);
            this.Controls.Add(this.bntClear);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.mainGraphControl);
            this.IsShown = true;
            this.Name = "CardioResults";
            this.Text = "CardioResults";
            this.Load += new System.EventHandler(this.CardioResults_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl mainGraphControl;
        private Controls.BaseButton bntClear;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private Controls.BaseComboBox TrainingList;
        private Controls.BaseComboBox cbType;
        private Controls.BaseButton btnOptions;
    }
}