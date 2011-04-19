namespace TrainingCatalog.Forms
{
    partial class CardioTraining
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.baseButton1 = new TrainingCatalog.Controls.BaseButton();
            this.baseButton2 = new TrainingCatalog.Controls.BaseButton();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(18, 18);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(194, 18);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(164, 160);
            this.listBox1.TabIndex = 1;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(18, 192);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(340, 162);
            this.zedGraphControl1.TabIndex = 2;
            // 
            // baseButton1
            // 
            this.baseButton1.Location = new System.Drawing.Point(364, 155);
            this.baseButton1.Name = "baseButton1";
            this.baseButton1.Size = new System.Drawing.Size(75, 23);
            this.baseButton1.TabIndex = 3;
            this.baseButton1.Text = "Добавить";
            this.baseButton1.UseVisualStyleBackColor = true;
            this.baseButton1.Click += new System.EventHandler(this.baseButton1_Click);
            // 
            // baseButton2
            // 
            this.baseButton2.Location = new System.Drawing.Point(364, 18);
            this.baseButton2.Name = "baseButton2";
            this.baseButton2.Size = new System.Drawing.Size(75, 23);
            this.baseButton2.TabIndex = 4;
            this.baseButton2.Text = "baseButton2";
            this.baseButton2.UseVisualStyleBackColor = true;
            // 
            // CardioTraining
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 366);
            this.Controls.Add(this.baseButton2);
            this.Controls.Add(this.baseButton1);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.monthCalendar1);
            this.IsShown = true;
            this.Name = "CardioTraining";
            this.Text = "Cardio";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.ListBox listBox1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private Controls.BaseButton baseButton1;
        private Controls.BaseButton baseButton2;

     
    }
}