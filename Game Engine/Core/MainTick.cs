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
        NodeSystem _nodeSystem;
        
        public MainTick()
        {
            _nodeSystem = new NodeSystem();
        }

        void Tick()
        {
            _nodeSystem.RunUpdates();
            Time.lastUpdate = DateTime.Now;
        }
    }
}
