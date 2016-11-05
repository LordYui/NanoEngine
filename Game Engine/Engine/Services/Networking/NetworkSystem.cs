using Game_Engine.Injector;
using Game_Engine.Services.Networking.Client;
using Game_Engine.Services.RenderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Services.Networking
{
    [Injectable(typeof(RenderService.RenderService))]
    class NetworkSystem : Service
    {
        NetworkClient ply;
        RenderService.RenderService renderServ;
        internal override void Init()
        {
            base.Init();
            this.Inject();
            ply = new NetworkClient();
        }

        internal override void UpdateService(double delta)
        {
            throw new NotImplementedException();
        }
    }
}
