using Game_Engine.Core;
using Game_Engine.Engine.Logman;
using SunshineConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Engine.Services.Render
{
    class Window
    {
        public ConsoleWindow _Win { get; private set; }
        public Window()
        {
            Init();
        }

        void Init()
        {
            _Win = new ConsoleWindow(40, 40, "Test");
            Logger.Log(Logman.LogLevel.Info, "Window created");
        }
        public void Update(double delta)
        {
            _Win.Title = "FPS:" + (1 / delta);
            _Win.WindowUpdate();
        }
    }
}
