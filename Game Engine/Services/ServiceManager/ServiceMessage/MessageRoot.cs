using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Services.ServiceManager.ServiceMessage
{
    class MessageRoot
    {
        List<MessageDefinition> msgDefs = new List<MessageDefinition>();
        internal void On(string n, MessageAct a)
        {
            MessageDefinition d = msgDefs.Find(m => m.Name == n);
            if(d.Name != null)
                msgDefs.Add(new ServiceMessage.MessageDefinition(n, a));
        }

        public void Receive(string n, Service sender, params object[] args)
        {
            MessageDefinition d = msgDefs.Find(m => m.Name == n);
            if (d.Name != null)
                d.Act.DynamicInvoke(args);
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