using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.UI;

namespace TrainingCatalog.Forms
{
    public class CardioSession : BaseForm
    {
        MyAppointmentFormController controller;
        SchedulerControl control;
        Appointment apt;
        bool openRecurrenceForm = false;
        private TrainingCatalog.Controls.BaseMaskedTextBox maskedTextBox1;
        private Controls.BaseMaskedTextBox baseMaskedTextBox1;
        private TrainingCatalog.Controls.BaseGroupBox gbType;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private Controls.BaseMaskedTextBox baseMaskedTextBox2;
        private Controls.BaseLabel lblStart;
        private Controls.BaseLabel lblEnd;
        private Controls.BaseLabel lblDuration;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox listBox1;
        private TrainingCatalog.Controls.BaseButton btnAdd;
        private Controls.BaseGroupBox baseGroupBox1;
        private TrainingCatalog.Controls.BaseButton btnOk;
        private void InitializeComponent()
        {
            this.btnOk = new TrainingCatalog.Controls.BaseButton();
            this.maskedTextBox1 = new TrainingCatalog.Controls.BaseMaskedTextBox();
            this.baseMaskedTextBox1 = new TrainingCatalog.Controls.BaseMaskedTextBox();
            this.gbType = new TrainingCatalog.Controls.BaseGroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.baseMaskedTextBox2 = new TrainingCatalog.Controls.BaseMaskedTextBox();
            this.lblStart = new TrainingCatalog.Controls.BaseLabel();
            this.lblEnd = new TrainingCatalog.Controls.BaseLabel();
            this.lblDuration = new TrainingCatalog.Controls.BaseLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnAdd = new TrainingCatalog.Controls.BaseButton();
            this.baseGroupBox1 = new TrainingCatalog.Controls.BaseGroupBox();
            this.gbType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.baseGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(515, 315);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(50, 50);
            this.btnOk.TabIndex = 0;
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBox1.Location = new System.Drawing.Point(123, 8);
            this.maskedTextBox1.Mask = "00:00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(49, 20);
            this.maskedTextBox1.TabIndex = 1;
            this.maskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // baseMaskedTextBox1
            // 
            this.baseMaskedTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.baseMaskedTextBox1.Location = new System.Drawing.Point(123, 33);
            this.baseMaskedTextBox1.Mask = "00:00";
            this.baseMaskedTextBox1.Name = "baseMaskedTextBox1";
            this.baseMaskedTextBox1.Size = new System.Drawing.Size(49, 20);
            this.baseMaskedTextBox1.TabIndex = 2;
            this.baseMaskedTextBox1.ValidatingType = typeof(System.DateTime);
            // 
            // gbType
            // 
            this.gbType.Controls.Add(this.radioButton2);
            this.gbType.Controls.Add(this.radioButton1);
            this.gbType.Location = new System.Drawing.Point(15, 274);
            this.gbType.Name = "gbType";
            this.gbType.Size = new System.Drawing.Size(127, 75);
            this.gbType.TabIndex = 3;
            this.gbType.TabStop = false;
            this.gbType.Text = "Тип кардио";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(7, 41);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(72, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Обычный";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(7, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(100, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Интервальный";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // baseMaskedTextBox2
            // 
            this.baseMaskedTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.baseMaskedTextBox2.Location = new System.Drawing.Point(123, 60);
            this.baseMaskedTextBox2.Mask = "0000";
            this.baseMaskedTextBox2.Name = "baseMaskedTextBox2";
            this.baseMaskedTextBox2.Size = new System.Drawing.Size(49, 20);
            this.baseMaskedTextBox2.TabIndex = 4;
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
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(6, 62);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(111, 13);
            this.lblDuration.TabIndex = 7;
            this.lblDuration.Text = "Продолжительность";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(178, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(387, 299);
            this.dataGridView1.TabIndex = 8;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(138, 147);
            this.listBox1.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(178, 315);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 50);
            this.btnAdd.TabIndex = 11;
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // baseGroupBox1
            // 
            this.baseGroupBox1.Controls.Add(this.listBox1);
            this.baseGroupBox1.Location = new System.Drawing.Point(15, 86);
            this.baseGroupBox1.Name = "baseGroupBox1";
            this.baseGroupBox1.Size = new System.Drawing.Size(150, 177);
            this.baseGroupBox1.TabIndex = 12;
            this.baseGroupBox1.TabStop = false;
            this.baseGroupBox1.Text = "Вид Кардио";
            // 
            // CardioSession
            // 
            this.ClientSize = new System.Drawing.Size(577, 375);
            this.Controls.Add(this.baseGroupBox1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.baseMaskedTextBox2);
            this.Controls.Add(this.gbType);
            this.Controls.Add(this.baseMaskedTextBox1);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.btnOk);
            this.MinimumSize = new System.Drawing.Size(593, 413);
            this.Name = "CardioSession";
            this.gbType.ResumeLayout(false);
            this.gbType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.baseGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public CardioSession(SchedulerControl control, Appointment apt, bool openRecurrenceForm)
        {
            this.openRecurrenceForm = openRecurrenceForm;
            this.controller = new MyAppointmentFormController(control, apt);
            this.apt = apt;
            this.control = control;
            InitializeComponent();
            this.controller.CustomName = "asdasd";
            controller.ApplyChanges();
            this.btnAdd.Image = TrainingCatalog.AppResources.AppResources.Plus_green_32x32;
            this.btnOk.Image = TrainingCatalog.AppResources.AppResources.save_48x48;


        }

        public class MyAppointmentFormController : AppointmentFormController
        {

            public string CustomName
            {
                get
                {
                    return (string)EditedAppointmentCopy.CustomFields["CustomName"];
                }
                set
                {
                    EditedAppointmentCopy.CustomFields["CustomName"] = value;
                }
            }
            public string CustomStatus
            {
                get
                {
                    return (string)EditedAppointmentCopy.CustomFields["CustomStatus"];
                }
                set
                {
                    EditedAppointmentCopy.CustomFields["CustomStatus"] = value;
                }
            }

            string SourceCustomName
            {
                get
                {
                    return (string)SourceAppointment.CustomFields["CustomName"];
                }
                set
                {
                    SourceAppointment.CustomFields["CustomName"] = value;
                }
            }

            string SourceCustomStatus
            {
                get
                {
                    return (string)SourceAppointment.CustomFields["CustomStatus"];
                }
                set
                {
                    SourceAppointment.CustomFields["CustomStatus"] = value;
                }
            }

            public MyAppointmentFormController(SchedulerControl control, Appointment apt) :
                base(control, apt)
            {
            }

            public override bool IsAppointmentChanged()
            {
                if (base.IsAppointmentChanged())
                    return true;
                return SourceCustomName != CustomName ||
                    SourceCustomStatus != CustomStatus;
            }

            protected override void ApplyCustomFieldsValues()
            {
                SourceCustomName = CustomName;
                SourceCustomStatus = CustomStatus;
            }
        }
    }
}
