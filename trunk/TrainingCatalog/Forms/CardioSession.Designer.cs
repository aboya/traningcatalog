using System.Windows.Forms;
namespace TrainingCatalog.Forms
{
    partial class CardioSession
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TrainingCatalog.Controls.BaseMaskedTextBox maskedTextBox1;
        private Controls.BaseMaskedTextBox baseMaskedTextBox1;
        private Controls.BaseMaskedTextBox baseMaskedTextBox2;
        private Controls.BaseLabel lblStart;
        private Controls.BaseLabel lblEnd;
        private Controls.BaseLabel lblDuration;
        private System.Windows.Forms.DataGridView gvMain;
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
            this.maskedTextBox1 = new TrainingCatalog.Controls.BaseMaskedTextBox();
            this.baseMaskedTextBox1 = new TrainingCatalog.Controls.BaseMaskedTextBox();
            this.baseMaskedTextBox2 = new TrainingCatalog.Controls.BaseMaskedTextBox();
            this.lblStart = new TrainingCatalog.Controls.BaseLabel();
            this.lblEnd = new TrainingCatalog.Controls.BaseLabel();
            this.lblDuration = new TrainingCatalog.Controls.BaseLabel();
            this.gvMain = new System.Windows.Forms.DataGridView();
            this.lstExersizes = new System.Windows.Forms.ListBox();
            this.btnAdd = new TrainingCatalog.Controls.BaseButton();
            this.baseGroupBox1 = new TrainingCatalog.Controls.BaseGroupBox();
            this.ExersizeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Intensivity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Velocity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pulse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            this.baseGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.Location = new System.Drawing.Point(15, 340);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(50, 50);
            this.btnOk.TabIndex = 0;
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBox1.Location = new System.Drawing.Point(123, 8);
            this.maskedTextBox1.Mask = "00:00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(49, 20);
            this.maskedTextBox1.TabIndex = 1;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // baseMaskedTextBox1
            // 
            this.baseMaskedTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.baseMaskedTextBox1.Location = new System.Drawing.Point(123, 33);
            this.baseMaskedTextBox1.Mask = "00:00";
            this.baseMaskedTextBox1.Name = "baseMaskedTextBox1";
            this.baseMaskedTextBox1.Size = new System.Drawing.Size(49, 20);
            this.baseMaskedTextBox1.TabIndex = 2;
            this.baseMaskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // baseMaskedTextBox2
            // 
            this.baseMaskedTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.baseMaskedTextBox2.Location = new System.Drawing.Point(123, 60);
            this.baseMaskedTextBox2.Mask = "0000";
            this.baseMaskedTextBox2.Name = "baseMaskedTextBox2";
            this.baseMaskedTextBox2.Size = new System.Drawing.Size(49, 20);
            this.baseMaskedTextBox2.TabIndex = 4;
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
            this.gvMain.Size = new System.Drawing.Size(563, 385);
            this.gvMain.TabIndex = 8;
            this.gvMain.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvMain_CellEndEdit);
            this.gvMain.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gvMain_RowsAdded);
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
            this.btnAdd.Location = new System.Drawing.Point(115, 340);
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
            this.baseGroupBox1.Size = new System.Drawing.Size(150, 221);
            this.baseGroupBox1.TabIndex = 12;
            this.baseGroupBox1.TabStop = false;
            this.baseGroupBox1.Text = "Вид Кардио";
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
            // CardioSession
            // 
            this.ClientSize = new System.Drawing.Size(753, 402);
            this.Controls.Add(this.baseGroupBox1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gvMain);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.baseMaskedTextBox2);
            this.Controls.Add(this.baseMaskedTextBox1);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.btnOk);
            this.IsShown = true;
            this.MinimumSize = new System.Drawing.Size(593, 413);
            this.Name = "CardioSession";
            this.Load += new System.EventHandler(this.CardioSession_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            this.baseGroupBox1.ResumeLayout(false);
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





    }
}