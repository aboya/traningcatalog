namespace TrainingCatalog.Forms
{
    partial class about
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
            this.pbApp = new System.Windows.Forms.PictureBox();
            this.lblInfo = new TrainingCatalog.Controls.BaseLabel();
            this.lblAuthor = new TrainingCatalog.Controls.BaseLabel();
            this.lblEmail = new TrainingCatalog.Controls.BaseLabel();
            this.label1 = new TrainingCatalog.Controls.BaseLabel();
            this.lblFio = new TrainingCatalog.Controls.BaseLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbApp)).BeginInit();
            this.SuspendLayout();
            // 
            // pbApp
            // 
            this.pbApp.Location = new System.Drawing.Point(12, 24);
            this.pbApp.Name = "pbApp";
            this.pbApp.Size = new System.Drawing.Size(100, 78);
            this.pbApp.TabIndex = 0;
            this.pbApp.TabStop = false;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInfo.Location = new System.Drawing.Point(144, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(148, 18);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Training Catalog";
            // 
            // lblAuthor
            // 
            this.lblAuthor.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAuthor.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblAuthor.Location = new System.Drawing.Point(185, 70);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(130, 20);
            this.lblAuthor.TabIndex = 2;
            this.lblAuthor.Text = "aboimov@gmail.com";
            this.lblAuthor.Click += new System.EventHandler(this.lblAuthor_Click);
            this.lblAuthor.MouseLeave += new System.EventHandler(this.lblAuthor_MouseLeave);
            this.lblAuthor.MouseHover += new System.EventHandler(this.lblAuthor_MouseHover);
            this.lblAuthor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblAuthor_MouseMove);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(144, 70);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Author:";
            // 
            // lblFio
            // 
            this.lblFio.AutoSize = true;
            this.lblFio.Location = new System.Drawing.Point(185, 45);
            this.lblFio.Name = "lblFio";
            this.lblFio.Size = new System.Drawing.Size(84, 13);
            this.lblFio.TabIndex = 5;
            this.lblFio.Text = "Sergey Aboimov";
            // 
            // about
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 140);
            this.Controls.Add(this.lblFio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.pbApp);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "about";
            this.Text = "About";
            this.Load += new System.EventHandler(this.about_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbApp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbApp;
        private TrainingCatalog.Controls.BaseLabel lblInfo;
        private TrainingCatalog.Controls.BaseLabel lblAuthor;
        private TrainingCatalog.Controls.BaseLabel lblEmail;
        private TrainingCatalog.Controls.BaseLabel label1;
        private TrainingCatalog.Controls.BaseLabel lblFio;
    }
}