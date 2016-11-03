using Game_Engine.Systems.GameNodes;
using System;
using System.Collections.Generic;
using Game_Engine.Injector;

namespace Game_Engine.Systems
{
    class NodeSystem
    {
        List<GameNode> gameNodes = new List<GameNode>();

        public NodeSystem()
        {
            DependencyInjector.RegisterService<NodeSystem>(this);
        }

        public NodeSystem(RendererTick gR)
        {
            gameRenderer = gR;
        }

        public void RunUpdates()
        {

        }
    }
}
