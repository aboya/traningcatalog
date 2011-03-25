namespace TrainingCatalog.Forms
{
    partial class AddFromOtherDay
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
            this.templateViewerControl = new TrainingCatalog.TemplateViewerControl();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(699, 192);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(78, 48);
            this.btnNext.TabIndex = 5;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrev.Location = new System.Drawing.Point(615, 192);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(78, 48);
            this.btnPrev.TabIndex = 4;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(729, 256);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 50);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // mc
            // 
            this.mc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mc.Location = new System.Drawing.Point(615, 18);
            this.mc.MaxSelectionCount = 1;
            this.mc.Name = "mc";
            this.mc.TabIndex = 1;
            this.mc.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mc_DateChanged);
            // 
            // templateViewerControl
            // 
            this.templateViewerControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.templateViewerControl.Location = new System.Drawing.Point(12, 12);
            this.templateViewerControl.Name = "templateViewerControl";
            this.templateViewerControl.Size = new System.Drawing.Size(591, 293);
            this.templateViewerControl.TabIndex = 0;
            // 
            // AddFromOtherDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 317);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.mc);
            this.Controls.Add(this.templateViewerControl);
            this.MinimumSize = new System.Drawing.Size(813, 355);
            this.Name = "AddFromOtherDay";
            this.Text = "AddFromOtherDay";
            this.Load += new System.EventHandler(this.AddFromOtherDay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private TemplateViewerControl templateViewerControl;
        private TrainingCatalog.Controls.BaseMonthCalendar mc;
        private TrainingCatalog.Controls.BaseButton btnAdd;
        private Controls.BaseButton btnPrev;
        private Controls.BaseButton btnNext;
    }
}