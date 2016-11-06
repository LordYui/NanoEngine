using Game_Engine.Engine.Objects.Internals;
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
        public override void Start()
        {
            base.Start();
            initScenes();
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
                nScen.Start();
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
