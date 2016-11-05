using Game_Engine.Services.GameNodes;
using System;
using System.Collections.Generic;
using Game_Engine.Injector;
using System.Linq;

namespace Game_Engine.Services
{
    class NodeSystem : Service
    {
        List<GameNode> gameNodes = new List<GameNode>();

        internal override void Init()
        {
            base.Init();
            initNodes();
        }

        private void initNodes()
        {
            var serviceSubclasses =
                from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                where type.IsSubclassOf(typeof(_GameNodeParent))
                select type;

            Type to = typeof(GameNode);
            foreach (Type t in serviceSubclasses)
            {
                if (t != to)
                    return;
                GameNode nGN = (GameNode)Activator.CreateInstance(t);
                Logman.Logger.Log(Logman.LogLevel.Info, "Game node loaded: " + t.Name);
            }
        }

        internal override void UpdateService(double delta)
        {
            foreach(GameNode node in gameNodes)
            {
                node.Update(delta);
            }
        }
    }
}
