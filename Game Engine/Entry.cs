using Game_Engine.Core;
using Game_Engine.Engine.Services.Render.Configs;

namespace Game_Engine
{
    class Entry
    {
        static void Main()
        {
            MainTick mTick = new MainTick(typeof(SFMLRenderContract));
        }
    }
}
