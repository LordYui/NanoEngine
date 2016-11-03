using Game_Engine.Injector;
using Game_Engine.Services.ServiceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Services
{
    class Service
    {
        public ServiceRoot Root;
        public Service()
        {
            DependencyInjector.RegisterService(this);
            this.Inject();
        }
    }
}