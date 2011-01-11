using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace accdbTosdf
{
    public class ExersizeInstance
    {
        public int Weight;
        public int Count;
        public string name;
        public static bool operator ==(ExersizeInstance a, ExersizeInstance b)
        {
            if (a.Weight == b.Weight &&
                a.Count == b.Count &&
                a.name == b.name) return true;
            return false;
        }
        public static bool operator !=(ExersizeInstance a, ExersizeInstance b)
        {
            if (a.Weight == b.Weight &&
                a.Count == b.Count &&
                a.name == b.name) return false;
            return true;
        }
        public static int operator <(ExersizeInstance a, ExersizeInstance b)
        {
            return a.name.CompareTo(b.name);
        }
        public static int operator >(ExersizeInstance a, ExersizeInstance b)
        {
            return -a.name.CompareTo(b.name);
        }
    }
}
