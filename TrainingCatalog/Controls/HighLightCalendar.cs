using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace TrainingCatalog.Controls
{
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
            base.OnPaint(e);
            Graphics graphics = e.Graphics;

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

                if (visibleWarningDates.Count > 0)
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

                        using (Brush warningBrush = new SolidBrush(Color.FromArgb(255, Color.FromArgb(255, 240, 240))))
                        {
                            foreach (DateTime visDate in visibleWarningDates)
                            {
                                int row = 0;
                                int col = 0;

                                TimeSpan span = visDate.Subtract(calendarRange.Start);
                                row = span.Days / 7;
                                col = span.Days % 7;

                                Rectangle fillRect = new Rectangle((col + (ShowWeekNumbers ? 1 : 0)) * dayBoxWidth + 2, firstWeekPosition + row * dayBoxHeight + 1, dayBoxWidth - 2, dayBoxHeight - 2);
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

                                using (Font textFont = new Font(Font, (makeDateBolded ? FontStyle.Bold : FontStyle.Regular)))
                                {
                                    TextRenderer.DrawText(graphics, visDate.Day.ToString(), textFont, fillRect, Color.FromArgb(255, 128, 0, 0), TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
