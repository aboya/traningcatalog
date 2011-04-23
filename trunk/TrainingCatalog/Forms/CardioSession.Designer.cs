using System.Windows.Forms;
namespace TrainingCatalog.Forms
{
    partial class CardioSession
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TrainingCatalog.Controls.BaseMaskedTextBox txtBeginTime;
        private Controls.BaseMaskedTextBox txtEndTime;
        private Controls.BaseMaskedTextBox txtDuration;
        private Controls.BaseLabel lblStart;
        private Controls.BaseLabel lblEnd;
        private Controls.BaseLabel lblDuration;
        private TrainingCatalog.Controls.CardioDataGridView gvMain;
        private System.Windows.Forms.ListBox lstExersizes;
        private TrainingCatalog.Controls.BaseButton btnAdd;
        private Controls.BaseGroupBox baseGroupBox1;
        private TrainingCatalog.Controls.BaseButton btnOk;

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
            this.btnOk = new TrainingCatalog.Controls.BaseButton();
            this.txtBeginTime = new TrainingCatalog.Controls.BaseMaskedTextBox();
            this.txtEndTime = new TrainingCatalog.Controls.BaseMaskedTextBox();
            this.txtDuration = new TrainingCatalog.Controls.BaseMaskedTextBox();
            this.lblStart = new TrainingCatalog.Controls.BaseLabel();
            this.lblEnd = new TrainingCatalog.Controls.BaseLabel();
            this.lblDuration = new TrainingCatalog.Controls.BaseLabel();
            this.gvMain = new TrainingCatalog.Controls.CardioDataGridView();
            this.ExersizeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Intensivity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Velocity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pulse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lstExersizes = new System.Windows.Forms.ListBox();
            this.btnAdd = new TrainingCatalog.Controls.BaseButton();
            this.baseGroupBox1 = new TrainingCatalog.Controls.BaseGroupBox();
            this.baseComboBox1 = new TrainingCatalog.Controls.BaseComboBox();
            this.baseComboBox2 = new TrainingCatalog.Controls.BaseComboBox();
            this.baseComboBox3 = new TrainingCatalog.Controls.BaseComboBox();
            this.baseComboBox4 = new TrainingCatalog.Controls.BaseComboBox();
            this.lblVelocity = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDistance = new System.Windows.Forms.Label();
            this.lblSlash = new System.Windows.Forms.Label();
            this.gpSettings = new TrainingCatalog.Controls.BaseGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            this.baseGroupBox1.SuspendLayout();
            this.gpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.Location = new System.Drawing.Point(15, 313);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(50, 50);
            this.btnOk.TabIndex = 0;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtBeginTime
            // 
            this.txtBeginTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBeginTime.Location = new System.Drawing.Point(123, 8);
            this.txtBeginTime.Mask = "00:00";
            this.txtBeginTime.Name = "txtBeginTime";
            this.txtBeginTime.Size = new System.Drawing.Size(49, 20);
            this.txtBeginTime.TabIndex = 1;
            this.txtBeginTime.ValidatingType = typeof(System.DateTime);
            // 
            // txtEndTime
            // 
            this.txtEndTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndTime.Location = new System.Drawing.Point(123, 33);
            this.txtEndTime.Mask = "00:00";
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(49, 20);
            this.txtEndTime.TabIndex = 2;
            this.txtEndTime.ValidatingType = typeof(System.DateTime);
            // 
            // txtDuration
            // 
            this.txtDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDuration.Location = new System.Drawing.Point(123, 60);
            this.txtDuration.Mask = "00:00";
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(49, 20);
            this.txtDuration.TabIndex = 4;
            this.txtDuration.ValidatingType = typeof(System.DateTime);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(33, 10);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(78, 13);
            this.lblStart.TabIndex = 5;
            this.lblStart.Text = "Время начала";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(6, 35);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(105, 13);
            this.lblEnd.TabIndex = 6;
            this.lblEnd.Text = "Врмея завершения";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(6, 62);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(111, 13);
            this.lblDuration.TabIndex = 7;
            this.lblDuration.Text = "Продолжительность";
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
            this.gvMain.Location = new System.Drawing.Point(178, 5);
            this.gvMain.Name = "gvMain";
            this.gvMain.Size = new System.Drawing.Size(563, 291);
            this.gvMain.TabIndex = 8;
            this.gvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellClick);
            this.gvMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellContentClick);
            this.gvMain.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellEndEdit);
            this.gvMain.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellEnter);
            this.gvMain.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gvMain_CellValidating);
            this.gvMain.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.gvMain_CellValuePushed);
            this.gvMain.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gvMain_EditingControlShowing);
            this.gvMain.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gvMain_RowsAdded);
            this.gvMain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gvMain_KeyPress);
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
            // lstExersizes
            // 
            this.lstExersizes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstExersizes.FormattingEnabled = true;
            this.lstExersizes.Location = new System.Drawing.Point(6, 19);
            this.lstExersizes.Name = "lstExersizes";
            this.lstExersizes.Size = new System.Drawing.Size(138, 186);
            this.lstExersizes.TabIndex = 9;
            this.lstExersizes.SelectedIndexChanged += new System.EventHandler(this.lstExersizes_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(115, 313);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 50);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // baseGroupBox1
            // 
            this.baseGroupBox1.Controls.Add(this.lstExersizes);
            this.baseGroupBox1.Location = new System.Drawing.Point(15, 86);
            this.baseGroupBox1.Name = "baseGroupBox1";
            this.baseGroupBox1.Size = new System.Drawing.Size(150, 215);
            this.baseGroupBox1.TabIndex = 12;
            this.baseGroupBox1.TabStop = false;
            this.baseGroupBox1.Text = "Вид Кардио";
            // 
            // baseComboBox1
            // 
            this.baseComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.baseComboBox1.FormattingEnabled = true;
            this.baseComboBox1.Location = new System.Drawing.Point(71, 23);
            this.baseComboBox1.Name = "baseComboBox1";
            this.baseComboBox1.Size = new System.Drawing.Size(52, 21);
            this.baseComboBox1.TabIndex = 13;
            // 
            // baseComboBox2
            // 
            this.baseComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.baseComboBox2.FormattingEnabled = true;
            this.baseComboBox2.Location = new System.Drawing.Point(147, 23);
            this.baseComboBox2.Name = "baseComboBox2";
            this.baseComboBox2.Size = new System.Drawing.Size(52, 21);
            this.baseComboBox2.TabIndex = 14;
            // 
            // baseComboBox3
            // 
            this.baseComboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.baseComboBox3.FormattingEnabled = true;
            this.baseComboBox3.Location = new System.Drawing.Point(254, 23);
            this.baseComboBox3.Name = "baseComboBox3";
            this.baseComboBox3.Size = new System.Drawing.Size(49, 21);
            this.baseComboBox3.TabIndex = 15;
            // 
            // baseComboBox4
            // 
            this.baseComboBox4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.baseComboBox4.FormattingEnabled = true;
            this.baseComboBox4.Location = new System.Drawing.Point(385, 23);
            this.baseComboBox4.Name = "baseComboBox4";
            this.baseComboBox4.Size = new System.Drawing.Size(47, 21);
            this.baseComboBox4.TabIndex = 16;
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
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(205, 27);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(43, 13);
            this.lblTime.TabIndex = 18;
            this.lblTime.Text = "Время:";
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
            // lblSlash
            // 
            this.lblSlash.AutoSize = true;
            this.lblSlash.Location = new System.Drawing.Point(129, 27);
            this.lblSlash.Name = "lblSlash";
            this.lblSlash.Size = new System.Drawing.Size(12, 13);
            this.lblSlash.TabIndex = 20;
            this.lblSlash.Text = "/";
            // 
            // gpSettings
            // 
            this.gpSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpSettings.Controls.Add(this.lblVelocity);
            this.gpSettings.Controls.Add(this.lblSlash);
            this.gpSettings.Controls.Add(this.baseComboBox1);
            this.gpSettings.Controls.Add(this.lblDistance);
            this.gpSettings.Controls.Add(this.baseComboBox2);
            this.gpSettings.Controls.Add(this.lblTime);
            this.gpSettings.Controls.Add(this.baseComboBox3);
            this.gpSettings.Controls.Add(this.baseComboBox4);
            this.gpSettings.Location = new System.Drawing.Point(178, 302);
            this.gpSettings.Name = "gpSettings";
            this.gpSettings.Size = new System.Drawing.Size(563, 61);
            this.gpSettings.TabIndex = 13;
            this.gpSettings.TabStop = false;
            this.gpSettings.Text = "Настройки меры";
            // 
            // CardioSession
            // 
            this.ClientSize = new System.Drawing.Size(753, 375);
            this.Controls.Add(this.gpSettings);
            this.Controls.Add(this.baseGroupBox1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gvMain);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.txtEndTime);
            this.Controls.Add(this.txtBeginTime);
            this.Controls.Add(this.btnOk);
            this.IsShown = true;
            this.MinimumSize = new System.Drawing.Size(648, 413);
            this.Name = "CardioSession";
            this.Text = "CardioIntervals";
            this.Load += new System.EventHandler(this.CardioSession_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            this.baseGroupBox1.ResumeLayout(false);
            this.gpSettings.ResumeLayout(false);
            this.gpSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridViewTextBoxColumn ExersizeName;
        private DataGridViewTextBoxColumn Intensivity;
        private DataGridViewTextBoxColumn Resistance;
        private DataGridViewTextBoxColumn Velocity;
        private DataGridViewTextBoxColumn Time;
        private DataGridViewTextBoxColumn Distance;
        private DataGridViewTextBoxColumn Pulse;
        private Controls.BaseComboBox baseComboBox1;
        private Controls.BaseComboBox baseComboBox2;
        private Controls.BaseComboBox baseComboBox3;
        private Controls.BaseComboBox baseComboBox4;
        private Label lblVelocity;
        private Label lblTime;
        private Label lblDistance;
        private Label lblSlash;
        private Controls.BaseGroupBox gpSettings;





    }
}