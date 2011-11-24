using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TrainingCatalog.Controls
{
    public class BaseMonthCalendar : System.Windows.Forms.MonthCalendar
    {
        Point p;
        DateTime lastTime = DateTime.MinValue;
        const int eps = 1;
        TimeSpan timeEps = new TimeSpan(0,0,0,0,100); // 100 milisec
        public event EventHandler DoubleMouseClick;
        public BaseMonthCalendar()
        {
            this.MaxSelectionCount = 1;
        }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (Math.Abs(p.X - e.X) < eps && Math.Abs(p.Y - e.Y) < eps)
            {
                if (DateTime.Now.Subtract(lastTime) < timeEps)
                {
                    if (DoubleMouseClick != null)
                    {
                        this.DoubleMouseClick(this, e);
                    }
                }
            }

            lastTime = DateTime.Now;
            p.X = e.X;
            p.Y = e.Y;
            base.OnMouseDown(e);
        }
    }
}
