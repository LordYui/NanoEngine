using Game_Engine.Engine.Services.GameNodes;
using System;
using System.Collections.Generic;
using Game_Engine.Engine.Injector;
using System.Linq;
using Game_Engine.Engine.Services.GameNodes.GameObjects;

namespace Game_Engine.Engine.Services
{
    class NodeSystem : Service
    {
        List<GameNode> gameNodes = new List<GameNode>();

        public override void Init()
        {
            //base.Init();
            Message.On("register-gameobject", new Game_Engine.Services.ServiceManager.ServiceMessage.MessageAct(registerGameObject));

            initNodes();
        }

        private void registerGameObject(object[] o)
        {
            GameNode n = GetActiveNode();
            GameObjectModule goM = n.GetModule<GameObjectModule>();
            goM.registerGameObject(o);
        }

        private void initNodes()
        {
            var nodesSubClasses =
                from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                where type.IsSubclassOf(typeof(GameNode))
                select type;

            
            foreach (Type t in nodesSubClasses)
            {
               if (t.IsAbstract)
                    return;
                GameNode nGN = (GameNode)Activator.CreateInstance(t);
                nGN._System = this;
                gameNodes.Add(nGN);
                Logman.Logger.Log(Logman.LogLevel.Info, "Game node loaded: " + t.Name);
            }

            foreach(GameNode gN in gameNodes)
            {
                gN.StartModules();
            }
        }

        public GameNode GetActiveNode()
        {
            foreach(GameNode gN in gameNodes)
            {
                if (gN.Active)
                    return gN;
            }
            return null;
        }

        internal override void Update(double delta)
        {
            int inactiveNodes = 0;
            foreach(GameNode node in gameNodes)
            {
                if (node.Active)
                    node.Update(delta);
                else
                    inactiveNodes++;
            }

            if (inactiveNodes < gameNodes.Count - 1) // More than 1 Enabled at a time
                Logman.Logger.Log(Logman.LogLevel.Errors, "More than one GameNode enabled !");
            else if (inactiveNodes >= gameNodes.Count) // All disabled
                Logman.Logger.Log(Logman.LogLevel.Errors, "No GameNode enabled !");
        }
    }
}
