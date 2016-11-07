using Game_Engine.Engine.Objects;
using Game_Engine.Game.System.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Game.Atoms
{
    abstract class GameObject : Atom
    {
        public RenderObject render;
    }
}
