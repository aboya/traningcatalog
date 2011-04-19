﻿namespace TrainingCatalog.Forms
{
    partial class CardioTraining
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
            this.mCalendar = new System.Windows.Forms.MonthCalendar();
            this.lstSession = new System.Windows.Forms.ListBox();
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.baseButton1 = new TrainingCatalog.Controls.BaseButton();
            this.baseButton2 = new TrainingCatalog.Controls.BaseButton();
            this.txtName = new TrainingCatalog.Controls.BaseTextBox();
            this.chkGraph = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // mCalendar
            // 
            this.mCalendar.Location = new System.Drawing.Point(18, 18);
            this.mCalendar.Name = "mCalendar";
            this.mCalendar.TabIndex = 0;
            // 
            // lstSession
            // 
            this.lstSession.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSession.FormattingEnabled = true;
            this.lstSession.Location = new System.Drawing.Point(194, 18);
            this.lstSession.Name = "lstSession";
            this.lstSession.Size = new System.Drawing.Size(221, 108);
            this.lstSession.TabIndex = 1;
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl.Location = new System.Drawing.Point(18, 192);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.ScrollGrace = 0D;
            this.zedGraphControl.ScrollMaxX = 0D;
            this.zedGraphControl.ScrollMaxY = 0D;
            this.zedGraphControl.ScrollMaxY2 = 0D;
            this.zedGraphControl.ScrollMinX = 0D;
            this.zedGraphControl.ScrollMinY = 0D;
            this.zedGraphControl.ScrollMinY2 = 0D;
            this.zedGraphControl.Size = new System.Drawing.Size(398, 184);
            this.zedGraphControl.TabIndex = 2;
            // 
            // baseButton1
            // 
            this.baseButton1.Location = new System.Drawing.Point(260, 157);
            this.baseButton1.Name = "baseButton1";
            this.baseButton1.Size = new System.Drawing.Size(75, 23);
            this.baseButton1.TabIndex = 3;
            this.baseButton1.Text = "Добавить";
            this.baseButton1.UseVisualStyleBackColor = true;
            this.baseButton1.Click += new System.EventHandler(this.baseButton1_Click);
            // 
            // baseButton2
            // 
            this.baseButton2.Location = new System.Drawing.Point(194, 157);
            this.baseButton2.Name = "baseButton2";
            this.baseButton2.Size = new System.Drawing.Size(60, 23);
            this.baseButton2.TabIndex = 4;
            this.baseButton2.Text = "Удалить";
            this.baseButton2.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(194, 131);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(221, 20);
            this.txtName.TabIndex = 5;
            // 
            // chkGraph
            // 
            this.chkGraph.AutoSize = true;
            this.chkGraph.Location = new System.Drawing.Point(341, 161);
            this.chkGraph.Name = "chkGraph";
            this.chkGraph.Size = new System.Drawing.Size(64, 17);
            this.chkGraph.TabIndex = 6;
            this.chkGraph.Text = "График";
            this.chkGraph.UseVisualStyleBackColor = true;
            this.chkGraph.CheckedChanged += new System.EventHandler(this.chkGraph_CheckedChanged);
            // 
            // CardioTraining
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 388);
            this.Controls.Add(this.chkGraph);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.baseButton2);
            this.Controls.Add(this.baseButton1);
            this.Controls.Add(this.zedGraphControl);
            this.Controls.Add(this.lstSession);
            this.Controls.Add(this.mCalendar);
            this.IsShown = true;
            this.Name = "CardioTraining";
            this.Text = "Cardio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar mCalendar;
        private System.Windows.Forms.ListBox lstSession;
        private ZedGraph.ZedGraphControl zedGraphControl;
        private Controls.BaseButton baseButton1;
        private Controls.BaseButton baseButton2;
        private Controls.BaseTextBox txtName;
        private System.Windows.Forms.CheckBox chkGraph;

     
    }
}