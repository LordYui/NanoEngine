using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Objects.Internals
{
    class BaseObject
    {
        static int _ID = 0;
        public int ID;

        public BaseObject()
        {
            ID = _ID++;
        }
    }
}
