using Game_Engine.Render;
using Game_Engine.Systems.GameNodes;
using System;
using System.Collections.Generic;
using Game_Engine.Injector;

namespace Game_Engine.Systems
{
    class Bridge
    {
        RendererTick gameRenderer;
        List<GameNode> gameNodes = new List<GameNode>();

        public Bridge()
        {
            DependencyInjector.RegisterService<Bridge>(this);
        }

        public Bridge(RendererTick gR)
        {
            gameRenderer = gR;
        }

        public void RunUpdates()
        {

        }
    }
}
