using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Services.ServiceManager
{
    class ServiceRoot
    {
        public List<Service> Services;
        public ServiceRoot()
        {
            Services = new List<Service>();
            InitializeServices();
        }

        void InitializeServices()
        {
            var serviceSubclasses =
                from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                where type.IsSubclassOf(typeof(Service))
                select type;

            foreach(Type t in serviceSubclasses)
            {
                Service srvc = (Service)Activator.CreateInstance(t);
                srvc.Root = this;
                Services.Add(srvc);
                Logman.Logger.Log(Logman.LogLevel.Info, "Service loaded: " + t.Name);
            }
        }
    }
}
