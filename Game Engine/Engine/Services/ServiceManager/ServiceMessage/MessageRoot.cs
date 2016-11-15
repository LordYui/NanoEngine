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
using Game_Engine.Engine.Services.GameNodes.GameObjects;

namespace Game_Engine.Services.ServiceManager.ServiceMessage
{
    [Injectable(typeof(ServiceRoot))]
    class MessageRoot
    {
        static internal List<MessageLog> Logs = new List<MessageLog>();

        internal ServiceRoot _SrvcRoot;
        BaseObject _Parent;

        public MessageRoot(BaseObject p)
        {
            _Parent = p;
            this.InjectSrvc();
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
            Logs.Add(new MessageLog(sender, _Parent, n, args));
            MessageDefinition d = msgDefs.Find(m => m.Name == n);
            if (d.Name != null)
                d.Act.DynamicInvoke(new object[] { args });
        }

        public void Send(Type trgtType, string m, params object[] args)
        {
            if (trgtType.BaseType == typeof(Service))
                SendSrvc(trgtType, m, args);
            else if (trgtType.IsAssignableFrom(typeof(BaseObject)))
                SendGameObject(trgtType, m, args);
            else
                SendObject(trgtType, m, args);
        }

        private void SendSrvc(Type trgtSrvcType, string m, params object[] args)
        {
            Service c = _SrvcRoot.GetService(trgtSrvcType);
            c.Message.Receive(m, _Parent, args);
        }

        private void SendGameObject(Type trgtObjType, string m, params object[] args)
        {
            BaseObject bO = _SrvcRoot.GetService<NodeSystem>().GetActiveNode().GetModule<GameObjectModule>().GetGameObject(trgtObjType);
            bO.Message.Receive(m, _Parent, args);
        }

        private void SendObject(Type trgtObjType, string m, params object[] args)
        {

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

    struct MessageLog
    {
        public BaseObject Sender;
        public BaseObject Receiver;
        public string Command;
        public object[] Args;

        public MessageLog(BaseObject s, BaseObject r, string c, params object[] a)
        {
            Sender = s;
            Receiver = r;
            Command = c;
            Args = a;
        }
    }
}