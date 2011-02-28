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
            this.mainGraphControl = new ZedGraph.ZedGraphControl();
            this.TrainingList = new System.Windows.Forms.ComboBox();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.bntClear = new System.Windows.Forms.Button();
            this.chkWeighCount = new System.Windows.Forms.CheckBox();
            this.chkBodyWeight = new System.Windows.Forms.CheckBox();
            this.chkWeight = new System.Windows.Forms.CheckBox();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.rbWork = new System.Windows.Forms.RadioButton();
            this.rbMaxWeight = new System.Windows.Forms.RadioButton();
            this.lblFilters = new System.Windows.Forms.Label();
            this.chkTotalWork = new System.Windows.Forms.CheckBox();
            this.chkApprox = new System.Windows.Forms.CheckBox();
            this.pnlFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainGraphControl
            // 
            this.mainGraphControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainGraphControl.Location = new System.Drawing.Point(12, 36);
            this.mainGraphControl.Name = "mainGraphControl";
            this.mainGraphControl.ScrollGrace = 0D;
            this.mainGraphControl.ScrollMaxX = 0D;
            this.mainGraphControl.ScrollMaxY = 0D;
            this.mainGraphControl.ScrollMaxY2 = 0D;
            this.mainGraphControl.ScrollMinX = 0D;
            this.mainGraphControl.ScrollMinY = 0D;
            this.mainGraphControl.ScrollMinY2 = 0D;
            this.mainGraphControl.Size = new System.Drawing.Size(328, 208);
            this.mainGraphControl.TabIndex = 0;
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
            this.chkWeighCount.Location = new System.Drawing.Point(346, 36);
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
            this.chkBodyWeight.Location = new System.Drawing.Point(346, 82);
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
            this.chkWeight.Location = new System.Drawing.Point(346, 59);
            this.chkWeight.Name = "chkWeight";
            this.chkWeight.Size = new System.Drawing.Size(45, 17);
            this.chkWeight.TabIndex = 12;
            this.chkWeight.Text = "Вес";
            this.chkWeight.UseVisualStyleBackColor = true;
            this.chkWeight.CheckedChanged += new System.EventHandler(this.chkWeight_CheckedChanged);
            // 
            // pnlFilters
            // 
            this.pnlFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFilters.Controls.Add(this.rbNone);
            this.pnlFilters.Controls.Add(this.rbWork);
            this.pnlFilters.Controls.Add(this.rbMaxWeight);
            this.pnlFilters.Controls.Add(this.lblFilters);
            this.pnlFilters.Location = new System.Drawing.Point(347, 150);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(96, 94);
            this.pnlFilters.TabIndex = 13;
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Location = new System.Drawing.Point(3, 68);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(51, 17);
            this.rbNone.TabIndex = 3;
            this.rbNone.Text = "None";
            this.rbNone.UseVisualStyleBackColor = true;
            this.rbNone.CheckedChanged += new System.EventHandler(this.rbNone_CheckedChanged);
            // 
            // rbWork
            // 
            this.rbWork.AutoSize = true;
            this.rbWork.Location = new System.Drawing.Point(3, 44);
            this.rbWork.Name = "rbWork";
            this.rbWork.Size = new System.Drawing.Size(91, 17);
            this.rbWork.TabIndex = 2;
            this.rbWork.Text = "Макс Работа";
            this.rbWork.UseVisualStyleBackColor = true;
            this.rbWork.CheckedChanged += new System.EventHandler(this.rbWork_CheckedChanged);
            // 
            // rbMaxWeight
            // 
            this.rbMaxWeight.AutoSize = true;
            this.rbMaxWeight.Checked = true;
            this.rbMaxWeight.Location = new System.Drawing.Point(3, 21);
            this.rbMaxWeight.Name = "rbMaxWeight";
            this.rbMaxWeight.Size = new System.Drawing.Size(74, 17);
            this.rbMaxWeight.TabIndex = 1;
            this.rbMaxWeight.TabStop = true;
            this.rbMaxWeight.Text = "Макс Вес";
            this.rbMaxWeight.UseVisualStyleBackColor = true;
            // 
            // lblFilters
            // 
            this.lblFilters.AutoSize = true;
            this.lblFilters.Location = new System.Drawing.Point(4, 4);
            this.lblFilters.Name = "lblFilters";
            this.lblFilters.Size = new System.Drawing.Size(55, 13);
            this.lblFilters.TabIndex = 0;
            this.lblFilters.Text = "Фильтры";
            // 
            // chkTotalWork
            // 
            this.chkTotalWork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTotalWork.AutoSize = true;
            this.chkTotalWork.Location = new System.Drawing.Point(346, 127);
            this.chkTotalWork.Name = "chkTotalWork";
            this.chkTotalWork.Size = new System.Drawing.Size(99, 17);
            this.chkTotalWork.TabIndex = 14;
            this.chkTotalWork.Text = "Общая работа";
            this.chkTotalWork.UseVisualStyleBackColor = true;
            this.chkTotalWork.CheckedChanged += new System.EventHandler(this.chkTotalWork_CheckedChanged);
            // 
            // chkApprox
            // 
            this.chkApprox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkApprox.AutoSize = true;
            this.chkApprox.Location = new System.Drawing.Point(346, 104);
            this.chkApprox.Name = "chkApprox";
            this.chkApprox.Size = new System.Drawing.Size(58, 17);
            this.chkApprox.TabIndex = 15;
            this.chkApprox.Text = "approx";
            this.chkApprox.UseVisualStyleBackColor = true;
            this.chkApprox.CheckedChanged += new System.EventHandler(this.chkApprox_CheckedChanged);
            // 
            // Perfomance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 279);
            this.Controls.Add(this.chkApprox);
            this.Controls.Add(this.chkTotalWork);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.chkWeight);
            this.Controls.Add(this.chkBodyWeight);
            this.Controls.Add(this.chkWeighCount);
            this.Controls.Add(this.bntClear);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.TrainingList);
            this.Controls.Add(this.mainGraphControl);
            this.Name = "Perfomance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Perfomance";
            this.Load += new System.EventHandler(this.Perfomance_Load);
            this.Shown += new System.EventHandler(this.Perfomance_Shown);
            this.Resize += new System.EventHandler(this.Perfomance_Resize);
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl mainGraphControl;
        private System.Windows.Forms.ComboBox TrainingList;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button bntClear;
        private System.Windows.Forms.CheckBox chkWeighCount;
        private System.Windows.Forms.CheckBox chkBodyWeight;
        private System.Windows.Forms.CheckBox chkWeight;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.RadioButton rbWork;
        private System.Windows.Forms.RadioButton rbMaxWeight;
        private System.Windows.Forms.Label lblFilters;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.CheckBox chkTotalWork;
        private System.Windows.Forms.CheckBox chkApprox;
    }
}