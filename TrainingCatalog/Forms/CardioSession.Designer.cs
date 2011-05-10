using System.Windows.Forms;
namespace TrainingCatalog.Forms
{
    partial class CardioSession
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TrainingCatalog.Controls.BaseMaskedTextBox txtBeginTime;
        private Controls.BaseMaskedTextBox txtEndTime;
        private Controls.BaseLabel lblStart;
        private Controls.BaseLabel lblEnd;
        private System.Windows.Forms.ListBox lstExersizes;
        private TrainingCatalog.Controls.BaseButton btnAdd;
        private Controls.BaseGroupBox baseGroupBox1;
        private TrainingCatalog.Controls.BaseButton btnOk;

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
            this.btnOk = new TrainingCatalog.Controls.BaseButton();
            this.txtBeginTime = new TrainingCatalog.Controls.BaseMaskedTextBox();
            this.txtEndTime = new TrainingCatalog.Controls.BaseMaskedTextBox();
            this.lblStart = new TrainingCatalog.Controls.BaseLabel();
            this.lblEnd = new TrainingCatalog.Controls.BaseLabel();
            this.lstExersizes = new System.Windows.Forms.ListBox();
            this.btnAdd = new TrainingCatalog.Controls.BaseButton();
            this.baseGroupBox1 = new TrainingCatalog.Controls.BaseGroupBox();
            this.cardioExersizesControl = new TrainingCatalog.Controls.CardioExersizesControl();
            this.btnFromTemplate = new TrainingCatalog.Controls.BaseButton();
            this.btnFromOtherDay = new TrainingCatalog.Controls.BaseButton();
            this.baseGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.Location = new System.Drawing.Point(15, 313);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(50, 50);
            this.btnOk.TabIndex = 0;
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtBeginTime
            // 
            this.txtBeginTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBeginTime.Location = new System.Drawing.Point(123, 8);
            this.txtBeginTime.Mask = "00:00";
            this.txtBeginTime.Name = "txtBeginTime";
            this.txtBeginTime.Size = new System.Drawing.Size(49, 20);
            this.txtBeginTime.TabIndex = 1;
            this.txtBeginTime.ValidatingType = typeof(System.DateTime);
            // 
            // txtEndTime
            // 
            this.txtEndTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndTime.Location = new System.Drawing.Point(123, 33);
            this.txtEndTime.Mask = "00:00";
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(49, 20);
            this.txtEndTime.TabIndex = 2;
            this.txtEndTime.ValidatingType = typeof(System.DateTime);
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(33, 10);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(78, 13);
            this.lblStart.TabIndex = 5;
            this.lblStart.Text = "Время начала";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(6, 35);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(105, 13);
            this.lblEnd.TabIndex = 6;
            this.lblEnd.Text = "Врмея завершения";
            // 
            // lstExersizes
            // 
            this.lstExersizes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstExersizes.FormattingEnabled = true;
            this.lstExersizes.Location = new System.Drawing.Point(6, 19);
            this.lstExersizes.Name = "lstExersizes";
            this.lstExersizes.Size = new System.Drawing.Size(138, 186);
            this.lstExersizes.TabIndex = 9;
            this.lstExersizes.SelectedIndexChanged += new System.EventHandler(this.lstExersizes_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(115, 313);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 50);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // baseGroupBox1
            // 
            this.baseGroupBox1.Controls.Add(this.lstExersizes);
            this.baseGroupBox1.Location = new System.Drawing.Point(15, 59);
            this.baseGroupBox1.Name = "baseGroupBox1";
            this.baseGroupBox1.Size = new System.Drawing.Size(150, 215);
            this.baseGroupBox1.TabIndex = 12;
            this.baseGroupBox1.TabStop = false;
            this.baseGroupBox1.Text = "Вид Кардио";
            // 
            // cardioExersizesControl
            // 
            this.cardioExersizesControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cardioExersizesControl.DefaultCardioType = null;
            this.cardioExersizesControl.Location = new System.Drawing.Point(178, 8);
            this.cardioExersizesControl.Name = "cardioExersizesControl";
            this.cardioExersizesControl.Size = new System.Drawing.Size(563, 355);
            this.cardioExersizesControl.TabIndex = 13;
            // 
            // btnFromTemplate
            // 
            this.btnFromTemplate.Location = new System.Drawing.Point(15, 281);
            this.btnFromTemplate.Name = "btnFromTemplate";
            this.btnFromTemplate.Size = new System.Drawing.Size(50, 23);
            this.btnFromTemplate.TabIndex = 14;
            this.btnFromTemplate.Text = "Добавить из шаблона";
            this.btnFromTemplate.UseVisualStyleBackColor = true;
            this.btnFromTemplate.Click += new System.EventHandler(this.btnFromTemplate_Click);
            // 
            // btnFromOtherDay
            // 
            this.btnFromOtherDay.Location = new System.Drawing.Point(115, 280);
            this.btnFromOtherDay.Name = "btnFromOtherDay";
            this.btnFromOtherDay.Size = new System.Drawing.Size(50, 23);
            this.btnFromOtherDay.TabIndex = 15;
            this.btnFromOtherDay.Text = "День";
            this.btnFromOtherDay.UseVisualStyleBackColor = true;
            this.btnFromOtherDay.Click += new System.EventHandler(this.btnFromOtherDay_Click);
            // 
            // CardioSession
            // 
            this.ClientSize = new System.Drawing.Size(753, 375);
            this.Controls.Add(this.btnFromOtherDay);
            this.Controls.Add(this.btnFromTemplate);
            this.Controls.Add(this.cardioExersizesControl);
            this.Controls.Add(this.baseGroupBox1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.txtEndTime);
            this.Controls.Add(this.txtBeginTime);
            this.Controls.Add(this.btnOk);
            this.IsShown = true;
            this.MinimumSize = new System.Drawing.Size(648, 413);
            this.Name = "CardioSession";
            this.Text = "CardioIntervals";
            this.Load += new System.EventHandler(this.CardioSession_Load);
            this.baseGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.CardioExersizesControl cardioExersizesControl;
        private Controls.BaseButton btnFromTemplate;
        private Controls.BaseButton btnFromOtherDay;






    }
}