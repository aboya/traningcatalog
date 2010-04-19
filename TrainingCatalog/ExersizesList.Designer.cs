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
            this.txtExersizeName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkLstExersizeCategories = new System.Windows.Forms.CheckedListBox();
            this.TrainingList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtExersizeName
            // 
            this.txtExersizeName.Location = new System.Drawing.Point(12, 39);
            this.txtExersizeName.Multiline = true;
            this.txtExersizeName.Name = "txtExersizeName";
            this.txtExersizeName.Size = new System.Drawing.Size(234, 53);
            this.txtExersizeName.TabIndex = 9;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(12, 98);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(234, 95);
            this.txtDescription.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(405, 249);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 43);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkLstExersizeCategories
            // 
            this.chkLstExersizeCategories.CheckOnClick = true;
            this.chkLstExersizeCategories.FormattingEnabled = true;
            this.chkLstExersizeCategories.Location = new System.Drawing.Point(252, 39);
            this.chkLstExersizeCategories.Name = "chkLstExersizeCategories";
            this.chkLstExersizeCategories.Size = new System.Drawing.Size(120, 154);
            this.chkLstExersizeCategories.TabIndex = 12;
            // 
            // TrainingList
            // 
            this.TrainingList.FormattingEnabled = true;
            this.TrainingList.Location = new System.Drawing.Point(12, 12);
            this.TrainingList.Name = "TrainingList";
            this.TrainingList.Size = new System.Drawing.Size(352, 21);
            this.TrainingList.TabIndex = 7;
            this.TrainingList.SelectedIndexChanged += new System.EventHandler(this.TrainingList_SelectedIndexChanged);
            // 
            // ExersizesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 304);
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

        private System.Windows.Forms.TextBox txtExersizeName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckedListBox chkLstExersizeCategories;
        private System.Windows.Forms.ComboBox TrainingList;
    }
}