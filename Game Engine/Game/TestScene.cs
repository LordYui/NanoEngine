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

namespace Game_Engine
{
    [Injectable(typeof(InputSystem))]
    class TestScene : SceneBase
    {
        InputSystem inputs;
        TestObj a;
        override public void Start()
        {
            this.InjectSrvc();
            a = new TestObj();
        }

        internal override void Update(double delta)
        {
            if (inputs.isKeyDown(OpenTK.Input.Key.E))
            {
                Logger.Log(LogLevel.Info, "Pressing E");
            }
        }
    }

    class TestObj : Atom
    {
        internal override void Update(double delta)
        {
            throw new NotImplementedException();
        }
    }
}
