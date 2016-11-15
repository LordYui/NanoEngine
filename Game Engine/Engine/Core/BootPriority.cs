using Game_Engine.Engine.Services;
using Game_Engine.Engine.Services.AssetsProvider;
using Game_Engine.Engine.Services.ConfigsProvider;
using Game_Engine.Engine.Services.Input;
using Game_Engine.Engine.Services.Render;
using Game_Engine.Engine.Services.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Engine.Core
{
    static class BootPriority
    {
        /// <summary>
        /// Lower priority is better
        /// </summary>
        public static Dictionary<Type, int> serviceInitPriority = new Dictionary<Type, int>()
        {
            { typeof(ConfigService), 6 },
            { typeof(AssetService), 5 },
            { typeof(RenderService), 4 },
            { typeof(InputSystem), 3 },
            { typeof(ScriptService), 2 },
            { typeof(NodeSystem), 1 }
        };
    }
}
