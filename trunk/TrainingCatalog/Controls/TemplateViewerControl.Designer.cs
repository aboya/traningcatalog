namespace TrainingCatalog
{
    partial class TemplateViewerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gv_templates = new TrainingCatalog.Controls.CustomDataGridView();
            this.Category = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Exersize = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remove = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gv_templates)).BeginInit();
            this.SuspendLayout();
            // 
            // gv_templates
            // 
            this.gv_templates.AllowUserToAddRows = false;
            this.gv_templates.AllowUserToDeleteRows = false;
            this.gv_templates.AllowUserToResizeRows = false;
            this.gv_templates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gv_templates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_templates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Category,
            this.Exersize,
            this.Weight,
            this.Count,
            this.Remove});
            this.gv_templates.Location = new System.Drawing.Point(3, 3);
            this.gv_templates.MultiSelect = false;
            this.gv_templates.Name = "gv_templates";
            this.gv_templates.RowHeadersVisible = false;
            this.gv_templates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_templates.Size = new System.Drawing.Size(624, 390);
            this.gv_templates.TabIndex = 0;
            this.gv_templates.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_templates_CellClick);
            this.gv_templates.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_templates_CellContentClick);
            this.gv_templates.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_templates_CellValueChanged);
            this.gv_templates.CurrentCellDirtyStateChanged += new System.EventHandler(this.gv_templates_CurrentCellDirtyStateChanged);
            this.gv_templates.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gv_templates_EditingControlShowing);
            this.gv_templates.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.gv_templates_RowsAdded);
            this.gv_templates.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gv_templates_KeyDown);
            this.gv_templates.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gv_templates_KeyPress);
            // 
            // Category
            // 
            this.Category.HeaderText = "Column1";
            this.Category.Name = "Category";
            this.Category.Width = 150;
            // 
            // Exersize
            // 
            this.Exersize.HeaderText = "Column2";
            this.Exersize.Name = "Exersize";
            this.Exersize.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Exersize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Exersize.Width = 300;
            // 
            // Weight
            // 
            this.Weight.FillWeight = 40F;
            this.Weight.HeaderText = "Weight";
            this.Weight.Name = "Weight";
            this.Weight.Width = 40;
            // 
            // Count
            // 
            this.Count.FillWeight = 40F;
            this.Count.HeaderText = "Count";
            this.Count.Name = "Count";
            this.Count.Width = 40;
            // 
            // Remove
            // 
            this.Remove.FillWeight = 50F;
            this.Remove.HeaderText = "Remove";
            this.Remove.Name = "Remove";
            this.Remove.Width = 50;
            // 
            // TemplateViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gv_templates);
            this.Name = "TemplateViewerControl";
            this.Size = new System.Drawing.Size(629, 395);
            this.Load += new System.EventHandler(this.TemplateViewerControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_templates)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewButtonColumn Remove;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewComboBoxColumn Exersize;
        private System.Windows.Forms.DataGridViewComboBoxColumn Category;
        private TrainingCatalog.Controls.CustomDataGridView gv_templates;



    }
}
