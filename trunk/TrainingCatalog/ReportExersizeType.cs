using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingCatalog
{
    public class ReportExersizeType
    {
        public int Id;
        public string Name;
        public int count;
        public int weight;
        public ReportExersizeType(int _id, string _Name, int _count, int _weight)
        {
            Id = _id;
            Name = _Name;
            count = _count;
            weight = _weight;
        }
    }
}
