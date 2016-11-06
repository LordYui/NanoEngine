using Game_Engine.Engine.Services.GameNodes;
using System;
using System.Collections.Generic;
using Game_Engine.Engine.Injector;
using System.Linq;

namespace Game_Engine.Engine.Services
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
            var nodesSubClasses =
                from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                where type.IsSubclassOf(typeof(GameNode))
                select type;

            Type to = typeof(GameNode);
            foreach (Type t in nodesSubClasses)
            {
                if (t != to)
                    return;
                GameNode nGN = (GameNode)Activator.CreateInstance(t);
                gameNodes.Add(nGN);
                Logman.Logger.Log(Logman.LogLevel.Info, "Game node loaded: " + t.Name);
            }
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
