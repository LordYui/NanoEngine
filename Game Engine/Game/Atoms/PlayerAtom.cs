using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Engine.Engine.Objects;
using Game_Engine.Engine.Logman;
using OpenTK.Graphics;
using Game_Engine.Engine.Services.Render.Configs;

namespace Game_Engine.Game.Atoms
{
    class PlayerAtom : GameObject
    {
        public override void Init()
        {
            //base.Start();
            Render = new SunshineRenderContract('@', Color4.White, Color4.Black);
        }

        internal override void Update(double delta)
        {

        }
    }
}
