using Game_Engine.Engine.Services;
using Game_Engine.Engine.Services.ServiceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Game_Engine.Engine.Injector;
using Game_Engine.Engine.Objects.Internals;

namespace Game_Engine.Services.ServiceManager.ServiceMessage
{
    [Injectable(typeof(ServiceRoot))]
    class MessageRoot
    {
        ServiceRoot _SrvcRoot;
        BaseObject _Parent;

        public MessageRoot(BaseObject p)
        {
            _Parent = p;
        }
        List<MessageDefinition> msgDefs = new List<MessageDefinition>();
        internal void On(string n, MessageAct a)
        {
            MessageDefinition d = msgDefs.Find(m => m.Name == n);
            if (d.Name == null)
                msgDefs.Add(new ServiceMessage.MessageDefinition(n, a));
        }

        public void Receive(string n, BaseObject sender, params object[] args)
        {
            MessageDefinition d = msgDefs.Find(m => m.Name == n);
            if (d.Name != null)
                d.Act.DynamicInvoke(new object[] { args });
        }

        public void Send(Type trgtSrvcType, string m, params object[] args)
        {
            Service c = _SrvcRoot.GetService(trgtSrvcType);
            c.Message.Receive(m, _Parent, args);
        }

        public void SendDirect(ServiceRoot r, Type trgtSrvcType, string m, params object[] args)
        {
            Service c = r.GetService(trgtSrvcType);
            c.Message.Receive(m, _Parent, args);
        }
    }

    public delegate void MessageAct(params object[] args);

    struct MessageDefinition
    {
        public string Name;
        public MessageAct Act;

        public MessageDefinition(string n, MessageAct a)
        {
            Name = n;
            Act = a;
        }
    }
}