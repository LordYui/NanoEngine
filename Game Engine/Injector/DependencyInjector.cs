using System;
using System.Reflection;
using Game_Engine.Services;
using System.Collections.Generic;
using System.Diagnostics;
using Game_Engine.Logman;

namespace Game_Engine.Injector
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
            throw new ArgumentException();
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
            }

            ConstructorInfo cInfo = t.GetConstructors()[0];
            ParameterInfo[] pInfo = cInfo.GetParameters();
            Type[] cTypes = new Type[pInfo.Length];
            for (int i = 0; i < pInfo.Length; i++)
            {
                if (i > toInject.Count)
                    break;
                if (pInfo[i].ParameterType != toInject[i])
                    throw new ArgumentException();
            }
            T retObj = (T)Activator.CreateInstance(t, toInject);

            return retObj;
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

            FieldInfo[] fInfos = t.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            foreach (FieldInfo fI in fInfos)
            {
                Type inj = _injectableTypes.Find((ty => ty == fI.FieldType));
                if (inj == null)
                    continue;

                object newSrvc = getServiceInstance(inj);
                fI.SetValue(obj, Convert.ChangeType(newSrvc, inj));
            }

        }
    }
}