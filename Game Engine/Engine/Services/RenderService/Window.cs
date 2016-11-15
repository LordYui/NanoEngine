using Game_Engine.Core;
using Game_Engine.Engine.Logman;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Engine.Services.Render
{
    class WindowObject
    {
        internal RenderWindow _Win;
        public WindowObject()
        {
            Init();
        }

        void Init()
        {
            
            _Win = new RenderWindow(new VideoMode(800, 600), "Test window");
            Logger.Log(LogLevel.Info, "Window created");
        }

        public void Update(double delta)
        {
            _Win.DispatchEvents();
            _Win.Clear(Color.Black);
            _Win.Display();

        }
    }
}
