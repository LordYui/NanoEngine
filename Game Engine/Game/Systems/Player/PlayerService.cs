using Game_Engine.Engine.Services;
using Game_Engine.Game.Systems.Player.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Game.Systems.Player
{
    class PlayerService : Service
    {
        PlayerMovement _Movement;
        public override void Init()
        {
            _Movement = new PlayerMovement(this);
            Message.On("player-control-pressed", new Services.ServiceManager.ServiceMessage.MessageAct((k) => { _Movement.onPlayerCommand(k); })); ;
        }



        internal override void Update(double delta)
        {

        }
    }
}
