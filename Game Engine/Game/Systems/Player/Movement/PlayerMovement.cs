using Game_Engine.Engine.Objects.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Game.Systems.Player.Movement
{
    class PlayerMovement : BaseObject
    {
        PlayerService _Srvc;
        public PlayerMovement(PlayerService s)
        {
            s = _Srvc;
        }

        public override void Init()
        {
           
        }

        internal void onPlayerCommand(object o)
        {

        }

        internal override void Update(double delta)
        {
            
        }
    }
}
