using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TrainingCatalog.Controls
{
    public class HighlightedDates
    {
        public DateTime Date;
        public Point Position = new Point(0, 0);
        public Color DateColor;
        public Color BoxColor;
        public Color BackgroundColor;
        public Boolean Bold;

        // This constructor is used if you only want to make dates bold. All colors are set to "Empty"(null color)
        public HighlightedDates(DateTime date)
        {
            this.Date = date;
            this.DateColor = this.BoxColor = this.BackgroundColor = Color.Empty;
            this.Bold = true;
        }

 

        //// This constructor is used if you want colored and/or bolded dates
        public HighlightedDates(DateTime date, Color dateColor, Boolean bold)
        {
            this.Date = date;
            this.DateColor = dateColor;
            this.BoxColor = this.BackgroundColor = Color.Empty;
            this.Bold = bold;
        }

        //// This constructor is used when you want to control everything
        public HighlightedDates(DateTime date, Color dateColor, Color boxColor,Color backgroundColor, Boolean bold)
        {
            this.Date = date;
            this.DateColor = dateColor;
            this.BoxColor = boxColor;
            this.BackgroundColor = backgroundColor;
            this.Bold = bold;
        }
    }
}
