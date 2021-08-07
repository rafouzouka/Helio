using Helio.Actors;
using Microsoft.Xna.Framework;

namespace Helio.Components
{
    class DumbComponent : Component
    {
        public int val;

        public DumbComponent(int r)
        {
            val = r;
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
