using Game_Engine.Engine.Services.GameNodes.NodeModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Engine.Engine.Objects.Internals;
using SFML.Graphics;

namespace Game_Engine.Game
{
    class MainScene : SceneBase
    {
        Dictionary<string, Drawable> _Drawables;
        public override void Init()
        {
            _Drawables = new Dictionary<string, Drawable>();
        }

        private void LoadAssets()
        {

        }

        internal override void Update(double delta)
        {
            
        }
    }
}
