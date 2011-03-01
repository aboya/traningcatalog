using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TrainingCatalog.Controls
{
    /*
    public class HighLightCalendar : MonthCalendar
    {
        private List<DateTime> _warningDates = new List<DateTime>();

        public List<DateTime> WarningDates
        {
            get
            {
                return _warningDates;
            }
            set
            {
                _warningDates = value;
            }
        }
        protected static int WM_PAINT = 0x000F;

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT)
            {
                Graphics graphics = Graphics.FromHwnd(this.Handle);
                PaintEventArgs pe = new PaintEventArgs(graphics, new Rectangle(0, 0, this.Width, this.Height));
                OnPaint(pe);
            }
        } 
        
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
           // graphics.Clear(Color.Red); 
            base.OnPaint(e);
            int dayBoxWidth = 0;
            int dayBoxHeight = 0;
            int firstWeekPosition = 0;
            int lastWeekPosition = Height;
            if (WarningDates.Count > 0)
            {
                SelectionRange calendarRange = GetDisplayRange(false);
                
                // Create a list of those dates that actually should be marked as warnings.
                List<DateTime> visibleWarningDates = new List<DateTime>();
                foreach (DateTime date in WarningDates)
                {
                    if (date >= calendarRange.Start && date <= calendarRange.End)
                    {
                        visibleWarningDates.Add(date);
                    }
                }

                if (visibleWarningDates.Count > 0 && calendarRange.End.Subtract(calendarRange.Start).TotalDays < 362)
                {
                     
                    while ((HitTest(25, firstWeekPosition).HitArea != HitArea.PrevMonthDate && HitTest(25, firstWeekPosition).HitArea != HitArea.Date) && firstWeekPosition < Height)
                    {
                        firstWeekPosition++;
                    }

                    while ((HitTest(25, lastWeekPosition).HitArea != HitArea.NextMonthDate && HitTest(25, lastWeekPosition).HitArea != HitArea.Date) && lastWeekPosition >= 0)
                    {
                        lastWeekPosition--;
                    }

                    if (firstWeekPosition > 0 && lastWeekPosition > 0)
                    {
                        dayBoxWidth = Width / (ShowWeekNumbers ? 8 : 7);
                        dayBoxHeight = (int)(((float)(lastWeekPosition - firstWeekPosition)) / 6.0f);

                        using (Brush warningBrush = new SolidBrush(Color.FromArgb(127, Color.FromArgb(165, 191, 225))))
                        {
                            foreach (DateTime visDate in visibleWarningDates)
                            {
                                int row = 0;
                                int col = 0;

                                TimeSpan span = visDate.Subtract(calendarRange.Start);
                                row = span.Days / 7;
                                col = span.Days % 7;
                                Rectangle fillRect = new Rectangle((col + (ShowWeekNumbers ? 1 : 0)) * dayBoxWidth + 2, firstWeekPosition + row * dayBoxHeight + 1, dayBoxWidth - 2, dayBoxHeight);
                                graphics.FillRectangle(warningBrush, fillRect);

                                // Check if the date is in the bolded dates array
                                bool makeDateBolded = false;
                                foreach (DateTime boldDate in BoldedDates)
                                {
                                    if (boldDate == visDate)
                                    {
                                        makeDateBolded = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
}
     * */
    public class MonCal : MonthCalendar
    {
        protected static int WM_PAINT = 0x000F;
        private Rectangle dayBox;
        private int dayTop = 0;
        private SelectionRange range;

        private List<HighlightedDates> highlightedDates = new List<HighlightedDates>();

        public MonCal()
        {
            this.ShowTodayCircle = false;
           // this.highlightedDates = HighlightedDates;
            this.highlightedDates.Add(new HighlightedDates(DateTime.Now.AddDays(-2)));
            range = GetDisplayRange(false);
            SetDayBoxSize();
            SetPosition(this.highlightedDates);
        }


        // This method figures out the size of the entire date area portion of the control 
        //   and then divides it up o create a Rectagle for painting to individual dates
        private void SetDayBoxSize()
        {
            int bottom = this.Height;

            while (HitTest(25, dayTop).HitArea != HitArea.Date &&
                HitTest(25, dayTop).HitArea != HitArea.PrevMonthDate) dayTop++;

            while (HitTest(25, bottom).HitArea != HitArea.Date &&
                HitTest(25, bottom).HitArea != HitArea.NextMonthDate) bottom--;

            dayBox = new Rectangle();
            dayBox.Size = new Size(this.Width / 7, (bottom - dayTop) / 6);
        }

        // This method determines where in the 7 x 6 array of dates on the control our highlighted dates reside.
        private void SetPosition(List<HighlightedDates> hlDates)
        {
            int row = 0, col = 0;

            hlDates.ForEach(delegate(HighlightedDates date)
            {
                if (date.Date >= range.Start && date.Date <= range.End)
                {
                    TimeSpan span = date.Date.Subtract(range.Start);
                    row = span.Days / 7;
                    col = span.Days % 7;
                    date.Position = new Point(row, col);
                }
            });
        }

        // This overrides the message pump and traps the WM_PAINT call
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT)
            {
                Graphics g = Graphics.FromHwnd(this.Handle);
                PaintEventArgs pea =
                    new PaintEventArgs(g, new Rectangle(0, 0, this.Width, this.Height));
                OnPaint(pea);
            }
        }

        // Here is where we use our information to selectively draw what we want
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Rectangle backgroundRect;

            highlightedDates.ForEach(delegate(HighlightedDates date)
            {
                backgroundRect = new Rectangle(
                   date.Position.Y * dayBox.Width + 1,
                   date.Position.X * dayBox.Height + dayTop,
                   dayBox.Width, dayBox.Height);

                if (date.BackgroundColor != Color.Empty)
                {
                    using (Brush brush = new SolidBrush(date.BackgroundColor))
                    {
                        g.FillRectangle(brush, backgroundRect);
                    }
                }
                if (date.Bold || date.DateColor != Color.Empty)
                {
                    using (Font textFont =
                        new Font(Font, (date.Bold ? FontStyle.Bold : FontStyle.Regular)))
                    {
                        TextRenderer.DrawText(g, date.Date.Day.ToString(), textFont,
                            backgroundRect, date.DateColor,
                            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    }
                }

                if (date.BoxColor != Color.Empty)
                {
                    using (Pen pen = new Pen(date.BoxColor))
                    {
                        Rectangle boxRect = new Rectangle(
                            date.Position.Y * dayBox.Width + 1,
                            date.Position.X * dayBox.Height + dayTop,
                            dayBox.Width, dayBox.Height);
                        g.DrawRectangle(pen, boxRect);
                    }
                }
            });
        }
    }


}
