using Game_Engine.Engine.Services.Render;
using Game_Engine.Engine.Services.Render.Configs;
using Game_Engine.Engine.Services.RenderService;
using Game_Engine.Engine.Injector;
using Game_Engine.Services.ServiceManager.ServiceMessage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game_Engine.Engine.Services.Render
{
    internal class RenderService : Service
    {
        Window _Window;
        List<object> renderBuf = new List<object>();

        List<RendererBase> _Renderers;

        RenderConf _Conf;
        RendererModule _Module;

        internal override void Init()
        {
            base.Init();
            _Renderers = new List<Render.RendererBase>();
            Message.On("append-buffer", new MessageAct(appendBuffer));
            Message.On("set-config", new MessageAct(setConfig));
            InitRenderers();
        }

        void InitRenderers()
        {
            var rendererSubClasses =
                from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                where type.IsSubclassOf(typeof(RendererBase))
                select type;

            foreach (Type t in rendererSubClasses)
            {
                RendererBase r = (RendererBase)Activator.CreateInstance(t);
                r.Init();
                _Renderers.Add(r);
            }
        }

        void appendBuffer(params object[] o)
        {
            foreach (object nO in o)
            {
                if (isCorrectRenderContract(nO))
                {
                    renderBuf.Add(nO);
                }
            }
        }

        void setConfig(object[] o)
        {
            SetConfig(new RenderConf((Type)o[0]));
        }

        public void SetConfig(RenderConf conf)
        {
            _Conf = conf;
        }

        public void Start()
        {
            if (_Conf == null)
            {
                Logman.Logger.Log(Logman.LogLevel.Errors, "Renderer configs must be set before trying to start the service.");
                return;
            }
        }

        internal override void UpdateService(double delta)
        {
            //_Renderer.Update(delta, renderBuf.ToArray());
            renderBuf.Clear();
        }

        internal bool isCorrectRenderContract(object o)
        {
            Type t = _Conf.Contract;
            if (o.GetType() == t)
                return true;
            return false;
        }
    }
}