using Game_Engine.Engine.Services.GameNodes.NodeModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Engine.Engine.Objects.Internals;
using SFML.Graphics;
using Game_Engine.Game.Atoms;
using SFML.System;

namespace Game_Engine.Game
{
    class MainScene : SceneBase
    {
        TestAtom tA;
        public override void Init()
        {
            tA = new TestAtom();
        }

        internal override void Update(double delta)
        {
            tA.Position += new Vector2f((float)(10 * delta), 0);
        }
    }
}
