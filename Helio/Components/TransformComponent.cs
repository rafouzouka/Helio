using Helio.Actors;
using Microsoft.Xna.Framework;

namespace Helio.Components
{
    public class TransformComponent : Component
    {
        public Vector3 position = new Vector3(0, 0, 0);
        public Vector3 rotation = new Vector3(0, 0, 0);
        public Vector3 scale = new Vector3(0, 0, 0);

        public override void Update(GameTime gameTime)
        {
        }
    }
}
