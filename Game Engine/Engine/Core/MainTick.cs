using Game_Engine.Engine.Services;
using Game_Engine.Engine.Services.ServiceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                DateTime start = DateTime.Now;
                // Do stuff
                srvcRoot.UpdateServices(Time.deltaTime);
                DateTime end = DateTime.Now;

                double computedDeltaTime = (end - start).TotalSeconds;
                if (computedDeltaTime < 1.00 / Time.TargetFPS)
                {
                    Thread.Sleep((int)((1.00 / Time.TargetFPS - computedDeltaTime) * 1000));
                    computedDeltaTime = (1.00 / Time.TargetFPS);
                }

                var setDeltaTimeMethod = typeof(Time).GetMethod("SetDeltaTime", BindingFlags.Static | BindingFlags.NonPublic);
                setDeltaTimeMethod.Invoke(null, new object[] { computedDeltaTime }); // Super hacky way of calling a method, but for the greater good in the means of the user not setting his own delta time.

                //Time.lastUpdate = DateTime.Now;
            }    
        }
    }
}
