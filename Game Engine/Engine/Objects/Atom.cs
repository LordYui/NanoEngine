using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Engine.Engine.Objects.Internals;
using SFML.Graphics;
using Game_Engine.Engine.Services.Render.Configs;

namespace Game_Engine.Engine.Objects
{
    abstract class Atom : GameObjectBase
    {
        private SFMLRenderContract _render;
        public SFMLRenderContract Render
        {
            get
            {
                if (_render == null)
                    return null;
                //_render.transform = ((Transformable)_render.Draw).Transform;
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
