using Game_Engine.Services.RenderSystem.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Services.RenderSystem
{
    class Renderer
    {
        RendererConfigs _Conf;
        public Renderer(RendererConfigs c)
        {
            _Conf = c;
        }
    }
}
