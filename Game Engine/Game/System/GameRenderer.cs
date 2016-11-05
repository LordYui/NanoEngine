using System;
using Game_Engine.Services;
using Game_Engine.Services.Render;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Game.GameSystems
{
    [Injector.Injectable(typeof(RenderService))]
    class GameRenderer : RendererBase
    {
        public override T[] PollRender<T>()
        {
            throw new NotImplementedException();
        }
    }
}
