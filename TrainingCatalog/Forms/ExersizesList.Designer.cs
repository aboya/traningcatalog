namespace TrainingCatalog
{
    partial class ExersizesList
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.chkLstExersizeCategories = new System.Windows.Forms.CheckedListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDescription = new TrainingCatalog.Controls.BaseTextBox();
            this.txtExersizeName = new TrainingCatalog.Controls.BaseTextBox();
            this.TrainingList = new TrainingCatalog.Controls.BaseComboBox();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 116);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 14;
            this.lblDescription.Text = "Описание:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 41);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(124, 13);
            this.lblName.TabIndex = 13;
            this.lblName.Text = "Название упражнения:";
            // 
            // chkLstExersizeCategories
            // 
            this.chkLstExersizeCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkLstExersizeCategories.CheckOnClick = true;
            this.chkLstExersizeCategories.FormattingEnabled = true;
            this.chkLstExersizeCategories.Location = new System.Drawing.Point(257, 57);
            this.chkLstExersizeCategories.Name = "chkLstExersizeCategories";
            this.chkLstExersizeCategories.Size = new System.Drawing.Size(120, 244);
            this.chkLstExersizeCategories.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(302, 307);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 39);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(12, 132);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(239, 169);
            this.txtDescription.TabIndex = 10;
            // 
            // txtExersizeName
            // 
            this.txtExersizeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExersizeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExersizeName.Location = new System.Drawing.Point(12, 57);
            this.txtExersizeName.Multiline = true;
            this.txtExersizeName.Name = "txtExersizeName";
            this.txtExersizeName.Size = new System.Drawing.Size(239, 52);
            this.txtExersizeName.TabIndex = 9;
            // 
            // TrainingList
            // 
            this.TrainingList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TrainingList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TrainingList.FormattingEnabled = true;
            this.TrainingList.Location = new System.Drawing.Point(12, 12);
            this.TrainingList.Name = "TrainingList";
            this.TrainingList.Size = new System.Drawing.Size(365, 21);
            this.TrainingList.TabIndex = 7;
            this.TrainingList.SelectedIndexChanged += new System.EventHandler(this.TrainingList_SelectedIndexChanged);
            // 
            // ExersizesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 358);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.chkLstExersizeCategories);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtExersizeName);
            this.Controls.Add(this.TrainingList);
            this.Name = "ExersizesList";
            this.Text = "ExersizesList";
            this.Load += new System.EventHandler(this.ExersizesList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TrainingCatalog.Controls.BaseTextBox txtExersizeName;
        private TrainingCatalog.Controls.BaseTextBox txtDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckedListBox chkLstExersizeCategories;
        private TrainingCatalog.Controls.BaseComboBox TrainingList;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDescription;
    }
}