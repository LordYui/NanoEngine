using Game_Engine.Services.RenderSystem.Configs;
using Game_Engine.Services.ServiceMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Services.RenderSystem
{
    public class RenderSystem : Service
    {
        Renderer _Renderer;
        public RenderSystem()
        {

        }

        [Message(typeof(RendererConfigs))]
        public void SetConfig(RendererConfigs conf)
        {
            _Renderer = new Renderer(conf);
        }

        public void Start()
        {
            if(_Renderer == null)
            {
                Logman.Logger.Log(Logman.LogLevel.Errors, "Renderer configs must be set before trying to start the service.");
                return;
            }
        }
    }
}
