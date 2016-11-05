using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Services.RenderSystem.Configs
{
    public class RendererConfigs
    {
        public Type renderContract;
        public RendererConfigs(Type renderContractType)
        {
            renderContract = renderContractType;
        }
    }
}
