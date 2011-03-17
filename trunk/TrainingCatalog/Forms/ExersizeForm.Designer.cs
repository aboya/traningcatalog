namespace TrainingCatalog
{
    partial class ExersizeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.chkLstExersizeCategories = new System.Windows.Forms.CheckedListBox();
            this.btnAddExersize = new System.Windows.Forms.Button();
            this.textBox2 = new TrainingCatalog.Controls.BaseTextBox();
            this.textBox1 = new TrainingCatalog.Controls.BaseTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Описание упражнения:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(13, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(124, 13);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Название упражнения:";
            // 
            // chkLstExersizeCategories
            // 
            this.chkLstExersizeCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkLstExersizeCategories.CheckOnClick = true;
            this.chkLstExersizeCategories.FormattingEnabled = true;
            this.chkLstExersizeCategories.Location = new System.Drawing.Point(342, 28);
            this.chkLstExersizeCategories.Name = "chkLstExersizeCategories";
            this.chkLstExersizeCategories.Size = new System.Drawing.Size(113, 214);
            this.chkLstExersizeCategories.TabIndex = 5;
            // 
            // btnAddExersize
            // 
            this.btnAddExersize.Location = new System.Drawing.Point(378, 248);
            this.btnAddExersize.Name = "btnAddExersize";
            this.btnAddExersize.Size = new System.Drawing.Size(75, 38);
            this.btnAddExersize.TabIndex = 3;
            this.btnAddExersize.Text = "Добавить";
            this.btnAddExersize.UseVisualStyleBackColor = true;
            this.btnAddExersize.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Location = new System.Drawing.Point(12, 102);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(324, 140);
            this.textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(12, 28);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(324, 48);
            this.textBox1.TabIndex = 1;
            // 
            // ExersizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(460, 294);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.chkLstExersizeCategories);
            this.Controls.Add(this.btnAddExersize);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ExersizeForm";
            this.Text = "Exersize";
            this.Load += new System.EventHandler(this.ExersizeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TrainingCatalog.Controls.BaseTextBox textBox1;
        private TrainingCatalog.Controls.BaseTextBox textBox2;
        private System.Windows.Forms.Button btnAddExersize;
        private System.Windows.Forms.CheckedListBox chkLstExersizeCategories;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label1;
    }
}