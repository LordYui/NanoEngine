using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Services.Scripts
{
    class ScriptService : Service
    {
        internal override void Init()
        {
            base.Init();
            initScripts();
        }

        private void initScripts()
        {
            
        }

        internal override void UpdateService(double delta)
        {
            throw new NotImplementedException();
        }
    }
}
