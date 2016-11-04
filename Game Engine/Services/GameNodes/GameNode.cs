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
    [Injector.Injectable(typeof(RenderService))]
    class GameNode
    {
        static int _ID = 0;
        public int ID;

        List<NodeModule> _Modules;
        public GameNode()
        {
            ID = _ID++;
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
