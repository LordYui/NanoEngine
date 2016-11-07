using Game_Engine.Engine.Injector;
using Game_Engine.Engine.Objects.Internals;
using Game_Engine.Engine.Services;
using Game_Engine.Engine.Services.Input;
using Game_Engine.Game.Systems.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Game.Systems.Input
{
    [Injectable(typeof(InputSystem))]
    class InputService : Service
    {
        List<InputConfig> _Conf;
        InputSystem _InputSystem;
        public override void Init()
        {
            this.InjectSrvc();
            _Conf = new List<InputConfig>();

            _Conf.Add(new Input.InputConfig(OpenTK.Input.Key.D, new KeyActionDelegate((k) =>
            {
                Message.Send(typeof(PlayerService), "player-control-pressed", k);
            })));
        }

        internal override void Update(double delta)
        {
            foreach(InputConfig conf in _Conf)
            {
                if (_InputSystem.isKeyDown(conf.Key))
                    conf.Del.DynamicInvoke(conf.Key);
            }
        }
    }
}
