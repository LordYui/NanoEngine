using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Engine.Engine.Injector;
using Game_Engine.Engine.Services.GameNodes.GameObjects;
using Game_Engine.Engine.Services;

namespace Game_Engine.Engine.Objects.Internals
{
    [Injectable(typeof(GameObjectModule))]
    abstract class GameObjectBase : BaseObject
    {
        GameObjectModule _Mod;
        public GameObjectBase()
        {
            this.Inject();
            Message._SrvcRoot = _Mod._GameNode._System.SrvcRoot;
            Message.Send(typeof(NodeSystem), "register-gameobject", this);
        }
    }
}
