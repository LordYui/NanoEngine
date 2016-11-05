using System;
using Game_Engine.Services;
using Game_Engine.Services.RenderService;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Game.GameSystems
{
    [Injector.Injectable(typeof(RenderService))]
    class GameRenderer : Service
    {
        internal override void UpdateService(double delta)
        {
            throw new NotImplementedException();
        }
    }
}
