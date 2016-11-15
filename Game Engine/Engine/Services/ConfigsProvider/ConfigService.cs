using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Engine.Services.ConfigsProvider
{
    class ConfigService : Service
    {
        internal Dictionary<string, object> Confs;
        public override void Init()
        {
            Confs = new Dictionary<string, object>();
            LoadDebugConfig();
        }

        private void LoadDebugConfig()
        {
            AddConf("AssetsFolder", "Game/Assets/");
        }

        public void AddConf(string s, object o)
        {
            if (!Confs.ContainsKey(s))
                Confs.Add(s, o);
        }

        public void SetConf(string s, object o)
        {
            if (Confs.ContainsKey(s))
                Confs[s] = o;
        }

        public object GetConf(string c)
        {
            if (Confs.ContainsKey(c))
                return Confs[c];
            else
                return null;
        }

        public T GetConf<T>(string c)
        {
            if (Confs.ContainsKey(c))
                return (T)Confs[c];
            else
                return default(T);
        }

        internal override void Update(double delta)
        {

        }
    }
}
