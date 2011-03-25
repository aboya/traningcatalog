using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingCatalog.Controls
{
    public class BaseMonthCalendar : System.Windows.Forms.MonthCalendar
    {
        public BaseMonthCalendar()
        {
            this.MaxSelectionCount = 1;
        }
    }
}
