using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace accdbTosdf
{
    public class ExersizeInstance : IComparable
    {
        public int Weight;
        public int Count;
        public string name;
        public DateTime Day;
        public static bool operator ==(ExersizeInstance a, ExersizeInstance b)
        {
            if (a.Weight == b.Weight &&
                a.Count == b.Count &&
                a.name == b.name &&
                a.Day == b.Day) return true;
            return false;
        }
        public static bool operator !=(ExersizeInstance a, ExersizeInstance b)
        {
            if (a.Weight == b.Weight &&
                a.Count == b.Count &&
                a.name == b.name &&
                a.Day == b.Day) return false;
            return true;
        }
        public static bool operator <(ExersizeInstance a, ExersizeInstance b)
        {
            if (a.Day < b.Day) return true;
            else if (a.Day == b.Day && a.name.CompareTo(b.name) < 0) return true;
            else if (a.Day == b.Day && a.name.CompareTo(b.name) == 0 && a.Weight < b.Weight) return true;
            else if (a.Day == b.Day && a.name.CompareTo(b.name) == 0 && a.Weight == b.Weight && a.Count < b.Count) return true;
            return false;
        }
        public static bool operator >(ExersizeInstance a, ExersizeInstance b)
        {
            if (a.Day > b.Day) return true;
            else if (a.Day == b.Day && a.name.CompareTo(b.name) > 0) return true;
            else if (a.Day == b.Day && a.name.CompareTo(b.name) == 0 && a.Weight > b.Weight) return true;
            else if (a.Day == b.Day && a.name.CompareTo(b.name) == 0 && a.Weight == b.Weight && a.Count > b.Count) return true;
            return false;
        }

        public int CompareTo(object o)
        {
         
            if (this > (ExersizeInstance)o) return 1;
            return 0;
        }
    }
}
