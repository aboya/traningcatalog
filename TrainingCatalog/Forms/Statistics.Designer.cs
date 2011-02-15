namespace TrainingCatalog.Forms
{
    partial class Statistics
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
            this.mcStart = new System.Windows.Forms.MonthCalendar();
            this.mcEnd = new System.Windows.Forms.MonthCalendar();
            this.lstParams = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Stats = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.graph = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // mcStart
            // 
            this.mcStart.Location = new System.Drawing.Point(18, 18);
            this.mcStart.Name = "mcStart";
            this.mcStart.TabIndex = 2;
            this.mcStart.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mcStart_DateChanged);
            // 
            // mcEnd
            // 
            this.mcEnd.Location = new System.Drawing.Point(200, 18);
            this.mcEnd.Name = "mcEnd";
            this.mcEnd.TabIndex = 3;
            // 
            // lstParams
            // 
            this.lstParams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.Stats});
            this.lstParams.Location = new System.Drawing.Point(18, 192);
            this.lstParams.Name = "lstParams";
            this.lstParams.Size = new System.Drawing.Size(164, 190);
            this.lstParams.TabIndex = 4;
            this.lstParams.UseCompatibleStateImageBehavior = false;
            this.lstParams.View = System.Windows.Forms.View.Details;
            // 
            // name
            // 
            this.name.Text = "#";
            // 
            // Stats
            // 
            this.Stats.Text = "Stats";
            // 
            // graph
            // 
            this.graph.Location = new System.Drawing.Point(200, 192);
            this.graph.Name = "graph";
            this.graph.ScrollGrace = 0D;
            this.graph.ScrollMaxX = 0D;
            this.graph.ScrollMaxY = 0D;
            this.graph.ScrollMaxY2 = 0D;
            this.graph.ScrollMinX = 0D;
            this.graph.ScrollMinY = 0D;
            this.graph.ScrollMinY2 = 0D;
            this.graph.Size = new System.Drawing.Size(344, 190);
            this.graph.TabIndex = 5;
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 394);
            this.Controls.Add(this.graph);
            this.Controls.Add(this.lstParams);
            this.Controls.Add(this.mcEnd);
            this.Controls.Add(this.mcStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Statistics";
            this.Text = "Statistics";
            this.Load += new System.EventHandler(this.Statistics_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar mcStart;
        private System.Windows.Forms.MonthCalendar mcEnd;
        private System.Windows.Forms.ListView lstParams;
        private ZedGraph.ZedGraphControl graph;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader Stats;
    }
}