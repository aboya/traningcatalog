namespace TrainingCatalog
{
    partial class Perfomance
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
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.TrainingList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 12);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0;
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(328, 232);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // TrainingList
            // 
            this.TrainingList.FormattingEnabled = true;
            this.TrainingList.Location = new System.Drawing.Point(12, 250);
            this.TrainingList.Name = "TrainingList";
            this.TrainingList.Size = new System.Drawing.Size(328, 21);
            this.TrainingList.TabIndex = 6;
            this.TrainingList.SelectedIndexChanged += new System.EventHandler(this.TrainingList_SelectedIndexChanged);
            // 
            // Perfomance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 283);
            this.Controls.Add(this.TrainingList);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "Perfomance";
            this.Text = "Perfomance";
            this.Load += new System.EventHandler(this.Perfomance_Load);
            this.Resize += new System.EventHandler(this.Perfomance_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ComboBox TrainingList;
    }
}