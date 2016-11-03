using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Services.ServiceMessage
{
    class MessageRoot
    {
        List<MessageDefinition> _MessageDefs;
        public MessageRoot()
        {
            _MessageDefs = new List<ServiceMessage.MessageDefinition>();
            InitializeMessages();
        }

        public void InitializeMessages()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                Type[] asTy = assembly.GetTypes();
                foreach (Type t in asTy)
                {
                    foreach (MethodInfo m in t.GetMethods())
                    {
                        MessageAttribute attrInf = m.GetCustomAttribute<MessageAttribute>();
                        if (attrInf != null)
                        {
                            Delegate d = m.CreateDelegate(Expression.GetDelegateType(
            (from parameter in m.GetParameters() select parameter.ParameterType)
            .Concat(new[] { m.ReturnType })
            .ToArray()));
                            _MessageDefs.Add(new MessageDefinition(m.Name, d));
                        }
                    }
                }
            }
        }
    }

    struct MessageDefinition
    {
        public string Name;

        public Delegate Act;

        public MessageDefinition(string n, Delegate a)
        {
            Name = n;
            Act = a;
        }
    }
}