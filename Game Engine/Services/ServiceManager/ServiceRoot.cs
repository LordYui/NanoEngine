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
                Services.Add((Service)Activator.CreateInstance(t));
            }
        }
    }
}
