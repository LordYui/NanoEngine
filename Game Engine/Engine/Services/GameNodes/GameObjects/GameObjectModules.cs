using Game_Engine.Engine.Objects.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Engine.Services.GameNodes.GameObjects
{
    class GameObjectModule : NodeModule
    {
        List<GameObjectBase> _GameObjects;
        public override void Start()
        {
            base.Start();
        }

        void Init()
        {
            _GameObjects = new List<Objects.Internals.GameObjectBase>();
            Message.On("register-gameobject", new Game_Engine.Services.ServiceManager.ServiceMessage.MessageAct(registerGameObject));
        }

        public void registerGameObject(object[] o)
        {
            _GameObjects.Add((GameObjectBase)o[0]);
        }

        internal override void Update(double delta)
        {
            //throw new NotImplementedException();
        }
    }
}
