using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Game.Systems.Input
{
    class InputConfig
    {
        public Key Key { get; private set; }
        public KeyActionDelegate Del { get; private set; }

        public InputConfig(Key k, KeyActionDelegate d)
        {
            Key = k;
            Del = d;
        }
    }

   delegate void KeyActionDelegate(Key k);
}
