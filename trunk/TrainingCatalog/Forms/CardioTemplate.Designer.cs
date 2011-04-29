namespace TrainingCatalog.Forms
{
    partial class CardioTemplate
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cardioExersizesControl1 = new TrainingCatalog.Controls.CardioExersizesControl();
            this.Добавить = new System.Windows.Forms.Button();
            this.btnAdd = new TrainingCatalog.Controls.BaseButton();
            this.btnOk = new TrainingCatalog.Controls.BaseButton();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 186);
            this.listBox1.TabIndex = 0;
            // 
            // cardioExersizesControl1
            // 
            this.cardioExersizesControl1.DefaultCardioType = null;
            this.cardioExersizesControl1.Location = new System.Drawing.Point(146, 12);
            this.cardioExersizesControl1.Name = "cardioExersizesControl1";
            this.cardioExersizesControl1.Size = new System.Drawing.Size(575, 348);
            this.cardioExersizesControl1.TabIndex = 1;
            // 
            // Добавить
            // 
            this.Добавить.Location = new System.Drawing.Point(12, 204);
            this.Добавить.Name = "Добавить";
            this.Добавить.Size = new System.Drawing.Size(59, 23);
            this.Добавить.TabIndex = 2;
            this.Добавить.Text = "btnAddNew";
            this.Добавить.UseVisualStyleBackColor = true;
            this.Добавить.Click += new System.EventHandler(this.Добавить_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(82, 296);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 50);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.Location = new System.Drawing.Point(12, 296);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(50, 50);
            this.btnOk.TabIndex = 12;
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // CardioTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 371);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.Добавить);
            this.Controls.Add(this.cardioExersizesControl1);
            this.Controls.Add(this.listBox1);
            this.Name = "CardioTemplate";
            this.Text = "CardioTemplate";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private Controls.CardioExersizesControl cardioExersizesControl1;
        private System.Windows.Forms.Button Добавить;
        private Controls.BaseButton btnAdd;
        private Controls.BaseButton btnOk;
    }
}