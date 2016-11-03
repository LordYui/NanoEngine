using Game_Engine.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Core
{
    class MainTick
    {
        Bridge _Bridge;
        public MainTick()
        {
            _Bridge = new Bridge();
        }

        void Tick()
        {

            Time.lastUpdate = DateTime.Now;
        }
    }
}
