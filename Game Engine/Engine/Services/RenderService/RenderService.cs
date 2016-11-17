using Game_Engine.Engine.Services.Render;
using Game_Engine.Engine.Services.Render.Configs;
using Game_Engine.Engine.Injector;
using Game_Engine.Services.ServiceManager.ServiceMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using Game_Engine.Engine.Objects.Internals;
using Game_Engine.Engine.Services.Render.Configs;
using SFML.Graphics;

namespace Game_Engine.Engine.Services.Render
{
    internal class RenderService : Service
    {
        public WindowObject _Window { get; private set; }
        List<object> renderBuf = new List<object>();

        RenderConf _Conf;
        RendererModule _Module;

        public override void Init()
        {
            //base.Init();
            _Window = new WindowObject();
            Message.On("append-buffer", new MessageAct(appendBuffer));
            Message.On("set-config", new MessageAct(setConfig));
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

        internal override void Update(double delta)
        {
            _Window._Win.Clear();
           foreach (RenderBuf rObj in renderBuf)
            {
                foreach (SFMLRenderContract ctrct in rObj.renderObjects)
                {
                    _Window._Win.Draw(ctrct.Draw, new RenderStates(((Transformable)ctrct.Draw).Transform));
                }
            }
            renderBuf.Clear();

            _Window.Update(delta);
        }

        internal bool isCorrectRenderContract(object o)
        {
            //Type t = _Conf.Contract;
            //if (o.GetType() == t)
            //    return true;
            //return false;
            return true;
        }
    }
}