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
  

        private System.Windows.Forms.Button btnOk;
        private void InitializeComponent()
        {
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(197, 218);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 32);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // CardioSession
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnOk);
            this.Name = "CardioSession";
            this.ResumeLayout(false);

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
