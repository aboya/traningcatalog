namespace TrainingCatalog.Forms
{
    partial class CardioAddFromTemplate
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
            this.btnAdd = new TrainingCatalog.Controls.BaseButton();
            this.btnAddSave = new TrainingCatalog.Controls.BaseButton();
            this.btnSave = new TrainingCatalog.Controls.BaseButton();
            this.cbTemplates = new TrainingCatalog.Controls.BaseComboBox();
            this.cardioExersizesControl = new TrainingCatalog.Controls.CardioExersizesControl();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(512, 393);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnAddSave
            // 
            this.btnAddSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddSave.Location = new System.Drawing.Point(93, 393);
            this.btnAddSave.Name = "btnAddSave";
            this.btnAddSave.Size = new System.Drawing.Size(136, 23);
            this.btnAddSave.TabIndex = 3;
            this.btnAddSave.Text = "Сохранить и добавить";
            this.btnAddSave.UseVisualStyleBackColor = true;
            this.btnAddSave.Click += new System.EventHandler(this.btnAddSave_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(12, 393);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbTemplates
            // 
            this.cbTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTemplates.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbTemplates.FormattingEnabled = true;
            this.cbTemplates.Location = new System.Drawing.Point(12, 12);
            this.cbTemplates.Name = "cbTemplates";
            this.cbTemplates.Size = new System.Drawing.Size(575, 21);
            this.cbTemplates.TabIndex = 1;
            this.cbTemplates.SelectionChangeCommitted += new System.EventHandler(this.cbTemplates_SelectionChangeCommitted);
            // 
            // cardioExersizesControl
            // 
            this.cardioExersizesControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cardioExersizesControl.DefaultCardioType = null;
            this.cardioExersizesControl.Location = new System.Drawing.Point(12, 39);
            this.cardioExersizesControl.Name = "cardioExersizesControl";
            this.cardioExersizesControl.Size = new System.Drawing.Size(575, 348);
            this.cardioExersizesControl.TabIndex = 0;
            // 
            // CardioAddFromTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 431);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnAddSave);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbTemplates);
            this.Controls.Add(this.cardioExersizesControl);
            this.IsShown = true;
            this.MinimumSize = new System.Drawing.Size(615, 469);
            this.Name = "CardioAddFromTemplate";
            this.Text = "CardioAddFromTemplate";
            this.Load += new System.EventHandler(this.CardioAddFromTemplate_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CardioExersizesControl cardioExersizesControl;
        private Controls.BaseComboBox cbTemplates;
        private Controls.BaseButton btnSave;
        private Controls.BaseButton btnAddSave;
        private Controls.BaseButton btnAdd;
    }
}