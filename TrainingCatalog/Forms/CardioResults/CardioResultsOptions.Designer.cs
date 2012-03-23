namespace TrainingCatalog.Forms
{
    partial class CardioResultsOptions
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
            this.gpSettings = new TrainingCatalog.Controls.BaseGroupBox();
            this.lblVelocity = new System.Windows.Forms.Label();
            this.lblSlash = new System.Windows.Forms.Label();
            this.cbSpeedDistance = new TrainingCatalog.Controls.BaseComboBox();
            this.lblDistance = new System.Windows.Forms.Label();
            this.cbSpeedTime = new TrainingCatalog.Controls.BaseComboBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.cbTime = new TrainingCatalog.Controls.BaseComboBox();
            this.cbDistance = new TrainingCatalog.Controls.BaseComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDistanceTo = new TrainingCatalog.Controls.FloatNumberTextBox();
            this.txtDistanceFrom = new TrainingCatalog.Controls.FloatNumberTextBox();
            this.txtTimeTo = new TrainingCatalog.Controls.FloatNumberTextBox();
            this.txtTimeFrom = new TrainingCatalog.Controls.FloatNumberTextBox();
            this.txtSpeedTo = new TrainingCatalog.Controls.FloatNumberTextBox();
            this.txtSpeedFrom = new TrainingCatalog.Controls.FloatNumberTextBox();
            this.baseGroupBox1 = new TrainingCatalog.Controls.BaseGroupBox();
            this.btnApply = new TrainingCatalog.Controls.BaseButton();
            this.gpSettings.SuspendLayout();
            this.baseGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpSettings
            // 
            this.gpSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gpSettings.Controls.Add(this.lblVelocity);
            this.gpSettings.Controls.Add(this.lblSlash);
            this.gpSettings.Controls.Add(this.cbSpeedDistance);
            this.gpSettings.Controls.Add(this.lblDistance);
            this.gpSettings.Controls.Add(this.cbSpeedTime);
            this.gpSettings.Controls.Add(this.lblTime);
            this.gpSettings.Controls.Add(this.cbTime);
            this.gpSettings.Controls.Add(this.cbDistance);
            this.gpSettings.Location = new System.Drawing.Point(15, 7);
            this.gpSettings.Name = "gpSettings";
            this.gpSettings.Size = new System.Drawing.Size(237, 116);
            this.gpSettings.TabIndex = 15;
            this.gpSettings.TabStop = false;
            this.gpSettings.Text = "Настройки меры";
            // 
            // lblVelocity
            // 
            this.lblVelocity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVelocity.AutoSize = true;
            this.lblVelocity.Location = new System.Drawing.Point(25, 23);
            this.lblVelocity.Name = "lblVelocity";
            this.lblVelocity.Size = new System.Drawing.Size(58, 13);
            this.lblVelocity.TabIndex = 17;
            this.lblVelocity.Text = "Скорость:";
            // 
            // lblSlash
            // 
            this.lblSlash.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSlash.AutoSize = true;
            this.lblSlash.Location = new System.Drawing.Point(147, 23);
            this.lblSlash.Name = "lblSlash";
            this.lblSlash.Size = new System.Drawing.Size(12, 13);
            this.lblSlash.TabIndex = 20;
            this.lblSlash.Text = "/";
            // 
            // cbSpeedDistance
            // 
            this.cbSpeedDistance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbSpeedDistance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpeedDistance.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbSpeedDistance.FormattingEnabled = true;
            this.cbSpeedDistance.Location = new System.Drawing.Point(89, 19);
            this.cbSpeedDistance.Name = "cbSpeedDistance";
            this.cbSpeedDistance.Size = new System.Drawing.Size(52, 21);
            this.cbSpeedDistance.TabIndex = 13;
            this.cbSpeedDistance.SelectionChangeCommitted += new System.EventHandler(this.cbSpeedDistance_SelectionChangeCommitted);
            // 
            // lblDistance
            // 
            this.lblDistance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(13, 76);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(70, 13);
            this.lblDistance.TabIndex = 19;
            this.lblDistance.Text = "Расстояние:";
            // 
            // cbSpeedTime
            // 
            this.cbSpeedTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbSpeedTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpeedTime.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbSpeedTime.FormattingEnabled = true;
            this.cbSpeedTime.Location = new System.Drawing.Point(165, 19);
            this.cbSpeedTime.Name = "cbSpeedTime";
            this.cbSpeedTime.Size = new System.Drawing.Size(52, 21);
            this.cbSpeedTime.TabIndex = 14;
            this.cbSpeedTime.SelectionChangeCommitted += new System.EventHandler(this.cbSpeedTime_SelectionChangeCommitted);
            // 
            // lblTime
            // 
            this.lblTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(40, 49);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(43, 13);
            this.lblTime.TabIndex = 18;
            this.lblTime.Text = "Время:";
            // 
            // cbTime
            // 
            this.cbTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTime.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbTime.FormattingEnabled = true;
            this.cbTime.Location = new System.Drawing.Point(89, 46);
            this.cbTime.Name = "cbTime";
            this.cbTime.Size = new System.Drawing.Size(52, 21);
            this.cbTime.TabIndex = 15;
            this.cbTime.SelectionChangeCommitted += new System.EventHandler(this.cbTime_SelectionChangeCommitted);
            // 
            // cbDistance
            // 
            this.cbDistance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbDistance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDistance.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbDistance.FormattingEnabled = true;
            this.cbDistance.Location = new System.Drawing.Point(89, 73);
            this.cbDistance.Name = "cbDistance";
            this.cbDistance.Size = new System.Drawing.Size(52, 21);
            this.cbDistance.TabIndex = 16;
            this.cbDistance.SelectionChangeCommitted += new System.EventHandler(this.cbDistance_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "До";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "От";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Расстояние:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Время:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Скорость:";
            // 
            // txtDistanceTo
            // 
            this.txtDistanceTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDistanceTo.Location = new System.Drawing.Point(116, 83);
            this.txtDistanceTo.Name = "txtDistanceTo";
            this.txtDistanceTo.Size = new System.Drawing.Size(34, 20);
            this.txtDistanceTo.TabIndex = 37;
            // 
            // txtDistanceFrom
            // 
            this.txtDistanceFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDistanceFrom.Location = new System.Drawing.Point(76, 83);
            this.txtDistanceFrom.Name = "txtDistanceFrom";
            this.txtDistanceFrom.Size = new System.Drawing.Size(34, 20);
            this.txtDistanceFrom.TabIndex = 36;
            // 
            // txtTimeTo
            // 
            this.txtTimeTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimeTo.Location = new System.Drawing.Point(116, 57);
            this.txtTimeTo.Name = "txtTimeTo";
            this.txtTimeTo.Size = new System.Drawing.Size(34, 20);
            this.txtTimeTo.TabIndex = 35;
            // 
            // txtTimeFrom
            // 
            this.txtTimeFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimeFrom.Location = new System.Drawing.Point(76, 57);
            this.txtTimeFrom.Name = "txtTimeFrom";
            this.txtTimeFrom.Size = new System.Drawing.Size(34, 20);
            this.txtTimeFrom.TabIndex = 34;
            // 
            // txtSpeedTo
            // 
            this.txtSpeedTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpeedTo.Location = new System.Drawing.Point(116, 31);
            this.txtSpeedTo.Name = "txtSpeedTo";
            this.txtSpeedTo.Size = new System.Drawing.Size(34, 20);
            this.txtSpeedTo.TabIndex = 33;
            // 
            // txtSpeedFrom
            // 
            this.txtSpeedFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpeedFrom.Location = new System.Drawing.Point(76, 31);
            this.txtSpeedFrom.Name = "txtSpeedFrom";
            this.txtSpeedFrom.Size = new System.Drawing.Size(34, 20);
            this.txtSpeedFrom.TabIndex = 32;
            // 
            // baseGroupBox1
            // 
            this.baseGroupBox1.Controls.Add(this.btnApply);
            this.baseGroupBox1.Controls.Add(this.label1);
            this.baseGroupBox1.Controls.Add(this.label5);
            this.baseGroupBox1.Controls.Add(this.txtSpeedFrom);
            this.baseGroupBox1.Controls.Add(this.label4);
            this.baseGroupBox1.Controls.Add(this.txtSpeedTo);
            this.baseGroupBox1.Controls.Add(this.label3);
            this.baseGroupBox1.Controls.Add(this.txtTimeFrom);
            this.baseGroupBox1.Controls.Add(this.label2);
            this.baseGroupBox1.Controls.Add(this.txtTimeTo);
            this.baseGroupBox1.Controls.Add(this.txtDistanceFrom);
            this.baseGroupBox1.Controls.Add(this.txtDistanceTo);
            this.baseGroupBox1.Location = new System.Drawing.Point(15, 134);
            this.baseGroupBox1.Name = "baseGroupBox1";
            this.baseGroupBox1.Size = new System.Drawing.Size(237, 143);
            this.baseGroupBox1.TabIndex = 43;
            this.baseGroupBox1.TabStop = false;
            this.baseGroupBox1.Text = "Фильтрация";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(148, 108);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(83, 29);
            this.btnApply.TabIndex = 43;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // CardioResultsOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 295);
            this.Controls.Add(this.baseGroupBox1);
            this.Controls.Add(this.gpSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.IsShown = true;
            this.Name = "CardioResultsOptions";
            this.Text = "CardioResultsOptions";
            this.Load += new System.EventHandler(this.CardioResultsOptions_Load);
            this.gpSettings.ResumeLayout(false);
            this.gpSettings.PerformLayout();
            this.baseGroupBox1.ResumeLayout(false);
            this.baseGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.BaseGroupBox gpSettings;
        private System.Windows.Forms.Label lblVelocity;
        private System.Windows.Forms.Label lblSlash;
        private Controls.BaseComboBox cbSpeedDistance;
        private System.Windows.Forms.Label lblDistance;
        private Controls.BaseComboBox cbSpeedTime;
        private System.Windows.Forms.Label lblTime;
        private Controls.BaseComboBox cbTime;
        private Controls.BaseComboBox cbDistance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Controls.FloatNumberTextBox txtDistanceTo;
        private Controls.FloatNumberTextBox txtDistanceFrom;
        private Controls.FloatNumberTextBox txtTimeTo;
        private Controls.FloatNumberTextBox txtTimeFrom;
        private Controls.FloatNumberTextBox txtSpeedTo;
        private Controls.FloatNumberTextBox txtSpeedFrom;
        private Controls.BaseGroupBox baseGroupBox1;
        private Controls.BaseButton btnApply;

    }
}