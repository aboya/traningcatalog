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
            this.gpSettings.SuspendLayout();
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
            this.gpSettings.Location = new System.Drawing.Point(12, 12);
            this.gpSettings.Name = "gpSettings";
            this.gpSettings.Size = new System.Drawing.Size(269, 165);
            this.gpSettings.TabIndex = 15;
            this.gpSettings.TabStop = false;
            this.gpSettings.Text = "Настройки меры";
            // 
            // lblVelocity
            // 
            this.lblVelocity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblVelocity.AutoSize = true;
            this.lblVelocity.Location = new System.Drawing.Point(18, 27);
            this.lblVelocity.Name = "lblVelocity";
            this.lblVelocity.Size = new System.Drawing.Size(58, 13);
            this.lblVelocity.TabIndex = 17;
            this.lblVelocity.Text = "Скорость:";
            // 
            // lblSlash
            // 
            this.lblSlash.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSlash.AutoSize = true;
            this.lblSlash.Location = new System.Drawing.Point(140, 27);
            this.lblSlash.Name = "lblSlash";
            this.lblSlash.Size = new System.Drawing.Size(12, 13);
            this.lblSlash.TabIndex = 20;
            this.lblSlash.Text = "/";
            // 
            // cbSpeedDistance
            // 
            this.cbSpeedDistance.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbSpeedDistance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpeedDistance.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbSpeedDistance.FormattingEnabled = true;
            this.cbSpeedDistance.Location = new System.Drawing.Point(82, 23);
            this.cbSpeedDistance.Name = "cbSpeedDistance";
            this.cbSpeedDistance.Size = new System.Drawing.Size(52, 21);
            this.cbSpeedDistance.TabIndex = 13;
            // 
            // lblDistance
            // 
            this.lblDistance.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(6, 80);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(70, 13);
            this.lblDistance.TabIndex = 19;
            this.lblDistance.Text = "Расстояние:";
            // 
            // cbSpeedTime
            // 
            this.cbSpeedTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbSpeedTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpeedTime.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbSpeedTime.FormattingEnabled = true;
            this.cbSpeedTime.Location = new System.Drawing.Point(158, 23);
            this.cbSpeedTime.Name = "cbSpeedTime";
            this.cbSpeedTime.Size = new System.Drawing.Size(52, 21);
            this.cbSpeedTime.TabIndex = 14;
            // 
            // lblTime
            // 
            this.lblTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(33, 53);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(43, 13);
            this.lblTime.TabIndex = 18;
            this.lblTime.Text = "Время:";
            // 
            // cbTime
            // 
            this.cbTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTime.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbTime.FormattingEnabled = true;
            this.cbTime.Location = new System.Drawing.Point(82, 50);
            this.cbTime.Name = "cbTime";
            this.cbTime.Size = new System.Drawing.Size(49, 21);
            this.cbTime.TabIndex = 15;
            // 
            // cbDistance
            // 
            this.cbDistance.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbDistance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDistance.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbDistance.FormattingEnabled = true;
            this.cbDistance.Location = new System.Drawing.Point(82, 77);
            this.cbDistance.Name = "cbDistance";
            this.cbDistance.Size = new System.Drawing.Size(47, 21);
            this.cbDistance.TabIndex = 16;
            // 
            // CardioResultsOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 193);
            this.Controls.Add(this.gpSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.IsShown = true;
            this.Name = "CardioResultsOptions";
            this.Text = "CardioResultsOptions";
            this.gpSettings.ResumeLayout(false);
            this.gpSettings.PerformLayout();
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

    }
}