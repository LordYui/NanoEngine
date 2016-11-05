using Game_Engine.Scripts;
using Game_Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Services.Scripts
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
