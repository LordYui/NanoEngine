using Game_Engine.Engine.Services;
using Game_Engine.Engine.Services.ServiceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game_Engine.Core
{
    class MainTick
    {
        ServiceRoot srvcRoot;
        bool isRunning = false;

        public MainTick(Type renderConf)
        {
            srvcRoot = new ServiceRoot();
            SetRenderConfig(renderConf);
            Tick();
        }

        void SetRenderConfig(Type renderConfig)
        {
            srvcRoot.SetRenderConfig(renderConfig);
        }

        void Tick()
        {
            isRunning = true;
            while (isRunning)
            {
                //Console.ReadLine();
                srvcRoot.UpdateServices(Time.deltaTime);
                Time.lastUpdate = DateTime.Now;
            }    
        }
    }
}
