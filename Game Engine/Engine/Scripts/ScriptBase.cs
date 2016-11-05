using Game_Engine.Engine.Injector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Engine.Scripts
{
    abstract class ScriptBase
    {
        public ScriptBase()
        {
            this.Inject();
        }
        abstract public void Start();
        virtual public void Update(double delta) { return; }
    }
}
