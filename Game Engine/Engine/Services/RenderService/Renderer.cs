using Game_Engine.Services.RenderService.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Services.RenderService.Internals
{
    class Renderer
    {
        RendererConfigs _Conf;
        internal Renderer(RendererConfigs c)
        {
            _Conf = c;
        }

        internal bool isCorrectRenderContract(object o)
        {
            Type t = _Conf.renderContract;
            if(o.GetType() == t)
                return true;
            return false;
        }

        internal void Update(double delta, object[] renderBuf)
        {

        }
    }
}
