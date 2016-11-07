using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Engine.Engine.Objects;
using Game_Engine.Engine.Logman;
using Game_Engine.Game.System.Render;
using OpenTK.Graphics;

namespace Game_Engine.Game.Atoms
{
    class PlayerAtom : GameObject
    {
        public override void Init()
        {
            //base.Start();
            Render = new RenderObject() { C = '@', Fore = Color4.White, Back = Color4.Black };
        }

        double x = 0;
        internal override void Update(double delta)
        {
            x += 1 * delta;
            if(x >= 1)
            {
                Logger.Log(LogLevel.Debug, "1s player update");
                x = 0;
            }
        }
    }
}
