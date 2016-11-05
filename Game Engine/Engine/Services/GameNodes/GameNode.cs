using Game_Engine.Services.GameNodes;
using Game_Engine.Objects;
using Game_Engine.Objects.Internals;
using Game_Engine.Services.RenderSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Services.GameNodes
{
    abstract class _GameNodeParent
    {
    }

    [Injector.Injectable(typeof(RenderService))]
    class GameNode : _GameNodeParent
    {
        static int _ID = 0;
        public int ID;

        List<NodeModule> _Modules;
        public GameNode()
        {
            ID = _ID++;
            _Modules = new List<NodeModule>();
            initModules();
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

        internal void Update(double delta)
        {
            foreach(NodeModule m in _Modules)
            {
                if(m.Rendering)
                {
                    RenderBuf buf = PollRenderingModule(m);
                }
                m.UpdateModule(delta);
            }
        }

        internal RenderBuf PollRenderingModule(NodeModule m)
        {
            return new RenderBuf();
        }
    }
}
