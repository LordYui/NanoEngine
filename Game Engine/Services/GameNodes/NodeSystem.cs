using Game_Engine.Services.GameNodes;
using System;
using System.Collections.Generic;
using Game_Engine.Injector;

namespace Game_Engine.Services
{
    class NodeSystem : Service
    {
        List<GameNode> gameNodes = new List<GameNode>();

        public NodeSystem()
        {
            
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
