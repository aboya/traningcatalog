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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnAddExersize = new System.Windows.Forms.Button();
            this.chkLstExersizeCategories = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 28);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(324, 72);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 106);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(324, 113);
            this.textBox2.TabIndex = 2;
            // 
            // btnAddExersize
            // 
            this.btnAddExersize.Location = new System.Drawing.Point(261, 225);
            this.btnAddExersize.Name = "btnAddExersize";
            this.btnAddExersize.Size = new System.Drawing.Size(75, 33);
            this.btnAddExersize.TabIndex = 3;
            this.btnAddExersize.Text = "Добавить";
            this.btnAddExersize.UseVisualStyleBackColor = true;
            this.btnAddExersize.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkLstExersizeCategories
            // 
            this.chkLstExersizeCategories.CheckOnClick = true;
            this.chkLstExersizeCategories.FormattingEnabled = true;
            this.chkLstExersizeCategories.Location = new System.Drawing.Point(12, 225);
            this.chkLstExersizeCategories.Name = "chkLstExersizeCategories";
            this.chkLstExersizeCategories.Size = new System.Drawing.Size(113, 94);
            this.chkLstExersizeCategories.TabIndex = 5;
            // 
            // ExersizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(347, 354);
            this.Controls.Add(this.chkLstExersizeCategories);
            this.Controls.Add(this.btnAddExersize);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "ExersizeForm";
            this.Text = "Exersize";
            this.Load += new System.EventHandler(this.ExersizeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnAddExersize;
        private System.Windows.Forms.CheckedListBox chkLstExersizeCategories;
    }
}