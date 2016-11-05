using Game_Engine.Engine.Services.RenderService.Configs;
using Game_Engine.Engine.Services.RenderSystem;
using Game_Engine.Services.ServiceManager.ServiceMessage;
using System;
using System.Collections.Generic;

namespace Game_Engine.Services.RenderService
{
    internal class RenderService : Service
    {
        Window _Window;
        List<object> renderBuf = new List<object>();

        RenderConf _Conf;

        internal override void Init()
        {
            base.Init();
            Message.On("append-buffer", new MessageAct(appendBuffer));
            Message.On("set-config", new MessageAct(setConfig));
        }

        void appendBuffer(params object[] o)
        {
            foreach(object nO in o)
            {
                if(isCorrectRenderContract(nO))
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