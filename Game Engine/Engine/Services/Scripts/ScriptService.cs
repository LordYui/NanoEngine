using Game_Engine.Engine.Scripts;
using Game_Engine.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Engine.Engine.Logman;

namespace Game_Engine.Engine.Services.Scripts
{
    class ScriptService : Service
    {
        List<ScriptBase> _ScriptList;
        internal override void Init()
        {
            base.Init();
            _ScriptList = new List<ScriptBase>();
            initScripts();
        }

        private void initScripts()
        {
            var serviceSubclasses =
                from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                where type.IsSubclassOf(typeof(ScriptBase))
                select type;

            foreach (Type t in serviceSubclasses)
            {
                ScriptBase newScript = (ScriptBase)Activator.CreateInstance(t);
                newScript.Start();
                _ScriptList.Add(newScript);

                Logger.Log(LogLevel.Info, "Loaded Script: " + t.Name);
            }
        }

        internal override void UpdateService(double delta)
        {
            foreach(ScriptBase s in _ScriptList)
            {
                s.Update(delta);
            }
        }
    }
}
