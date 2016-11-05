using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Services.Render
{
    [Injector.Injectable(typeof(RenderService))]
    abstract class RendererBase
    {
        public RendererBase()
        {

        }
    }
}
