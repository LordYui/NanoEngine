using System;
using System.Reflection;
using Game_Engine.Services;
using System.Collections.Generic;
using System.Diagnostics;
using Game_Engine.Engine.Logman;
using Game_Engine.Engine.Scripts;
using Game_Engine.Engine.Services;
using Game_Engine.Engine.Injector;
using System.Linq;
using Game_Engine.Engine.Services.GameNodes;

namespace Game_Engine.Engine.Injector
{
    static class DependencyInjector
    {
        static List<Type> _injectableTypes = new List<Type>();
        static List<object> _injectableServices = new List<object>();

        static object getServiceInstance(Type tIn)
        {
            if (_injectableTypes.Contains(tIn))
            {
                foreach (object srv in _injectableServices)
                {
                    if (srv.GetType() == tIn)
                        return srv;
                }
            }
            return null;
        }

        public static void RegisterService(Service o)
        {
            if (!_injectableTypes.Contains(o.GetType()))
            {
                if (_injectableTypes.Find(sr => sr.GetType() == o.GetType()) == null)
                {
                    _injectableTypes.Add(o.GetType());
                    _injectableServices.Add(o);
                }
            }
        }

        public static T InjectAndCreateOfType<T>()
        {
            Type t = typeof(T);
            var mInfo = t.GetCustomAttributes();
            List<Type> toInject = new List<Type>();
            foreach (var at in mInfo)
            {
                if (at is InjectableAttribute)
                {
                    toInject.AddRange(((InjectableAttribute)at).InjectTypes);
                }
                else if(at is ProviderAttribute)
                {
                    toInject.AddRange(((ProviderAttribute)at).InjectTypes);
                }
            }

            FieldInfo[] fInfos = t.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            T retObj = (T)Activator.CreateInstance(t);
            foreach (FieldInfo fI in fInfos)
            {
                Type inj = _injectableTypes.Find((ty => ty == fI.FieldType));
                if (inj == null)
                    continue;

                fI.SetValue(retObj, Convert.ChangeType(typeof(T), inj));
            }

            return retObj;
        }

        public static T InjectAndCreateOfType<T>(Type inTy)
        {
            Type t = typeof(T);
            var mInfo = t.GetCustomAttributes();
            List<Type> toInject = new List<Type>();
            foreach (var at in mInfo)
            {
                if (at is InjectableAttribute)
                {
                    toInject.AddRange(((InjectableAttribute)at).InjectTypes);
                }
                else if (at is ProviderAttribute)
                {
                    toInject.AddRange(((ProviderAttribute)at).InjectTypes);
                }
            }

            FieldInfo[] fInfos = t.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            T retObj = (T)Activator.CreateInstance(t);
            foreach (FieldInfo fI in fInfos)
            {
                Type inj = _injectableTypes.Find((ty => ty == fI.FieldType));
                if (inj == null)
                    continue;

                fI.SetValue(retObj, Convert.ChangeType(typeof(T), inj));
            }

            return retObj;
        }

        public static void InjectSrvc<T>(this T obj)
        {
            Type t = typeof(T);
            var attrInfo = t.GetCustomAttributes();
            List<Type> toInject = new List<Type>();
            foreach (var at in attrInfo)
            {
                if (at is InjectableAttribute)
                {
                    toInject.AddRange(((InjectableAttribute)at).InjectTypes);
                }
            }

            FieldInfo[] fInfos = t.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (FieldInfo fI in fInfos)
            {
                Type inj = _injectableTypes.Find((ty => ty == fI.FieldType));
                if (inj == null)
                    continue;

                object newSrvc = getServiceInstance(inj);
                fI.SetValue(obj, Convert.ChangeType(newSrvc, inj));
            }
        }

        public static void Inject<T>(this T obj)
        {
            Type t = typeof(T);
            var attrInfo = t.GetCustomAttributes();
            List<Type> toInject = new List<Type>();
            foreach (var at in attrInfo)
            {
                if (at is InjectableAttribute)
                {
                    toInject.AddRange(((InjectableAttribute)at).InjectTypes);
                }
            }


            FieldInfo[] fInfos = t.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (Type toInj in toInject)
            {
                foreach (FieldInfo fI in fInfos)
                {
                    if (toInj.IsSubclassOf(typeof(NodeModule)) && fI.FieldType.IsSubclassOf(typeof(NodeModule)))
                    {
                        fI.SetValue(obj, GetModule(toInj));
                    }
                    else if (toInj.IsSubclassOf(typeof(Service)) && fI.FieldType.IsSubclassOf(typeof(Service)))
                    {
                        object srvc = getServiceInstance(toInj);
                        fI.SetValue(obj, srvc);
                    }
                }
            }
        }

        private static List<NodeModule> _nodeModules = new List<NodeModule>();

        internal static void RegisterModules(NodeModule[] modules)
        {
            _nodeModules.AddRange(modules);
        }

        private static object GetModule(Type t)
        {
            if (_nodeModules.Count == 0)
            {
                Logman.Logger.Log(LogLevel.Errors, "Injector: module list not set");
                throw new Exception("Injector: module list not set");
            }

            foreach(NodeModule m in _nodeModules)
            {
                if(m.GetType() == t)
                    return m;
            }
            return null;
        }
    }
}