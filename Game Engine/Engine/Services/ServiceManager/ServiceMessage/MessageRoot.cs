﻿using System;
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
        Service _Parent;
        public MessageRoot(Service parent)
        {
            _Parent = parent;
        }
        List<MessageDefinition> msgDefs = new List<MessageDefinition>();
        internal void On(string n, MessageAct a)
        {
            MessageDefinition d = msgDefs.Find(m => m.Name == n);
            if(d.Name == null)
                msgDefs.Add(new ServiceMessage.MessageDefinition(n, a));
        }

        public void Receive(string n, Service sender, params object[] args)
        {
            MessageDefinition d = msgDefs.Find(m => m.Name == n);
            if (d.Name != null)
                d.Act.DynamicInvoke(new object[] { args });
        }

        public void Send(Type trgtSrvcType, string m, params object[] args)
        {
            Service c = _Parent.SrvcRoot.GetService(trgtSrvcType);
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