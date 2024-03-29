﻿namespace TrainingCatalog
{
    partial class EditTemplate
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
            this.btnCancel = new TrainingCatalog.Controls.BaseButton();
            this.txtTemplateName = new TrainingCatalog.Controls.BaseTextBox();
            this.lblName = new TrainingCatalog.Controls.BaseLabel();
            this.btnAddExersize = new TrainingCatalog.Controls.BaseButton();
            this.templateViewerControl = new TrainingCatalog.TemplateViewerControl();
            this.btnOk = new TrainingCatalog.Controls.BaseButton();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(573, 438);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtTemplateName
            // 
            this.txtTemplateName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTemplateName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTemplateName.Location = new System.Drawing.Point(78, 7);
            this.txtTemplateName.Name = "txtTemplateName";
            this.txtTemplateName.Size = new System.Drawing.Size(530, 20);
            this.txtTemplateName.TabIndex = 4;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Название:";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAddExersize
            // 
            this.btnAddExersize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddExersize.Location = new System.Drawing.Point(614, 7);
            this.btnAddExersize.Name = "btnAddExersize";
            this.btnAddExersize.Size = new System.Drawing.Size(27, 20);
            this.btnAddExersize.TabIndex = 6;
            this.btnAddExersize.Text = "+";
            this.btnAddExersize.UseVisualStyleBackColor = true;
            this.btnAddExersize.Click += new System.EventHandler(this.btnAddExersize_Click);
            // 
            // templateViewerControl
            // 
            this.templateViewerControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.templateViewerControl.Location = new System.Drawing.Point(15, 33);
            this.templateViewerControl.Name = "templateViewerControl";
            this.templateViewerControl.Size = new System.Drawing.Size(626, 398);
            this.templateViewerControl.TabIndex = 7;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(499, 437);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(68, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Сохранить";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // EditTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 473);
            this.Controls.Add(this.templateViewerControl);
            this.Controls.Add(this.btnAddExersize);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtTemplateName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "EditTemplate";
            this.Text = "Редактирование шаблона";
            this.Load += new System.EventHandler(this.EditTemplate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TrainingCatalog.Controls.BaseButton btnCancel;
        private TrainingCatalog.Controls.BaseTextBox txtTemplateName;
        private TrainingCatalog.Controls.BaseLabel lblName;
        private TrainingCatalog.Controls.BaseButton btnAddExersize;
        private TemplateViewerControl templateViewerControl;
        private TrainingCatalog.Controls.BaseButton btnOk;
    }
}