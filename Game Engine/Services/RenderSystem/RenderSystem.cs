using Game_Engine.Objects;
using Game_Engine.Services.RenderSystem.Configs;
using Game_Engine.Services.ServiceManager.ServiceMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Services.RenderSystem
{
    internal class RenderService : Service
    {
        Renderer _Renderer;
        List<Atom> atomBuffer = new List<Atom>();

        public override void Init()
        {
            base.Init();
            Message.On("append-buffer", new MessageAct(appendBuffer));
        }

        void appendBuffer(params object[] o)
        {
            Atom[] aL = (Atom[])o;
            atomBuffer.AddRange(aL);
        }

        public void SetConfig(RendererConfigs conf)
        {
            _Renderer = new Renderer(conf);
        }

        public void Start()
        {
            if (_Renderer == null)
            {
                Logman.Logger.Log(Logman.LogLevel.Errors, "Renderer configs must be set before trying to start the service.");
                return;
            }
        }

        internal override void UpdateService(double delta)
        {
            throw new NotImplementedException();
        }
    }
}
