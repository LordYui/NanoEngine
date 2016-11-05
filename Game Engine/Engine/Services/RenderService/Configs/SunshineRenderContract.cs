using Game_Engine.Engine.Services.Render.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Engine.Services.Render.Configs
{
    class SunshineRenderContract : RenderContract
    {
        public char C;
        public int X;
        public int Y;

        public SunshineRenderContract(char c, int x, int y)
        {
            C = c;
            X = x;
            Y = y;
        }
    }
}
