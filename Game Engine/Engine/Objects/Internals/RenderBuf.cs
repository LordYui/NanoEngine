using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Engine.Objects.Internals
{
    /// <summary>
    /// Returned by NodeModules, to be rendered
    /// </summary>
    class RenderBuf
    {
        public List<object> renderObjects;

        public RenderBuf()
        {
            renderObjects = new List<object>();
        }
    }
}
