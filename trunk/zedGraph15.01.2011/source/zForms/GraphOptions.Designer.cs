namespace ZedGraph.zForms
{
    partial class GraphOptions
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
            this.chkMajorY = new System.Windows.Forms.CheckBox();
            this.chkMinorX = new System.Windows.Forms.CheckBox();
            this.chkMajorX = new System.Windows.Forms.CheckBox();
            this.chkMinorY = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkMajorY
            // 
            this.chkMajorY.AutoSize = true;
            this.chkMajorY.Location = new System.Drawing.Point(13, 13);
            this.chkMajorY.Name = "chkMajorY";
            this.chkMajorY.Size = new System.Drawing.Size(78, 17);
            this.chkMajorY.TabIndex = 0;
            this.chkMajorY.Text = "MajorYGrid";
            this.chkMajorY.UseVisualStyleBackColor = true;
            // 
            // chkMinorX
            // 
            this.chkMinorX.AutoSize = true;
            this.chkMinorX.Location = new System.Drawing.Point(119, 36);
            this.chkMinorX.Name = "chkMinorX";
            this.chkMinorX.Size = new System.Drawing.Size(78, 17);
            this.chkMinorX.TabIndex = 1;
            this.chkMinorX.Text = "MinorXGrid";
            this.chkMinorX.UseVisualStyleBackColor = true;
            // 
            // chkMajorX
            // 
            this.chkMajorX.AutoSize = true;
            this.chkMajorX.Location = new System.Drawing.Point(119, 13);
            this.chkMajorX.Name = "chkMajorX";
            this.chkMajorX.Size = new System.Drawing.Size(78, 17);
            this.chkMajorX.TabIndex = 2;
            this.chkMajorX.Text = "MajorXGrid";
            this.chkMajorX.UseVisualStyleBackColor = true;
            // 
            // chkMinorY
            // 
            this.chkMinorY.AutoSize = true;
            this.chkMinorY.Location = new System.Drawing.Point(13, 36);
            this.chkMinorY.Name = "chkMinorY";
            this.chkMinorY.Size = new System.Drawing.Size(78, 17);
            this.chkMinorY.TabIndex = 3;
            this.chkMinorY.Text = "MinorYGrid";
            this.chkMinorY.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(119, 59);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // GraphOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 94);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkMinorY);
            this.Controls.Add(this.chkMajorX);
            this.Controls.Add(this.chkMinorX);
            this.Controls.Add(this.chkMajorY);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GraphOptions";
            this.Text = "GraphOptions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkMajorY;
        private System.Windows.Forms.CheckBox chkMinorX;
        private System.Windows.Forms.CheckBox chkMajorX;
        private System.Windows.Forms.CheckBox chkMinorY;
        private System.Windows.Forms.Button btnSave;
    }
}