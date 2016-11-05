using Game_Engine.Engine.Services.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Engine.Core
{
    static class BootPriority
    {
        public static Dictionary<Type, int> serviceInitPriority = new Dictionary<Type, int>()
        {
            { typeof(RenderService), 10 }
        };
    }
}
