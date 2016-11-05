using Game_Engine.Engine.Injector;
using Game_Engine.Engine.Services.ServiceManager;
using Game_Engine.Services.ServiceManager.ServiceMessage;

namespace Game_Engine.Engine.Services
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
            this.InjectSrvc();
        }

        abstract internal void UpdateService(double delta);
        virtual internal void Init() { }
    }
}