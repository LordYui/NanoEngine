using OpenTK.Input;
using Game_Engine.Engine.Services.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunshineConsole;
using Game_Engine.Engine.Injector;

namespace Game_Engine.Engine.Services.Input
{
    class InputSystem : Service
    {
        RenderService _RenderSrvc;
        ConsoleWindow _Win;
        List<Key> pressedKey;

        public override void Init()
        {
            //base.Init();
            pressedKey = new List<Key>();
            _RenderSrvc = SrvcRoot.GetService<RenderService>();

            _Win = _RenderSrvc._Window._Win;

            _Win.KeyDown += _Win_KeyDown;
            _Win.KeyUp += _Win_KeyUp;
        }

        private void _Win_KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            if (pressedKey.Contains(e.Key))
                pressedKey.Remove(e.Key);
        }

        private void _Win_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            pressedKey.Add(e.Key);
        }

        internal override void Update(double delta)
        {
            
            return;
        }

        public bool isKeyDown(Key k)
        {
            return _Win.KeyIsDown(k);
        }

        public bool isKeyPressed(Key k)
        {
            return pressedKey.Contains(k);
        }
    }
}
