using Game_Engine.Injector;
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
        RenderService _RenderService;
        public RendererBase()
        {
            this.Inject();
        }

        virtual public void Init() { }

        abstract public T[] PollRender<T>();
    }
}
