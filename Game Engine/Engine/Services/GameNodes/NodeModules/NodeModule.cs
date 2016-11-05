using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Engine.Engine.Objects.Internals;
using Game_Engine.Engine.Objects;

namespace Game_Engine.Engine.Services.GameNodes
{
    abstract class NodeModule
    {
        internal bool Rendering = false;

        List<BaseObject> moduleObjects = new List<BaseObject>();

        abstract internal void UpdateModule(double delta);
        public virtual RenderBuf GetAtomRenders()
        {
            foreach(BaseObject bO in moduleObjects)
            {
                if(bO is Atom)
                {
                    // get render
                }  
            }

            return new RenderBuf();
        }

        internal virtual void Start() { }
    }
}
