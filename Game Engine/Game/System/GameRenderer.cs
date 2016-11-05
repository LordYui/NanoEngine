using System;
using Game_Engine.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Engine.Engine.Services.Render;
using Game_Engine.Engine.Injector;

namespace Game_Engine.Game.GameSystems
{
    [Injectable(typeof(RenderService))]
    class GameRenderer : RendererBase
    {
        public override T[] PollRender<T>()
        {
            throw new NotImplementedException();
        }
    }
}
