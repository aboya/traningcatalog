namespace TrainingCatalog.Forms
{
    partial class DayComment
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
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.txtComments = new TrainingCatalog.Controls.BaseTextBox();
            this.btnSave = new TrainingCatalog.Controls.BaseButton();
            this.btnPrev = new TrainingCatalog.Controls.BaseButton();
            this.btnNext = new TrainingCatalog.Controls.BaseButton();
            this.SuspendLayout();
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(18, 18);
            this.monthCalendar.MaxSelectionCount = 1;
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // txtComments
            // 
            this.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComments.Location = new System.Drawing.Point(194, 18);
            this.txtComments.MaxLength = 999;
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(316, 162);
            this.txtComments.TabIndex = 1;
            this.txtComments.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtComments_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(460, 186);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 50);
            this.btnSave.TabIndex = 2;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(194, 186);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(78, 48);
            this.btnPrev.TabIndex = 3;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(278, 186);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(78, 48);
            this.btnNext.TabIndex = 4;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // DayComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 243);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.monthCalendar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DayComment";
            this.Text = "DayComment";
            this.Load += new System.EventHandler(this.DayComment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar;
        private TrainingCatalog.Controls.BaseTextBox txtComments;
        private TrainingCatalog.Controls.BaseButton btnSave;
        private TrainingCatalog.Controls.BaseButton btnPrev;
        private TrainingCatalog.Controls.BaseButton btnNext;
    }
}