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

        public bool isCorrectRenderContract(object o)
        {
            Type t = _Conf.renderContract;
            if(o.GetType() == t)
                return true;
            return false;
        }
    }
}
