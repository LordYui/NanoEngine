using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Core
{
    static class Time
    {
        public static uint TargetFPS { get; set; } = 60;

        public static DateTime lastUpdate;
        public static double deltaTime { get; private set; }
        //public static double deltaTime
        //{
        //    get
        //    {
        //        return (DateTime.Now - lastUpdate).TotalSeconds;
        //    }
        //}

        static void SetDeltaTime(double dt)
        {
            deltaTime = dt;
        }
    }
}
