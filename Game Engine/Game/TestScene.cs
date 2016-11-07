using Game_Engine.Engine.Injector;
using Game_Engine.Engine.Services.Scripts;
using Game_Engine.Engine.Objects.Internals;
using Game_Engine.Engine.Logman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Engine.Engine.Services.Input;
using Game_Engine.Engine.Objects;
using Game_Engine.Game.Atoms;

namespace Game_Engine
{
    [Injectable(typeof(ScriptService))]
    class TestScene : SceneBase
    {
        ScriptService _ScriptSrvc;
        Input _InputSystem;
        PlayerAtom ply;
        override public void Init()
        {
            this.InjectSrvc();
            _InputSystem = _ScriptSrvc.GetScript<Input>();
            ply = new PlayerAtom();
            
        }

        internal override void Update(double delta)
        {
            if (_InputSystem.isKeyDown(OpenTK.Input.Key.S))
            {
                ply.transform.Position += new OpenTK.Vector2(0, 1);
            } 
            else if(_InputSystem.isKeyDown(OpenTK.Input.Key.D))
            {
                ply.transform.Position += new OpenTK.Vector2(1, 0);
            }
            else if (_InputSystem.isKeyDown(OpenTK.Input.Key.W))
            {
                ply.transform.Position += new OpenTK.Vector2(0, -1);
            }
            else if (_InputSystem.isKeyDown(OpenTK.Input.Key.A))
            {
                ply.transform.Position += new OpenTK.Vector2(-1, 0);
            }
        }
    }
}
