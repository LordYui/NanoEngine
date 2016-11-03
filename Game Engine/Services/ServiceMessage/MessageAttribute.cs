using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Services.ServiceMessage
{
    class MessageAttribute : Attribute
    {
        public Type[] ArgsTypes;
        public MessageAttribute(params Type[] argsT)
        {
            ArgsTypes = argsT;
        }
    }
}
