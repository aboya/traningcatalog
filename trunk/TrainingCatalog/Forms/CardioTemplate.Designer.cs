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
            this.SuspendLayout();
            // 
            // lstExersizes
            // 
            this.lstExersizes.FormattingEnabled = true;
            this.lstExersizes.ItemHeight = 16;
            this.lstExersizes.Location = new System.Drawing.Point(13, 15);
            this.lstExersizes.Margin = new System.Windows.Forms.Padding(4);
            this.lstExersizes.Name = "lstExersizes";
            this.lstExersizes.Size = new System.Drawing.Size(159, 228);
            this.lstExersizes.TabIndex = 0;
            this.lstExersizes.SelectedIndexChanged += new System.EventHandler(this.lstExersizes_SelectedIndexChanged);
            // 
            // cardioExersizeControl
            // 
            this.cardioExersizeControl.DefaultCardioType = null;
            this.cardioExersizeControl.Location = new System.Drawing.Point(195, 15);
            this.cardioExersizeControl.Margin = new System.Windows.Forms.Padding(5);
            this.cardioExersizeControl.Name = "cardioExersizeControl";
            this.cardioExersizeControl.Size = new System.Drawing.Size(767, 428);
            this.cardioExersizeControl.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(109, 364);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(67, 62);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.Location = new System.Drawing.Point(16, 364);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(67, 62);
            this.btnOk.TabIndex = 12;
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // CardioTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 457);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cardioExersizeControl);
            this.Controls.Add(this.lstExersizes);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CardioTemplate";
            this.Text = "CardioTemplate";
            this.Load += new System.EventHandler(this.CardioTemplate_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstExersizes;
        private Controls.CardioExersizesControl cardioExersizeControl;
        private Controls.BaseButton btnAdd;
        private Controls.BaseButton btnOk;
    }
}