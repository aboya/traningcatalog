namespace TrainingCatalog.Forms
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
            this.mCalendar = new TrainingCatalog.Controls.BaseMonthCalendar();
            this.lstSession = new System.Windows.Forms.ListBox();
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.btnAdd = new TrainingCatalog.Controls.BaseButton();
            this.btnDelete = new TrainingCatalog.Controls.BaseButton();
            this.chkGraph = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // mCalendar
            // 
            this.mCalendar.Location = new System.Drawing.Point(18, 18);
            this.mCalendar.MaxSelectionCount = 1;
            this.mCalendar.Name = "mCalendar";
            this.mCalendar.TabIndex = 0;
            this.mCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mCalendar_DateSelected);
            // 
            // lstSession
            // 
            this.lstSession.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSession.FormattingEnabled = true;
            this.lstSession.Location = new System.Drawing.Point(194, 18);
            this.lstSession.Name = "lstSession";
            this.lstSession.Size = new System.Drawing.Size(221, 134);
            this.lstSession.TabIndex = 1;
            this.lstSession.SelectedIndexChanged += new System.EventHandler(this.lstSession_SelectedIndexChanged);
            this.lstSession.DoubleClick += new System.EventHandler(this.lstSession_DoubleClick);
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl.Location = new System.Drawing.Point(18, 192);
            this.zedGraphControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(260, 157);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(194, 157);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.zedGraphControl);
            this.Controls.Add(this.lstSession);
            this.Controls.Add(this.mCalendar);
            this.IsShown = true;
            this.Name = "CardioTraining";
            this.Text = "Cardio";
            this.Load += new System.EventHandler(this.CardioTraining_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TrainingCatalog.Controls.BaseMonthCalendar mCalendar;
        private System.Windows.Forms.ListBox lstSession;
        private ZedGraph.ZedGraphControl zedGraphControl;
        private Controls.BaseButton btnAdd;
        private Controls.BaseButton btnDelete;
        private System.Windows.Forms.CheckBox chkGraph;

     
    }
}