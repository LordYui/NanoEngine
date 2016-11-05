using Game_Engine.Engine.Injector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Engine.Services.Render
{
    [Injectable(typeof(RenderService))]
    abstract class RendererBase
    {
        RenderService _RenderService;
        public RendererBase()
        {
            this.InjectSrvc();
        }

        virtual public void Init() { }

        abstract public T[] PollRender<T>();
    }
}
