using Game_Engine.Core;
using Game_Engine.Engine.Logman;
using OpenTK.Graphics;
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
            Logger.Log(LogLevel.Info, "Window created");
        }
        public void Update(double delta)
        {
            _Win.Title = "FPS:" + (1 / delta);
            _Win.WindowUpdate();
            ClearScreen();
        }

        private void ClearScreen()
        {
            for(int x = 0; x < _Win.Cols; x++)
            {
                for(int y = 0; y < _Win.Rows; y++)
                {
                    _Win.Write(y, x, ' ', Color4.Black);
                }
            }
        }
    }
}
