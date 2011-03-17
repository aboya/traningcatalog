using TrainingCatalog.Controls;
namespace TrainingCatalog.Forms
{
    partial class BodyMeasurements
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblBodyWeight = new System.Windows.Forms.Label();
            this.lblBodyFat = new System.Windows.Forms.Label();
            this.lblWaistLine_l = new System.Windows.Forms.Label();
            this.lblWaistLine_h = new System.Windows.Forms.Label();
            this.lblMidarm_l = new System.Windows.Forms.Label();
            this.lblMidarm_h = new System.Windows.Forms.Label();
            this.lblHip_l = new System.Windows.Forms.Label();
            this.lblHip_h = new System.Windows.Forms.Label();
            this.lblCest_l = new System.Windows.Forms.Label();
            this.lblChest_h = new System.Windows.Forms.Label();
            this.txtBodyFat = new TrainingCatalog.Controls.FloatNumberTextBox();
            this.txtWaistline_h = new TrainingCatalog.Controls.FloatNumberTextBox();
            this.txtMidarm_l = new TrainingCatalog.Controls.FloatNumberTextBox();
            this.txtWaistline_l = new TrainingCatalog.Controls.FloatNumberTextBox();
            this.txtMidarm_h = new TrainingCatalog.Controls.FloatNumberTextBox();
            this.txtBodyWeight = new TrainingCatalog.Controls.FloatNumberTextBox();
            this.txtHip_l = new TrainingCatalog.Controls.FloatNumberTextBox();
            this.txtHip_h = new TrainingCatalog.Controls.FloatNumberTextBox();
            this.txtChest_l = new TrainingCatalog.Controls.FloatNumberTextBox();
            this.txtChest_h = new TrainingCatalog.Controls.FloatNumberTextBox();
            this.txtBiceps_l = new TrainingCatalog.Controls.FloatNumberTextBox();
            this.txtBiceps_h = new TrainingCatalog.Controls.FloatNumberTextBox();
            this.lblBiceps_l = new System.Windows.Forms.Label();
            this.lblBiceps_h = new System.Windows.Forms.Label();
            this.mCalendar = new System.Windows.Forms.MonthCalendar();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(18, 185);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(176, 26);
            this.lblInfo.TabIndex = 26;
            this.lblInfo.Text = "*_h - в напряженном состоянии\r\n* _l - в расслабленном состоянии\r\n";
            // 
            // lblBodyWeight
            // 
            this.lblBodyWeight.AutoSize = true;
            this.lblBodyWeight.Location = new System.Drawing.Point(409, 153);
            this.lblBodyWeight.Name = "lblBodyWeight";
            this.lblBodyWeight.Size = new System.Drawing.Size(54, 13);
            this.lblBodyWeight.TabIndex = 25;
            this.lblBodyWeight.Text = "Вес Тела";
            // 
            // lblBodyFat
            // 
            this.lblBodyFat.AutoSize = true;
            this.lblBodyFat.Location = new System.Drawing.Point(425, 127);
            this.lblBodyFat.Name = "lblBodyFat";
            this.lblBodyFat.Size = new System.Drawing.Size(38, 13);
            this.lblBodyFat.TabIndex = 24;
            this.lblBodyFat.Text = "Жир%";
            // 
            // lblWaistLine_l
            // 
            this.lblWaistLine_l.AutoSize = true;
            this.lblWaistLine_l.Location = new System.Drawing.Point(417, 101);
            this.lblWaistLine_l.Name = "lblWaistLine_l";
            this.lblWaistLine_l.Size = new System.Drawing.Size(46, 13);
            this.lblWaistLine_l.TabIndex = 23;
            this.lblWaistLine_l.Text = "Талия_l";
            // 
            // lblWaistLine_h
            // 
            this.lblWaistLine_h.AutoSize = true;
            this.lblWaistLine_h.Location = new System.Drawing.Point(413, 75);
            this.lblWaistLine_h.Name = "lblWaistLine_h";
            this.lblWaistLine_h.Size = new System.Drawing.Size(50, 13);
            this.lblWaistLine_h.TabIndex = 22;
            this.lblWaistLine_h.Text = "Талия_h";
            // 
            // lblMidarm_l
            // 
            this.lblMidarm_l.AutoSize = true;
            this.lblMidarm_l.Location = new System.Drawing.Point(387, 49);
            this.lblMidarm_l.Name = "lblMidarm_l";
            this.lblMidarm_l.Size = new System.Drawing.Size(76, 13);
            this.lblMidarm_l.TabIndex = 21;
            this.lblMidarm_l.Text = "Предплечье_l";
            // 
            // lblMidarm_h
            // 
            this.lblMidarm_h.AutoSize = true;
            this.lblMidarm_h.Location = new System.Drawing.Point(383, 23);
            this.lblMidarm_h.Name = "lblMidarm_h";
            this.lblMidarm_h.Size = new System.Drawing.Size(80, 13);
            this.lblMidarm_h.TabIndex = 20;
            this.lblMidarm_h.Text = "Предплечье_h";
            // 
            // lblHip_l
            // 
            this.lblHip_l.AutoSize = true;
            this.lblHip_l.Location = new System.Drawing.Point(215, 153);
            this.lblHip_l.Name = "lblHip_l";
            this.lblHip_l.Size = new System.Drawing.Size(46, 13);
            this.lblHip_l.TabIndex = 19;
            this.lblHip_l.Text = "Бедро_l";
            // 
            // lblHip_h
            // 
            this.lblHip_h.AutoSize = true;
            this.lblHip_h.Location = new System.Drawing.Point(211, 127);
            this.lblHip_h.Name = "lblHip_h";
            this.lblHip_h.Size = new System.Drawing.Size(50, 13);
            this.lblHip_h.TabIndex = 18;
            this.lblHip_h.Text = "Бедро_h";
            // 
            // lblCest_l
            // 
            this.lblCest_l.AutoSize = true;
            this.lblCest_l.Location = new System.Drawing.Point(217, 101);
            this.lblCest_l.Name = "lblCest_l";
            this.lblCest_l.Size = new System.Drawing.Size(44, 13);
            this.lblCest_l.TabIndex = 17;
            this.lblCest_l.Text = "Грудь_l";
            // 
            // lblChest_h
            // 
            this.lblChest_h.AutoSize = true;
            this.lblChest_h.Location = new System.Drawing.Point(213, 75);
            this.lblChest_h.Name = "lblChest_h";
            this.lblChest_h.Size = new System.Drawing.Size(48, 13);
            this.lblChest_h.TabIndex = 16;
            this.lblChest_h.Text = "Грудь_h";
            // 
            // txtBodyFat
            // 
            this.txtBodyFat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBodyFat.Location = new System.Drawing.Point(469, 122);
            this.txtBodyFat.Name = "txtBodyFat";
            this.txtBodyFat.Size = new System.Drawing.Size(100, 20);
            this.txtBodyFat.TabIndex = 11;
            // 
            // txtWaistline_h
            // 
            this.txtWaistline_h.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWaistline_h.Location = new System.Drawing.Point(469, 70);
            this.txtWaistline_h.Name = "txtWaistline_h";
            this.txtWaistline_h.Size = new System.Drawing.Size(100, 20);
            this.txtWaistline_h.TabIndex = 9;
            // 
            // txtMidarm_l
            // 
            this.txtMidarm_l.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMidarm_l.Location = new System.Drawing.Point(469, 44);
            this.txtMidarm_l.Name = "txtMidarm_l";
            this.txtMidarm_l.Size = new System.Drawing.Size(100, 20);
            this.txtMidarm_l.TabIndex = 8;
            // 
            // txtWaistline_l
            // 
            this.txtWaistline_l.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWaistline_l.Location = new System.Drawing.Point(469, 96);
            this.txtWaistline_l.Name = "txtWaistline_l";
            this.txtWaistline_l.Size = new System.Drawing.Size(100, 20);
            this.txtWaistline_l.TabIndex = 10;
            // 
            // txtMidarm_h
            // 
            this.txtMidarm_h.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMidarm_h.Location = new System.Drawing.Point(469, 18);
            this.txtMidarm_h.Name = "txtMidarm_h";
            this.txtMidarm_h.Size = new System.Drawing.Size(100, 20);
            this.txtMidarm_h.TabIndex = 7;
            // 
            // txtBodyWeight
            // 
            this.txtBodyWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBodyWeight.Location = new System.Drawing.Point(469, 148);
            this.txtBodyWeight.Name = "txtBodyWeight";
            this.txtBodyWeight.Size = new System.Drawing.Size(100, 20);
            this.txtBodyWeight.TabIndex = 12;
            // 
            // txtHip_l
            // 
            this.txtHip_l.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHip_l.Location = new System.Drawing.Point(267, 148);
            this.txtHip_l.Name = "txtHip_l";
            this.txtHip_l.Size = new System.Drawing.Size(100, 20);
            this.txtHip_l.TabIndex = 6;
            // 
            // txtHip_h
            // 
            this.txtHip_h.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHip_h.Location = new System.Drawing.Point(267, 122);
            this.txtHip_h.Name = "txtHip_h";
            this.txtHip_h.Size = new System.Drawing.Size(100, 20);
            this.txtHip_h.TabIndex = 5;
            // 
            // txtChest_l
            // 
            this.txtChest_l.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChest_l.Location = new System.Drawing.Point(267, 96);
            this.txtChest_l.Name = "txtChest_l";
            this.txtChest_l.Size = new System.Drawing.Size(100, 20);
            this.txtChest_l.TabIndex = 4;
            // 
            // txtChest_h
            // 
            this.txtChest_h.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChest_h.Location = new System.Drawing.Point(267, 70);
            this.txtChest_h.Name = "txtChest_h";
            this.txtChest_h.Size = new System.Drawing.Size(100, 20);
            this.txtChest_h.TabIndex = 3;
            // 
            // txtBiceps_l
            // 
            this.txtBiceps_l.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBiceps_l.Location = new System.Drawing.Point(267, 44);
            this.txtBiceps_l.Name = "txtBiceps_l";
            this.txtBiceps_l.Size = new System.Drawing.Size(100, 20);
            this.txtBiceps_l.TabIndex = 2;
            // 
            // txtBiceps_h
            // 
            this.txtBiceps_h.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBiceps_h.Location = new System.Drawing.Point(267, 18);
            this.txtBiceps_h.Name = "txtBiceps_h";
            this.txtBiceps_h.Size = new System.Drawing.Size(100, 20);
            this.txtBiceps_h.TabIndex = 1;
            // 
            // lblBiceps_l
            // 
            this.lblBiceps_l.AutoSize = true;
            this.lblBiceps_l.Location = new System.Drawing.Point(209, 49);
            this.lblBiceps_l.Name = "lblBiceps_l";
            this.lblBiceps_l.Size = new System.Drawing.Size(52, 13);
            this.lblBiceps_l.TabIndex = 3;
            this.lblBiceps_l.Text = "Бицепц_l";
            // 
            // lblBiceps_h
            // 
            this.lblBiceps_h.AutoSize = true;
            this.lblBiceps_h.Location = new System.Drawing.Point(205, 22);
            this.lblBiceps_h.Name = "lblBiceps_h";
            this.lblBiceps_h.Size = new System.Drawing.Size(56, 13);
            this.lblBiceps_h.TabIndex = 2;
            this.lblBiceps_h.Text = "Бицепц_h";
            // 
            // mCalendar
            // 
            this.mCalendar.Location = new System.Drawing.Point(18, 18);
            this.mCalendar.MaxSelectionCount = 1;
            this.mCalendar.Name = "mCalendar";
            this.mCalendar.TabIndex = 0;
            this.mCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mCalendar_DateChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(517, 183);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 50);
            this.btnSave.TabIndex = 0;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(267, 185);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(78, 48);
            this.btnPrev.TabIndex = 27;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(353, 185);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(78, 48);
            this.btnNext.TabIndex = 28;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // BodyMeasurements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 240);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblBodyWeight);
            this.Controls.Add(this.lblBodyFat);
            this.Controls.Add(this.lblWaistLine_l);
            this.Controls.Add(this.lblWaistLine_h);
            this.Controls.Add(this.lblMidarm_l);
            this.Controls.Add(this.lblMidarm_h);
            this.Controls.Add(this.lblHip_l);
            this.Controls.Add(this.lblHip_h);
            this.Controls.Add(this.lblCest_l);
            this.Controls.Add(this.lblChest_h);
            this.Controls.Add(this.txtBodyFat);
            this.Controls.Add(this.txtWaistline_h);
            this.Controls.Add(this.txtMidarm_l);
            this.Controls.Add(this.txtWaistline_l);
            this.Controls.Add(this.txtMidarm_h);
            this.Controls.Add(this.txtBodyWeight);
            this.Controls.Add(this.txtHip_l);
            this.Controls.Add(this.txtHip_h);
            this.Controls.Add(this.txtChest_l);
            this.Controls.Add(this.txtChest_h);
            this.Controls.Add(this.txtBiceps_l);
            this.Controls.Add(this.txtBiceps_h);
            this.Controls.Add(this.lblBiceps_l);
            this.Controls.Add(this.lblBiceps_h);
            this.Controls.Add(this.mCalendar);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BodyMeasurements";
            this.Text = "BodyMeasurements";
            this.Load += new System.EventHandler(this.BodyMeasurements_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.MonthCalendar mCalendar;
        private System.Windows.Forms.Label lblBiceps_h;
        private System.Windows.Forms.Label lblBiceps_l;
        private FloatNumberTextBox txtBiceps_h;
        private FloatNumberTextBox txtBiceps_l;
        private FloatNumberTextBox txtChest_h;
        private FloatNumberTextBox txtChest_l;
        private FloatNumberTextBox txtHip_h;
        private FloatNumberTextBox txtHip_l;
        private FloatNumberTextBox txtBodyWeight;
        private FloatNumberTextBox txtMidarm_h;
        private FloatNumberTextBox txtWaistline_l;
        private FloatNumberTextBox txtMidarm_l;
        private FloatNumberTextBox txtWaistline_h;
        private FloatNumberTextBox txtBodyFat;
        private System.Windows.Forms.Label lblChest_h;
        private System.Windows.Forms.Label lblCest_l;
        private System.Windows.Forms.Label lblHip_h;
        private System.Windows.Forms.Label lblHip_l;
        private System.Windows.Forms.Label lblMidarm_h;
        private System.Windows.Forms.Label lblMidarm_l;
        private System.Windows.Forms.Label lblWaistLine_h;
        private System.Windows.Forms.Label lblWaistLine_l;
        private System.Windows.Forms.Label lblBodyFat;
        private System.Windows.Forms.Label lblBodyWeight;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
    }
}