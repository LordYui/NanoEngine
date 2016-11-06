using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Engine.Engine.Injector;
using Game_Engine.Services.ServiceManager.ServiceMessage;

namespace Game_Engine.Engine.Objects.Internals
{
    abstract class BaseObject
    {
        static int _ID = 0;
        public int ID;
        internal MessageRoot Message;
        public BaseObject()
        {
            ID = _ID++;
            Message = new MessageRoot(this);
            this.InjectSrvc();
            this.Inject();
        }
     
        virtual public void Start() { }
        abstract internal void Update(double delta);
    }
}
