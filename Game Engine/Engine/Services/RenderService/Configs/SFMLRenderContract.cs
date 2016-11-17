using Game_Engine.Engine.Objects.Internals;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Engine.Services.Render.Configs
{
    class SFMLRenderContract : RenderBase
    {
        // todo: sprites
        public Drawable Draw;
        public SFMLRenderContract(Drawable d)
        {
            Draw = d;
            //Transformable = (Transformable)d;
        }
    }
}
