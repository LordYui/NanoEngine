using Game_Engine.Engine.Services.GameNodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Game.Node
{
    class MainNode : GameNode
    {
        public MainNode() : base(true)
        {
        }

        public override void Init()
        {
            
        }

        internal override void Update(double delta)
        {
            base.Update(delta);
        }
    }
}
