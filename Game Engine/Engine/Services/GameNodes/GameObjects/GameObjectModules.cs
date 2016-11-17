using Game_Engine.Engine.Objects;
using Game_Engine.Engine.Objects.Internals;
using Game_Engine.Engine.Services.Render.Configs;
using SFML.Graphics;
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
        public override void Init()
        {
            base.Init();
            _GameObjects = new List<GameObjectBase>();
            Message.On("register-gameobject", new Game_Engine.Services.ServiceManager.ServiceMessage.MessageAct(registerGameObject));
        }

        public void registerGameObject(object[] o)
        {
            GameObjectBase gO = (GameObjectBase)o[0];
            _GameObjects.Add(gO);
            gO.Init();

        }

        public RenderBuf getGameObjectsRenderer()
        {
            RenderBuf b = new Objects.Internals.RenderBuf();
            foreach(GameObjectBase go in _GameObjects)
            {
                if(go is Atom)
                {
                    Atom a = (Atom)go;
                    SFMLRenderContract nB = a.Render;
                    if (nB != null)
                    {
                        ((Transformable)nB.Draw).Position = a.Position;
                        b.renderObjects.Add(a.Render);
                    }
                }
            }
            return b;
        }

        internal override void Update(double delta)
        {
            foreach(GameObjectBase goB in _GameObjects)
            {
                goB.Update(delta);
            }
        }

        public GameObjectBase GetGameObject(Type t)
        {
            foreach(GameObjectBase goB in _GameObjects)
            {
                if (goB.GetType() == t)
                    return goB;
            }
            return null;
        }
    }
}
