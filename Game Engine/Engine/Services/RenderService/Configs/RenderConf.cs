using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Engine.Services.RenderService.Configs
{
    class RenderConf
    {
        public Type Contract;
        public RenderConf(Type t)
        {
            Contract = t;
        }
    }
}
