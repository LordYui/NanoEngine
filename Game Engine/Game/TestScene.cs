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

namespace Game_Engine
{
    [Injectable(typeof(InputSystem))]
    class TestScene : SceneBase
    {
        InputSystem inputs;
        override public void Start()
        {
            this.InjectSrvc();
        }

        internal override void Update(double delta)
        {
            if (inputs.isKeyDown(OpenTK.Input.Key.E))
            {
                Logger.Log(LogLevel.Info, "Pressing E");
            }
        }
    }
}
