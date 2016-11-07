using Game_Engine.Engine.Injector;
using Game_Engine.Engine.Objects.Internals;
using Game_Engine.Engine.Services.ServiceManager;
using Game_Engine.Services.ServiceManager.ServiceMessage;

namespace Game_Engine.Engine.Services
{
    abstract class Service : BaseObject
    {
        internal ServiceRoot SrvcRoot;
        internal int Priority = 0;

        internal bool Ready = false;
        public Service() : base()
        {
            DependencyInjector.RegisterService(this);
            this.InjectSrvc();
            Ready = true;
        }
        //virtual internal void Init() { }
    }
}