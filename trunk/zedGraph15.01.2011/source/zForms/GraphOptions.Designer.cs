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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkLegend = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkMajorY
            // 
            this.chkMajorY.AutoSize = true;
            this.chkMajorY.Location = new System.Drawing.Point(6, 19);
            this.chkMajorY.Name = "chkMajorY";
            this.chkMajorY.Size = new System.Drawing.Size(78, 17);
            this.chkMajorY.TabIndex = 0;
            this.chkMajorY.Text = "MajorYGrid";
            this.chkMajorY.UseVisualStyleBackColor = true;
            // 
            // chkMinorX
            // 
            this.chkMinorX.AutoSize = true;
            this.chkMinorX.Location = new System.Drawing.Point(112, 42);
            this.chkMinorX.Name = "chkMinorX";
            this.chkMinorX.Size = new System.Drawing.Size(78, 17);
            this.chkMinorX.TabIndex = 1;
            this.chkMinorX.Text = "MinorXGrid";
            this.chkMinorX.UseVisualStyleBackColor = true;
            // 
            // chkMajorX
            // 
            this.chkMajorX.AutoSize = true;
            this.chkMajorX.Location = new System.Drawing.Point(112, 19);
            this.chkMajorX.Name = "chkMajorX";
            this.chkMajorX.Size = new System.Drawing.Size(78, 17);
            this.chkMajorX.TabIndex = 2;
            this.chkMajorX.Text = "MajorXGrid";
            this.chkMajorX.UseVisualStyleBackColor = true;
            // 
            // chkMinorY
            // 
            this.chkMinorY.AutoSize = true;
            this.chkMinorY.Location = new System.Drawing.Point(6, 42);
            this.chkMinorY.Name = "chkMinorY";
            this.chkMinorY.Size = new System.Drawing.Size(78, 17);
            this.chkMinorY.TabIndex = 3;
            this.chkMinorY.Text = "MinorYGrid";
            this.chkMinorY.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(146, 129);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 44);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkMinorY);
            this.groupBox1.Controls.Add(this.chkMajorY);
            this.groupBox1.Controls.Add(this.chkMinorX);
            this.groupBox1.Controls.Add(this.chkMajorX);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 80);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grid Options";
            // 
            // chkLegend
            // 
            this.chkLegend.AutoSize = true;
            this.chkLegend.Location = new System.Drawing.Point(18, 99);
            this.chkLegend.Name = "chkLegend";
            this.chkLegend.Size = new System.Drawing.Size(62, 17);
            this.chkLegend.TabIndex = 6;
            this.chkLegend.Text = "Legend";
            this.chkLegend.UseVisualStyleBackColor = true;
            // 
            // GraphOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 180);
            this.Controls.Add(this.chkLegend);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GraphOptions";
            this.Text = "GraphOptions";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkMajorY;
        private System.Windows.Forms.CheckBox chkMinorX;
        private System.Windows.Forms.CheckBox chkMajorX;
        private System.Windows.Forms.CheckBox chkMinorY;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkLegend;
    }
}