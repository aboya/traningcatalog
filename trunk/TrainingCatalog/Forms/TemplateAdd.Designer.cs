namespace TrainingCatalog
{
    partial class TemplateAdd
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
            this.btnTemplateAdd = new TrainingCatalog.Controls.BaseButton();
            this.ddlTemplates = new TrainingCatalog.Controls.BaseComboBox();
            this.btnSaveTemplateAndAdd = new TrainingCatalog.Controls.BaseButton();
            this.btnSaveTemplate = new TrainingCatalog.Controls.BaseButton();
            this.lblTemplateName = new TrainingCatalog.Controls.BaseLabel();
            this.btnAdd = new TrainingCatalog.Controls.BaseButton();
            this.ucTemplate = new TrainingCatalog.TemplateViewerControl();
            this.SuspendLayout();
            // 
            // btnTemplateAdd
            // 
            this.btnTemplateAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTemplateAdd.Location = new System.Drawing.Point(807, 6);
            this.btnTemplateAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTemplateAdd.Name = "btnTemplateAdd";
            this.btnTemplateAdd.Size = new System.Drawing.Size(45, 26);
            this.btnTemplateAdd.TabIndex = 7;
            this.btnTemplateAdd.Text = "+";
            this.btnTemplateAdd.UseVisualStyleBackColor = true;
            this.btnTemplateAdd.Click += new System.EventHandler(this.btnTemplateAdd_Click);
            // 
            // ddlTemplates
            // 
            this.ddlTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlTemplates.BackColor = System.Drawing.SystemColors.Window;
            this.ddlTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlTemplates.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ddlTemplates.FormattingEnabled = true;
            this.ddlTemplates.Location = new System.Drawing.Point(127, 6);
            this.ddlTemplates.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ddlTemplates.Name = "ddlTemplates";
            this.ddlTemplates.Size = new System.Drawing.Size(671, 24);
            this.ddlTemplates.TabIndex = 5;
            this.ddlTemplates.SelectedIndexChanged += new System.EventHandler(this.ddlTemplates_SelectedIndexChanged);
            // 
            // btnSaveTemplateAndAdd
            // 
            this.btnSaveTemplateAndAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveTemplateAndAdd.Location = new System.Drawing.Point(172, 530);
            this.btnSaveTemplateAndAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveTemplateAndAdd.Name = "btnSaveTemplateAndAdd";
            this.btnSaveTemplateAndAdd.Size = new System.Drawing.Size(180, 28);
            this.btnSaveTemplateAndAdd.TabIndex = 4;
            this.btnSaveTemplateAndAdd.Text = "Сохранить и добавить";
            this.btnSaveTemplateAndAdd.UseVisualStyleBackColor = true;
            this.btnSaveTemplateAndAdd.Click += new System.EventHandler(this.btnSaveTemplateAndAdd_Click);
            // 
            // btnSaveTemplate
            // 
            this.btnSaveTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveTemplate.Location = new System.Drawing.Point(21, 530);
            this.btnSaveTemplate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveTemplate.Name = "btnSaveTemplate";
            this.btnSaveTemplate.Size = new System.Drawing.Size(143, 28);
            this.btnSaveTemplate.TabIndex = 3;
            this.btnSaveTemplate.Text = "Сохранить шаблон";
            this.btnSaveTemplate.UseVisualStyleBackColor = true;
            this.btnSaveTemplate.Click += new System.EventHandler(this.btnSaveTemplate_Click);
            // 
            // lblTemplateName
            // 
            this.lblTemplateName.AutoSize = true;
            this.lblTemplateName.Location = new System.Drawing.Point(17, 11);
            this.lblTemplateName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTemplateName.Name = "lblTemplateName";
            this.lblTemplateName.Size = new System.Drawing.Size(98, 17);
            this.lblTemplateName.TabIndex = 2;
            this.lblTemplateName.Text = "Имя шаблона";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(753, 530);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 28);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ucTemplate
            // 
            this.ucTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucTemplate.Location = new System.Drawing.Point(16, 39);
            this.ucTemplate.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ucTemplate.Name = "ucTemplate";
            this.ucTemplate.Size = new System.Drawing.Size(839, 486);
            this.ucTemplate.TabIndex = 6;
            // 
            // TemplateAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 574);
            this.Controls.Add(this.btnTemplateAdd);
            this.Controls.Add(this.ucTemplate);
            this.Controls.Add(this.ddlTemplates);
            this.Controls.Add(this.btnSaveTemplateAndAdd);
            this.Controls.Add(this.btnSaveTemplate);
            this.Controls.Add(this.lblTemplateName);
            this.Controls.Add(this.btnAdd);
            this.IsShown = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TemplateAdd";
            this.Text = "TemplateAdd";
            this.Load += new System.EventHandler(this.TemplateAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TrainingCatalog.Controls.BaseButton btnAdd;
        private TrainingCatalog.Controls.BaseLabel lblTemplateName;
        private TrainingCatalog.Controls.BaseButton btnSaveTemplate;
        private TrainingCatalog.Controls.BaseButton btnSaveTemplateAndAdd;
        private TrainingCatalog.Controls.BaseComboBox ddlTemplates;
        private TemplateViewerControl ucTemplate;
        private TrainingCatalog.Controls.BaseButton btnTemplateAdd;
    }
}