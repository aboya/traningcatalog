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
        public float Waistline_h;
        public float Waistline_l;
        public float Biceps_h;
        public float Biceps_l;
        public float Chest_h;
        public float Chest_l;
        public float Hip_h;
        public float Hip_l;
        public float Midarm_l;
        public float Midarm_h;
        public float BodyFat;
        public float BodyWeight;
        public bool IsEmpty
        {
            get
            {
                return this.Biceps_h == 0 && this.Biceps_l == 0 && this.BodyFat == 0 && this.Chest_h == 0 && this.Chest_l == 0
                    && this.Hip_h == 0 && this.Hip_l == 0 && this.Midarm_h == 0 && this.Midarm_l == 0 && this.Waistline_h == 0
                    && this.Waistline_l == 0;
                 
            }
        }
    }
}
