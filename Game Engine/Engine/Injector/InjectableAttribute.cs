using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Engine.Injector
{
    class InjectableAttribute : Attribute
    {
        public readonly Type[] InjectTypes;
        public InjectableAttribute(params Type[] types)
        {
            InjectTypes = types;
        }
    }
}
