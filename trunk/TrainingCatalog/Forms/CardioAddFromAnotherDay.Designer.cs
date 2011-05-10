namespace TrainingCatalog.Forms
{
    partial class CardioAddFromAnotherDay
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
            this.btnNext = new TrainingCatalog.Controls.BaseButton();
            this.btnPrev = new TrainingCatalog.Controls.BaseButton();
            this.btnAdd = new TrainingCatalog.Controls.BaseButton();
            this.mc = new TrainingCatalog.Controls.BaseMonthCalendar();
            this.cardioExersizesControl = new TrainingCatalog.Controls.CardioExersizesControl();
            this.cbSessions = new TrainingCatalog.Controls.BaseComboBox();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(683, 206);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(78, 48);
            this.btnNext.TabIndex = 9;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrev.Location = new System.Drawing.Point(599, 206);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(78, 48);
            this.btnPrev.TabIndex = 8;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(711, 310);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 50);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // mc
            // 
            this.mc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mc.Location = new System.Drawing.Point(599, 12);
            this.mc.MaxSelectionCount = 1;
            this.mc.Name = "mc";
            this.mc.TabIndex = 6;
            this.mc.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mc_DateChanged);
            // 
            // cardioExersizesControl
            // 
            this.cardioExersizesControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cardioExersizesControl.DefaultCardioType = null;
            this.cardioExersizesControl.Location = new System.Drawing.Point(12, 12);
            this.cardioExersizesControl.Name = "cardioExersizesControl";
            this.cardioExersizesControl.Size = new System.Drawing.Size(575, 348);
            this.cardioExersizesControl.TabIndex = 10;
            // 
            // cbSessions
            // 
            this.cbSessions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSessions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSessions.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbSessions.FormattingEnabled = true;
            this.cbSessions.Location = new System.Drawing.Point(601, 179);
            this.cbSessions.Name = "cbSessions";
            this.cbSessions.Size = new System.Drawing.Size(162, 21);
            this.cbSessions.TabIndex = 11;
            this.cbSessions.SelectionChangeCommitted += new System.EventHandler(this.cbSessions_SelectionChangeCommitted);
            // 
            // CardioAddFromAnotherDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 371);
            this.Controls.Add(this.cbSessions);
            this.Controls.Add(this.cardioExersizesControl);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.mc);
            this.IsShown = true;
            this.MinimumSize = new System.Drawing.Size(799, 409);
            this.Name = "CardioAddFromAnotherDay";
            this.Text = "CardioAddFromAnotherDay";
            this.Load += new System.EventHandler(this.CardioAddFromAnotherDay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.BaseButton btnNext;
        private Controls.BaseButton btnPrev;
        private Controls.BaseButton btnAdd;
        private Controls.BaseMonthCalendar mc;
        private Controls.CardioExersizesControl cardioExersizesControl;
        private Controls.BaseComboBox cbSessions;
    }
}