namespace TrainingCatalog
{
    partial class Perfomance
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
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.TrainingList = new System.Windows.Forms.ComboBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.bntClear = new System.Windows.Forms.Button();
            this.chkWeighCount = new System.Windows.Forms.CheckBox();
            this.chkBodyWeight = new System.Windows.Forms.CheckBox();
            this.chkWeight = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 36);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(328, 208);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // TrainingList
            // 
            this.TrainingList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TrainingList.FormattingEnabled = true;
            this.TrainingList.Location = new System.Drawing.Point(12, 250);
            this.TrainingList.Name = "TrainingList";
            this.TrainingList.Size = new System.Drawing.Size(328, 21);
            this.TrainingList.TabIndex = 6;
            this.TrainingList.SelectedIndexChanged += new System.EventHandler(this.TrainingList_SelectedIndexChanged);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(12, 10);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(138, 20);
            this.dtpFrom.TabIndex = 7;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(156, 10);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(142, 20);
            this.dtpTo.TabIndex = 8;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // bntClear
            // 
            this.bntClear.Location = new System.Drawing.Point(304, 10);
            this.bntClear.Name = "bntClear";
            this.bntClear.Size = new System.Drawing.Size(36, 20);
            this.bntClear.TabIndex = 9;
            this.bntClear.Text = "C";
            this.bntClear.UseVisualStyleBackColor = true;
            this.bntClear.Click += new System.EventHandler(this.bntClear_Click);
            // 
            // chkWeighCount
            // 
            this.chkWeighCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkWeighCount.AutoSize = true;
            this.chkWeighCount.Checked = true;
            this.chkWeighCount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWeighCount.Location = new System.Drawing.Point(347, 54);
            this.chkWeighCount.Name = "chkWeighCount";
            this.chkWeighCount.Size = new System.Drawing.Size(110, 17);
            this.chkWeighCount.TabIndex = 10;
            this.chkWeighCount.Text = "Вес*Повторения";
            this.chkWeighCount.UseVisualStyleBackColor = true;
            this.chkWeighCount.CheckedChanged += new System.EventHandler(this.chkWeighCount_CheckedChanged);
            // 
            // chkBodyWeight
            // 
            this.chkBodyWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBodyWeight.AutoSize = true;
            this.chkBodyWeight.Checked = true;
            this.chkBodyWeight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBodyWeight.Location = new System.Drawing.Point(347, 100);
            this.chkBodyWeight.Name = "chkBodyWeight";
            this.chkBodyWeight.Size = new System.Drawing.Size(73, 17);
            this.chkBodyWeight.TabIndex = 11;
            this.chkBodyWeight.Text = "Вес Тела";
            this.chkBodyWeight.UseVisualStyleBackColor = true;
            this.chkBodyWeight.CheckedChanged += new System.EventHandler(this.chkBodyWeight_CheckedChanged);
            // 
            // chkWeight
            // 
            this.chkWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkWeight.AutoSize = true;
            this.chkWeight.Checked = true;
            this.chkWeight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWeight.Location = new System.Drawing.Point(347, 77);
            this.chkWeight.Name = "chkWeight";
            this.chkWeight.Size = new System.Drawing.Size(45, 17);
            this.chkWeight.TabIndex = 12;
            this.chkWeight.Text = "Вес";
            this.chkWeight.UseVisualStyleBackColor = true;
            this.chkWeight.CheckedChanged += new System.EventHandler(this.chkWeight_CheckedChanged);
            // 
            // Perfomance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 279);
            this.Controls.Add(this.chkWeight);
            this.Controls.Add(this.chkBodyWeight);
            this.Controls.Add(this.chkWeighCount);
            this.Controls.Add(this.bntClear);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.TrainingList);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "Perfomance";
            this.Text = "Perfomance";
            this.Load += new System.EventHandler(this.Perfomance_Load);
            this.Resize += new System.EventHandler(this.Perfomance_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ComboBox TrainingList;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button bntClear;
        private System.Windows.Forms.CheckBox chkWeighCount;
        private System.Windows.Forms.CheckBox chkBodyWeight;
        private System.Windows.Forms.CheckBox chkWeight;
    }
}