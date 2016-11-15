using Game_Engine.Engine.Injector;
using Game_Engine.Engine.Services.ConfigsProvider;

namespace Game_Engine.Engine.Services.AssetsProvider
{
    [Injectable(typeof(ConfigService))]
    class AssetService : Service
    {
        ConfigService _Conf;
        string AssetsPath;
        public override void Init()
        {
            this.InjectSrvc();
            AssetsPath = _Conf.GetConf<string>("AssetsFolder");
            
        }

        internal override void Update(double delta)
        {

        }
    }
}
