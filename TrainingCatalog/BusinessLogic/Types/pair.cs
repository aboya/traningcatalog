using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeHighway.BusinessLogic.Common.Types
{
    public class pair<T, U>
    {
        public pair()
        {
        }
        public pair(T first, U second)
        {
            this.First = first;
            this.Second = second;
        }
        public T First { get; set; }
        public U Second { get; set; }
    };

}
