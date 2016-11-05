using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Scripts
{
    class ProviderAttribute : Attribute
    {

        public readonly Type[] InjectTypes;
        public ProviderAttribute(params Type[] types)
        {
            InjectTypes = types;
        }
    }
}
