using Game_Engine.Injector;
using Game_Engine.Services.ServiceManager;
using Game_Engine.Services.ServiceManager.ServiceMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Services
{
    abstract class Service
    {
        internal ServiceRoot SrvcRoot;
        internal MessageRoot Message;
        /// <summary>
        /// Higher is lower priority
        /// </summary>
        internal int Priority = 0;
        public Service()
        {
            DependencyInjector.RegisterService(this);
            this.Inject();
        }

        abstract internal void UpdateService(double delta);
    }
}