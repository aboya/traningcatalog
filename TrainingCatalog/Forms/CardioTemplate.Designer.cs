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
            this.lstExersizes = new System.Windows.Forms.ListBox();
            this.cardioExersizeControl = new TrainingCatalog.Controls.CardioExersizesControl();
            this.btnAdd = new TrainingCatalog.Controls.BaseButton();
            this.btnOk = new TrainingCatalog.Controls.BaseButton();
            this.txtName = new TrainingCatalog.Controls.BaseTextBox();
            this.lblName = new TrainingCatalog.Controls.BaseLabel();
            this.SuspendLayout();
            // 
            // lstExersizes
            // 
            this.lstExersizes.FormattingEnabled = true;
            this.lstExersizes.Location = new System.Drawing.Point(10, 12);
            this.lstExersizes.Name = "lstExersizes";
            this.lstExersizes.Size = new System.Drawing.Size(120, 186);
            this.lstExersizes.TabIndex = 0;
            this.lstExersizes.SelectedIndexChanged += new System.EventHandler(this.lstExersizes_SelectedIndexChanged);
            // 
            // cardioExersizeControl
            // 
            this.cardioExersizeControl.DefaultCardioType = null;
            this.cardioExersizeControl.Location = new System.Drawing.Point(146, 12);
            this.cardioExersizeControl.Margin = new System.Windows.Forms.Padding(4);
            this.cardioExersizeControl.Name = "cardioExersizeControl";
            this.cardioExersizeControl.Size = new System.Drawing.Size(575, 348);
            this.cardioExersizeControl.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(82, 296);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 50);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.Location = new System.Drawing.Point(12, 296);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(50, 50);
            this.btnOk.TabIndex = 12;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(10, 227);
            this.txtName.MaxLength = 99;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(120, 20);
            this.txtName.TabIndex = 14;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(13, 205);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(32, 13);
            this.lblName.TabIndex = 15;
            this.lblName.Text = "Имя:";
            // 
            // CardioTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 371);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cardioExersizeControl);
            this.Controls.Add(this.lstExersizes);
            this.IsShown = true;
            this.Name = "CardioTemplate";
            this.Text = "CardioTemplate";
            this.Load += new System.EventHandler(this.CardioTemplate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstExersizes;
        private Controls.CardioExersizesControl cardioExersizeControl;
        private Controls.BaseButton btnAdd;
        private Controls.BaseButton btnOk;
        private Controls.BaseTextBox txtName;
        private Controls.BaseLabel lblName;
    }
}