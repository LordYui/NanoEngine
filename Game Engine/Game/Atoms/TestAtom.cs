using Game_Engine.Engine.Objects;
using Game_Engine.Engine.Services.Render.Configs;
using SFML.Graphics;

namespace Game_Engine.Game.Atoms
{
    class TestAtom : Atom
    {
        public override void Init()
        {
            CircleShape c = new CircleShape(5);
            Render = new SFMLRenderContract(new CircleShape(5) { FillColor = Color.White });
        }

        internal override void Update(double delta)
        {
            
        }
    }
}
