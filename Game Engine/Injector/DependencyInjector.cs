using System;
using System.Reflection;
using Game_Engine.Systems;
using System.Collections.Generic;
using System.Diagnostics;

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

        public static void RegisterService<T>(T o)
        {
            _injectableTypes.Add(typeof(T));
            _injectableServices.Add(o);
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

    [Injectable(typeof(Bridge))]
    class TestAttr
    {
        Bridge _b;
        public Bridge _b2;
        public TestAttr()
        {
            this.Inject();

            Console.WriteLine("_b exists: " + (_b != null));
            Console.WriteLine("_b2 exists: " + (_b2 != null));

            Console.ReadLine();
        }
    }
}
