using Game_Engine.Engine.Injector;
using Game_Engine.Engine.Objects.Internals;
using Game_Engine.Engine.Services.GameNodes.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Engine.Services.GameNodes.NodeModules
{
    class SceneModule : NodeModule
    {
        List<SceneBase> _Scenes = new List<SceneBase>();
        GameObjectModule _GameObjectModule;
        public override void Init()
        {
            base.Init();
            initScenes();
            Rendering = true;
        }

        public override RenderBuf GetAtomRenders()
        {
            if (_GameObjectModule == null)
                _GameObjectModule = _GameNode.GetModule<GameObjectModule>();
            return _GameObjectModule.getGameObjectsRenderer();
        }

        private void initScenes()
        {
            var serviceSubclasses =
                from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                where type.IsSubclassOf(typeof(SceneBase))
                select type;

            Type to = typeof(SceneBase);
            foreach (Type t in serviceSubclasses)
            {
                if (t.IsAssignableFrom(to))
                    return;
                SceneBase nScen = (SceneBase)Activator.CreateInstance(t);
                nScen.Init();
                _Scenes.Add(nScen);
                Logman.Logger.Log(Logman.LogLevel.Info, "Scene loaded: " + t.Name);
            }
        }

        internal override void Update(double delta)
        {
            foreach (SceneBase s in _Scenes)
            {
                s.Update(delta);
            }
        }
    }
}
