using Game_Engine.Engine.Objects.Internals;
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
        public object Sprite;
        public SFMLRenderContract(object s)
        {
            Sprite = s;
        }
    }
}
