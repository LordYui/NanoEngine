using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Engine.Engine.Objects.Internals;

namespace Game_Engine.Engine.Objects
{
    abstract class Atom : GameObjectBase
    {
        RenderObject _RenderObj;
        Transform transform;
        public Atom()
        {
            transform = new Transform();
        }

        virtual public void Start() { }
        virtual public void Update() { }
    }
}
