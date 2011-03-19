using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraScheduler;

namespace TrainingCatalog.Forms
{
    public partial class CardioTraining : BaseForm
    {
        public CardioTraining()
        {
            InitializeComponent();
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, DevExpress.XtraScheduler.AppointmentFormEventArgs e)
        {
            Appointment apt = e.Appointment;

            bool openRecurrenceForm = apt.IsRecurring && schedulerStorage1.Appointments.IsNewAppointment(apt);

            using (CardioSession cs = new CardioSession((SchedulerControl)sender, apt, openRecurrenceForm))
            {
                e.DialogResult = cs.ShowDialog(this);
                schedulerControl1.Refresh();
                e.Handled = true;
            }
        }
    }
}
