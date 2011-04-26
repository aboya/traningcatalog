namespace TrainingCatalog.Controls
{
    partial class CardioExersizesControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gvMain = new TrainingCatalog.Controls.CardioDataGridView();
            this.ExersizeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Intensivity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Velocity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pulse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpSettings = new TrainingCatalog.Controls.BaseGroupBox();
            this.lblVelocity = new System.Windows.Forms.Label();
            this.lblSlash = new System.Windows.Forms.Label();
            this.cbSpeedDistance = new TrainingCatalog.Controls.BaseComboBox();
            this.lblDistance = new System.Windows.Forms.Label();
            this.cbSpeedTime = new TrainingCatalog.Controls.BaseComboBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.cbTime = new TrainingCatalog.Controls.BaseComboBox();
            this.cbDistance = new TrainingCatalog.Controls.BaseComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            this.gpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvMain
            // 
            this.gvMain.AllowUserToResizeRows = false;
            this.gvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ExersizeName,
            this.Intensivity,
            this.Resistance,
            this.Velocity,
            this.Time,
            this.Distance,
            this.Pulse});
            this.gvMain.Location = new System.Drawing.Point(3, 3);
            this.gvMain.Name = "gvMain";
            this.gvMain.Size = new System.Drawing.Size(569, 275);
            this.gvMain.TabIndex = 9;
            this.gvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellClick);
            this.gvMain.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellEnter);
            this.gvMain.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gvMain_RowsAdded);
            // 
            // ExersizeName
            // 
            this.ExersizeName.DataPropertyName = "Name";
            this.ExersizeName.HeaderText = "Имя";
            this.ExersizeName.Name = "ExersizeName";
            this.ExersizeName.ReadOnly = true;
            this.ExersizeName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ExersizeName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Intensivity
            // 
            this.Intensivity.DataPropertyName = "Intensivity";
            this.Intensivity.HeaderText = "Интенсивность";
            this.Intensivity.Name = "Intensivity";
            this.Intensivity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Resistance
            // 
            this.Resistance.DataPropertyName = "Resistance";
            this.Resistance.HeaderText = "Нагрузка";
            this.Resistance.Name = "Resistance";
            this.Resistance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Resistance.Width = 70;
            // 
            // Velocity
            // 
            this.Velocity.DataPropertyName = "Velocity";
            this.Velocity.HeaderText = "Скорость";
            this.Velocity.Name = "Velocity";
            this.Velocity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Velocity.Width = 60;
            // 
            // Time
            // 
            this.Time.DataPropertyName = "Time";
            this.Time.HeaderText = "Время";
            this.Time.Name = "Time";
            this.Time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Time.Width = 70;
            // 
            // Distance
            // 
            this.Distance.DataPropertyName = "Distance";
            this.Distance.HeaderText = "Расстояние";
            this.Distance.Name = "Distance";
            this.Distance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Distance.Width = 70;
            // 
            // Pulse
            // 
            this.Pulse.DataPropertyName = "HeartRate";
            this.Pulse.HeaderText = "Пульс";
            this.Pulse.Name = "Pulse";
            this.Pulse.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Pulse.Width = 50;
            // 
            // gpSettings
            // 
            this.gpSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpSettings.Controls.Add(this.lblVelocity);
            this.gpSettings.Controls.Add(this.lblSlash);
            this.gpSettings.Controls.Add(this.cbSpeedDistance);
            this.gpSettings.Controls.Add(this.lblDistance);
            this.gpSettings.Controls.Add(this.cbSpeedTime);
            this.gpSettings.Controls.Add(this.lblTime);
            this.gpSettings.Controls.Add(this.cbTime);
            this.gpSettings.Controls.Add(this.cbDistance);
            this.gpSettings.Location = new System.Drawing.Point(3, 284);
            this.gpSettings.Name = "gpSettings";
            this.gpSettings.Size = new System.Drawing.Size(569, 61);
            this.gpSettings.TabIndex = 14;
            this.gpSettings.TabStop = false;
            this.gpSettings.Text = "Настройки меры";
            // 
            // lblVelocity
            // 
            this.lblVelocity.AutoSize = true;
            this.lblVelocity.Location = new System.Drawing.Point(7, 27);
            this.lblVelocity.Name = "lblVelocity";
            this.lblVelocity.Size = new System.Drawing.Size(58, 13);
            this.lblVelocity.TabIndex = 17;
            this.lblVelocity.Text = "Скорость:";
            // 
            // lblSlash
            // 
            this.lblSlash.AutoSize = true;
            this.lblSlash.Location = new System.Drawing.Point(129, 27);
            this.lblSlash.Name = "lblSlash";
            this.lblSlash.Size = new System.Drawing.Size(12, 13);
            this.lblSlash.TabIndex = 20;
            this.lblSlash.Text = "/";
            // 
            // cbSpeedDistance
            // 
            this.cbSpeedDistance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpeedDistance.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbSpeedDistance.FormattingEnabled = true;
            this.cbSpeedDistance.Location = new System.Drawing.Point(71, 23);
            this.cbSpeedDistance.Name = "cbSpeedDistance";
            this.cbSpeedDistance.Size = new System.Drawing.Size(52, 21);
            this.cbSpeedDistance.TabIndex = 13;
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(309, 27);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(70, 13);
            this.lblDistance.TabIndex = 19;
            this.lblDistance.Text = "Расстояние:";
            // 
            // cbSpeedTime
            // 
            this.cbSpeedTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpeedTime.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbSpeedTime.FormattingEnabled = true;
            this.cbSpeedTime.Location = new System.Drawing.Point(147, 23);
            this.cbSpeedTime.Name = "cbSpeedTime";
            this.cbSpeedTime.Size = new System.Drawing.Size(52, 21);
            this.cbSpeedTime.TabIndex = 14;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(205, 27);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(43, 13);
            this.lblTime.TabIndex = 18;
            this.lblTime.Text = "Время:";
            // 
            // cbTime
            // 
            this.cbTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTime.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbTime.FormattingEnabled = true;
            this.cbTime.Location = new System.Drawing.Point(254, 23);
            this.cbTime.Name = "cbTime";
            this.cbTime.Size = new System.Drawing.Size(49, 21);
            this.cbTime.TabIndex = 15;
            // 
            // cbDistance
            // 
            this.cbDistance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDistance.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbDistance.FormattingEnabled = true;
            this.cbDistance.Location = new System.Drawing.Point(385, 23);
            this.cbDistance.Name = "cbDistance";
            this.cbDistance.Size = new System.Drawing.Size(47, 21);
            this.cbDistance.TabIndex = 16;
            // 
            // CardioExersizesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpSettings);
            this.Controls.Add(this.gvMain);
            this.Name = "CardioExersizesControl";
            this.Size = new System.Drawing.Size(575, 348);
            this.Load += new System.EventHandler(this.CardioExersizesControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            this.gpSettings.ResumeLayout(false);
            this.gpSettings.PerformLayout();
            this.ResumeLayout(false);

            this.cbDistance.SelectedIndexChanged += new System.EventHandler(this.cbDistance_SelectedIndexChanged);
            this.cbDistance.SelectionChangeCommitted += new System.EventHandler(this.cbDistance_SelectionChangeCommitted);
            this.cbTime.SelectedIndexChanged += new System.EventHandler(this.cbTime_SelectedIndexChanged);
            this.cbTime.SelectionChangeCommitted += new System.EventHandler(this.cbTime_SelectionChangeCommitted);
            this.cbSpeedTime.SelectedIndexChanged += new System.EventHandler(this.cbSpeedTime_SelectedIndexChanged);
            this.cbSpeedTime.SelectionChangeCommitted += new System.EventHandler(this.cbSpeedTime_SelectionChangeCommitted);
            this.cbSpeedDistance.SelectedIndexChanged += new System.EventHandler(this.cbSpeedDistance_SelectedIndexChanged);
            this.cbSpeedDistance.SelectionChangeCommitted += new System.EventHandler(this.cbSpeedDistance_SelectionChangeCommitted);
        

        }

        #endregion

        private CardioDataGridView gvMain;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExersizeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Intensivity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Resistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Velocity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Distance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pulse;
        private BaseGroupBox gpSettings;
        private System.Windows.Forms.Label lblVelocity;
        private System.Windows.Forms.Label lblSlash;
        private BaseComboBox cbSpeedDistance;
        private System.Windows.Forms.Label lblDistance;
        private BaseComboBox cbSpeedTime;
        private System.Windows.Forms.Label lblTime;
        private BaseComboBox cbTime;
        private BaseComboBox cbDistance;
    }
}
