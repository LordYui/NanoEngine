using Game_Engine.Engine.Injector;
using Game_Engine.Engine.Services.Scripts;
using Game_Engine.Engine.Objects.Internals;
using Game_Engine.Engine.Logman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Engine.Engine.Services.Input;
using Game_Engine.Engine.Objects;
using Game_Engine.Game.Atoms;

namespace Game_Engine
{
    [Injectable(typeof(InputSystem))]
    class TestScene : SceneBase
    {
        override public void Init()
        {
            this.InjectSrvc();
            
            PlayerAtom Player = new PlayerAtom();
            
        }

        internal override void Update(double delta)
        {
            
        }
    }
}
