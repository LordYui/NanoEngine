using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Engine.Engine.Objects.Internals;
using Game_Engine.Engine.Objects;
using Game_Engine.Engine.Injector;

namespace Game_Engine.Engine.Services.GameNodes
{
    abstract class NodeModule : BaseObject
    {
        internal bool Rendering = false;
        internal GameNode _GameNode;

        List<BaseObject> moduleObjects = new List<BaseObject>();

        public override void Init()
        {
            
        }

        public virtual RenderBuf GetAtomRenders()
        {
            RenderBuf retRnd = new RenderBuf();
            foreach(BaseObject bO in moduleObjects)
            {
                if(bO is Atom)
                {
                    retRnd.renderObjects.Add(((Atom)bO).Render);
                }  
            }

            return new RenderBuf();
        }
    }
}
