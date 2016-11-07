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
        private RenderBase _render;
        public RenderBase Render
        {
            get
            {
                if (_render == null)
                    return null;
                _render.Pos = transform.Position;
                return _render;
            }
            protected set
            {
                _render = value;
            }
        } 
        public Transform transform;
        public Atom()
        {
            transform = new Transform();
        }

        virtual public void Start() { }
        virtual public void Update() { }
    }
}
