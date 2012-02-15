using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingCatalog.BusinessLogic.Types
{
    public class MeasurementType
    {
        public int TrainingId;
        public DateTime date;
        public float Waistline_h { get; set; }
        public float Waistline_l { get; set; }
        public float Biceps_h { get; set; }
        public float Biceps_l { get; set; }
        public float Chest_h { get; set; }
        public float Chest_l { get; set; }
        public float Hip_h { get; set; }
        public float Hip_l { get; set; }
        public float Midarm_l { get; set; }
        public float Midarm_h { get; set; }
        public float BodyFat { get; set; }
        public float BodyWeight { get; set; }
        public bool IsEmpty()
        {
           
                return this.Biceps_h == 0 && this.Biceps_l == 0 && this.BodyFat == 0 && this.Chest_h == 0 && this.Chest_l == 0
                    && this.Hip_h == 0 && this.Hip_l == 0 && this.Midarm_h == 0 && this.Midarm_l == 0 && this.Waistline_h == 0
                    && this.Waistline_l == 0;
                 
            
        }
    }
}
