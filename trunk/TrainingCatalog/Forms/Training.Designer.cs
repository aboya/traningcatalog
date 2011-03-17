namespace TrainingCatalog
{
    partial class Training
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
            this.btnAddFromTemplate = new System.Windows.Forms.Button();
            this.btnSaveWeight = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBodyWeight = new TrainingCatalog.Controls.FloatNumberTextBox();
            this.cbTraningCategory = new TrainingCatalog.Controls.BaseComboBox();
            this.TrainingList = new TrainingCatalog.Controls.BaseComboBox();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.txtCount = new TrainingCatalog.Controls.NullableTextBox();
            this.txtWeight = new TrainingCatalog.Controls.NullableTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AddExersize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddFromTemplate
            // 
            this.btnAddFromTemplate.Location = new System.Drawing.Point(369, 35);
            this.btnAddFromTemplate.Name = "btnAddFromTemplate";
            this.btnAddFromTemplate.Size = new System.Drawing.Size(158, 21);
            this.btnAddFromTemplate.TabIndex = 10;
            this.btnAddFromTemplate.Text = "Добавить из шаблона";
            this.btnAddFromTemplate.UseVisualStyleBackColor = true;
            this.btnAddFromTemplate.Click += new System.EventHandler(this.btnAddFromTemplate_Click);
            // 
            // btnSaveWeight
            // 
            this.btnSaveWeight.Location = new System.Drawing.Point(258, 35);
            this.btnSaveWeight.Name = "btnSaveWeight";
            this.btnSaveWeight.Size = new System.Drawing.Size(105, 21);
            this.btnSaveWeight.TabIndex = 9;
            this.btnSaveWeight.Text = "Сохранить вес";
            this.btnSaveWeight.UseVisualStyleBackColor = true;
            this.btnSaveWeight.Click += new System.EventHandler(this.btnSaveWeight_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Вес тела:";
            // 
            // txtBodyWeight
            // 
            this.txtBodyWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBodyWeight.Location = new System.Drawing.Point(204, 35);
            this.txtBodyWeight.Name = "txtBodyWeight";
            this.txtBodyWeight.Size = new System.Drawing.Size(48, 20);
            this.txtBodyWeight.TabIndex = 7;
            // 
            // cbTraningCategory
            // 
            this.cbTraningCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbTraningCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbTraningCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTraningCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbTraningCategory.FormattingEnabled = true;
            this.cbTraningCategory.Location = new System.Drawing.Point(12, 35);
            this.cbTraningCategory.Name = "cbTraningCategory";
            this.cbTraningCategory.Size = new System.Drawing.Size(128, 21);
            this.cbTraningCategory.TabIndex = 6;
            this.cbTraningCategory.SelectedIndexChanged += new System.EventHandler(this.cbTraningCategory_SelectedIndexChanged);
            // 
            // TrainingList
            // 
            this.TrainingList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TrainingList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.TrainingList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.TrainingList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TrainingList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TrainingList.FormattingEnabled = true;
            this.TrainingList.Location = new System.Drawing.Point(258, 11);
            this.TrainingList.Name = "TrainingList";
            this.TrainingList.Size = new System.Drawing.Size(269, 21);
            this.TrainingList.TabIndex = 5;
            // 
            // dateTime
            // 
            this.dateTime.Location = new System.Drawing.Point(12, 12);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(128, 20);
            this.dateTime.TabIndex = 4;
            this.dateTime.ValueChanged += new System.EventHandler(this.dateTime_ValueChanged);
            // 
            // txtCount
            // 
            this.txtCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCount.ForeColor = System.Drawing.Color.Gray;
            this.txtCount.Location = new System.Drawing.Point(204, 12);
            this.txtCount.Name = "txtCount";
            this.txtCount.NullableText = "Количество";
            this.txtCount.Size = new System.Drawing.Size(48, 20);
            this.txtCount.TabIndex = 3;
            this.txtCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCount_KeyDown);
            // 
            // txtWeight
            // 
            this.txtWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWeight.ForeColor = System.Drawing.Color.Gray;
            this.txtWeight.Location = new System.Drawing.Point(146, 12);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.NullableText = "Вес";
            this.txtWeight.Size = new System.Drawing.Size(51, 20);
            this.txtWeight.TabIndex = 2;
            this.txtWeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWeight_KeyDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(544, 268);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // AddExersize
            // 
            this.AddExersize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddExersize.Location = new System.Drawing.Point(533, 15);
            this.AddExersize.Name = "AddExersize";
            this.AddExersize.Size = new System.Drawing.Size(32, 32);
            this.AddExersize.TabIndex = 0;
            this.AddExersize.UseVisualStyleBackColor = true;
            this.AddExersize.Click += new System.EventHandler(this.AddExersize_Click);
            // 
            // Training
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 342);
            this.Controls.Add(this.btnAddFromTemplate);
            this.Controls.Add(this.btnSaveWeight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBodyWeight);
            this.Controls.Add(this.cbTraningCategory);
            this.Controls.Add(this.TrainingList);
            this.Controls.Add(this.dateTime);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.AddExersize);
            this.Name = "Training";
            this.Text = "Training";
            this.Load += new System.EventHandler(this.Training_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddExersize;
        private TrainingCatalog.Controls.NullableTextBox txtWeight;
        private TrainingCatalog.Controls.NullableTextBox txtCount;
        private System.Windows.Forms.DateTimePicker dateTime;
        private TrainingCatalog.Controls.BaseComboBox TrainingList;
        private System.Windows.Forms.DataGridView dataGridView1;
        private TrainingCatalog.Controls.BaseComboBox cbTraningCategory;
        private TrainingCatalog.Controls.FloatNumberTextBox txtBodyWeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaveWeight;
        private System.Windows.Forms.Button btnAddFromTemplate;
    }
}