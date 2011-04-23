using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingCatalog.BusinessLogic.Types
{
    public class CardioSessionType
    {
        public int Id { get; set; }
        public int TrainingId { get; set; }
        public DateTime Date { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public string Name
        {
            get
            {
                return string.Format("{0} {1}:{2}", Date.ToString("yyyy.MM.dd"), StartTime / 60, StartTime % 60);
            }
        }
    }
}
