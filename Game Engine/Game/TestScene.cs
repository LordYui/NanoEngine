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
    [Injectable(typeof(ScriptService))]
    class TestScene : SceneBase
    {
        ScriptService _ScriptSrvc;
        override public void Init()
        {
            this.InjectSrvc();

        }

        internal override void Update(double delta)
        {

        }
    }
}
