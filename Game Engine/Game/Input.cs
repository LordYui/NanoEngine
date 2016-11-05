using Game_Engine.Engine.Injector;
using Game_Engine.Engine.Scripts;
using Game_Engine.Engine.Services.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine
{
    [Injectable(typeof(InputSystem))]
    class Input : ScriptBase
    {
        InputSystem _InputSystem;

        public override void Start()
        {
            
        }
    }
}
