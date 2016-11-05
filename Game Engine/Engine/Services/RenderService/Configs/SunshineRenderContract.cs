using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Services.RenderService.Configs
{
    class SunshineRenderContract
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
