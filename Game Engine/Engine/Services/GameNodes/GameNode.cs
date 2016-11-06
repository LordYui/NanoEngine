using Game_Engine.Engine.Services.GameNodes;
using Game_Engine.Engine.Objects;
using Game_Engine.Engine.Objects.Internals;
using Game_Engine.Engine.Services.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Engine.Services.ServiceManager.ServiceMessage;

namespace Game_Engine.Engine.Services.GameNodes
{
    [Injector.InjectableAttribute(typeof(Render.RenderService))]
    class GameNode : BaseObject
    {
        public bool Active { get; private set; }

        List<NodeModule> _Modules;
        public override void Start()
        {
            _Modules = new List<NodeModule>();
            initModules();

            Message.On("set-active", new MessageAct(SetActive));
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
                nMod.Start();
                _Modules.Add(nMod);
                Logman.Logger.Log(Logman.LogLevel.Info, "Node module loaded: " + t.Name);
            }
        }

        internal RenderBuf PollRenderingModule(NodeModule m)
        {
            return new RenderBuf();
        }

        internal override void Update(double delta)
        {
            foreach (NodeModule m in _Modules)
            {
                if (m.Rendering)
                {
                    RenderBuf buf = PollRenderingModule(m);
                }
                m.Update(delta);
            }
        }
    }
}
