
using Game_Engine.Services.ServiceManager.ServiceMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Services.ServiceManager
{
    internal class ServiceRoot
    {
        List<Service> _Services;
        public ServiceRoot()
        {
            _Services = new List<Service>();
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
                srvc.SrvcRoot = this;
                MessageRoot msgR = (MessageRoot)Activator.CreateInstance(typeof(MessageRoot), srvc); ;
                srvc.Message = msgR;
                srvc.Init();
                _Services.Add(srvc);
                Logman.Logger.Log(Logman.LogLevel.Info, "Service loaded: " + t.Name);
            }

            _Services = _Services.OrderBy(s => s.Priority).ToList();
        }

        internal void UpdateServices(double delta)
        {
            foreach(Service srvc in _Services)
            {
                srvc.UpdateService(delta);
            }
        }

        public T GetService<T>() where T : Service
        {
            foreach(Service srvc in _Services)
            {
                if (typeof(T) == srvc.GetType())
                    return (T)srvc;
            }
            throw new ArgumentException();
        }

        public Service GetService( Type T)
        {
            foreach (Service srvc in _Services)
            {
                if (T == srvc.GetType())
                    return srvc;
            }
            throw new ArgumentException();
        }
    }
}
