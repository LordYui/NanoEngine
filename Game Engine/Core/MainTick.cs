using Game_Engine.Services;
using Game_Engine.Services.ServiceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Core
{
    class MainTick
    {
        ServiceRoot srvcRoot;
        bool isRunning = false;

        public MainTick()
        {
            srvcRoot = new ServiceRoot();
        }

        void Tick()
        {
            isRunning = true;
            while (isRunning)
            {

            }    
            Time.lastUpdate = DateTime.Now;
        }
    }
}
