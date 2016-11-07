using Game_Engine.Engine.Services.Render.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics;
using OpenTK;
using Game_Engine.Engine.Objects.Internals;

namespace Game_Engine.Engine.Services.Render.Configs
{
    class SunshineRenderContract : RenderBase
    {
        public char C;
        public Color4 Fore;
        public Color4 Back;
        //public Vector2 Pos;
        public SunshineRenderContract(char c, Color4 x, Color4 y)
        {
            C = c;
            Fore = x;
            Back = y;
        }
    }
}
