using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Engine.Engine.Injector;
using Game_Engine.Engine.Services.GameNodes.GameObjects;

namespace Game_Engine.Engine.Objects.Internals
{
    abstract class GameObjectBase : BaseObject
    {
        GameObjectModule _Mod;
        public GameObjectBase() 
        {
            this.Inject();
            Message.Send(typeof(GameObjectModule), "register-gameobject", this);
        }
    }
}
