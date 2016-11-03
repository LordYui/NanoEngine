using Game_Engine.Services.ServiceMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Services.ServiceManager
{
    public class ServiceRoot
    {
        public List<Service> Services;
        MessageRoot _MessageRoot;
        public ServiceRoot()
        {
            Services = new List<Service>();
            _MessageRoot = new MessageRoot();
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

        public T GetService<T>() where T : Service
        {
            foreach(Service srvc in Services)
            {
                if (typeof(T) == srvc.GetType())
                    return (T)srvc;
            }
            throw new ArgumentException();
        }
    }
}
