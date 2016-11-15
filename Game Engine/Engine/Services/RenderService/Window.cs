using Game_Engine.Core;
using Game_Engine.Engine.Logman;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Engine.Engine.Services.Render
{
    class Window
    {
        
        public Window()
        {
            Init();
        }

        void Init()
        {
            
            Logger.Log(LogLevel.Info, "Window created");
        }

        public void Update(double delta)
        {
            
        }

        private void ClearScreen()
        {
            
        }
    }
}
