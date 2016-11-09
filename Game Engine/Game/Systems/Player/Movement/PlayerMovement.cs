using Game_Engine.Engine.Objects.Internals;
using Game_Engine.Game.Systems.Input;
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

        internal void onPlayerCommand(object[] o)
        {
            InputConfig conf = (InputConfig)o[0];
            conf.Del.Invoke();
        }

        internal override void Update(double delta)
        {
            
        }
    }
}
