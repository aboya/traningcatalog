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
        public int StartTime { get; set; }
        public int EndTime { get; set; }
    }
}
