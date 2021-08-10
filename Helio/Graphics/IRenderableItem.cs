using Microsoft.Xna.Framework;

namespace Helio.Graphics
{
    public interface IRenderableItem
    {
        void Move(Vector2 newPosition);

        void Update(GameTime gameTime);

        void Draw(GameTime gameTime, Renderer renderer);
    }
}
