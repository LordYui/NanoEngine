using Game_Engine.Engine.Injector;
using Game_Engine.Engine.Objects.Internals;
using Game_Engine.Engine.Services.Render;
using Game_Engine.Services.ServiceManager.ServiceMessage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game_Engine.Engine.Services.GameNodes
{
    [Injectable(typeof(Render.RenderService))]
    abstract class GameNode : BaseObject
    {
        public bool Active { get; private set; }
        internal NodeSystem _System;
        List<NodeModule> _Modules;

        RenderService _RenderService;

        public GameNode(bool defaultNode)
        {
            Active = defaultNode;

            _Modules = new List<NodeModule>();
            initModules();

            this.InjectSrvc();

            Message.On("set-active", new MessageAct(SetActive));
            Message.On("register-module", new MessageAct(RegisterModule));
        }

        private void RegisterModule(object o)
        {

        }

        private void SetActive(object o)
        {
            Active = (bool)o;
        }
        private void initModules()
        {
            var serviceSubclasses =
                from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                where type.IsSubclassOf(typeof(NodeModule))
                select type;

            Type to = typeof(NodeModule);
            foreach (Type t in serviceSubclasses)
            {
                if (t.IsAssignableFrom(to))
                    return;
                NodeModule nMod = (NodeModule)Activator.CreateInstance(t);
                nMod._GameNode = this;
                _Modules.Add(nMod);
                Logman.Logger.Log(Logman.LogLevel.Info, "Node module loaded: " + t.Name);
            }

            DependencyInjector.RegisterModules(_Modules.ToArray());
        }

        internal void StartModules()
        {
            _Modules.Reverse();
            foreach (NodeModule mod in _Modules)
            {
                mod.Init();
            }
        }

        public T GetModule<T>() where T : NodeModule
        {
            foreach (NodeModule m in _Modules)
            {
                if (m is T)
                    return (T)m;
            }
            return null;
        }

        internal RenderBuf PollRenderingModule(NodeModule m)
        {
            return m.GetAtomRenders();
        }

        internal override void Update(double delta)
        {
            foreach (NodeModule m in _Modules)
            {
                if (m.Rendering)
                {
                    RenderBuf buf = PollRenderingModule(m);
                    Message.Send(typeof(RenderService), "append-buffer", buf);
                }
                m.Update(delta);
            }
        }
    }
}
