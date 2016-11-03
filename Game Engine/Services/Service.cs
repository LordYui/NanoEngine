using Game_Engine.Injector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Services
{
    class Service
    {
        public Service()
        {
            DependencyInjector.RegisterService(this);
            this.Inject();
        }
    }
}