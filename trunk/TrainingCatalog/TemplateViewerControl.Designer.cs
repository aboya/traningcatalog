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
            this.gvMain = new DevExpress.XtraGrid.GridControl();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ExersizeCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ExersizeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Weight = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Count = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gvMain
            // 
            this.gvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvMain.Location = new System.Drawing.Point(3, 3);
            this.gvMain.MainView = this.gridView1;
            this.gvMain.Name = "gvMain";
            this.gvMain.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemComboBox2});
            this.gvMain.Size = new System.Drawing.Size(563, 324);
            this.gvMain.TabIndex = 0;
            this.gvMain.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AccessibleName = "ExersizeCategory";
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ExersizeCategory,
            this.ExersizeName,
            this.Weight,
            this.Count});
            this.gridView1.GridControl = this.gvMain;
            this.gridView1.Name = "gridView1";
            // 
            // ExersizeCategory
            // 
            this.ExersizeCategory.Caption = "gridColumn1";
            this.ExersizeCategory.ColumnEdit = this.repositoryItemComboBox1;
            this.ExersizeCategory.Name = "ExersizeCategory";
            this.ExersizeCategory.Visible = true;
            this.ExersizeCategory.VisibleIndex = 0;
            // 
            // ExersizeName
            // 
            this.ExersizeName.Caption = "gridColumn2";
            this.ExersizeName.ColumnEdit = this.repositoryItemComboBox2;
            this.ExersizeName.Name = "ExersizeName";
            this.ExersizeName.Visible = true;
            this.ExersizeName.VisibleIndex = 1;
            // 
            // Weight
            // 
            this.Weight.Caption = "gridColumn3";
            this.Weight.Name = "Weight";
            this.Weight.Visible = true;
            this.Weight.VisibleIndex = 2;
            // 
            // Count
            // 
            this.Count.Caption = "gridColumn4";
            this.Count.Name = "Count";
            this.Count.Visible = true;
            this.Count.VisibleIndex = 3;
            // 
            // TemplateViewerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gvMain);
            this.Name = "TemplateViewerControl";
            this.Size = new System.Drawing.Size(567, 329);
            ((System.ComponentModel.ISupportInitialize)(this.gvMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gvMain;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ExersizeCategory;
        private DevExpress.XtraGrid.Columns.GridColumn ExersizeName;
        private DevExpress.XtraGrid.Columns.GridColumn Weight;
        private DevExpress.XtraGrid.Columns.GridColumn Count;
    }
}
