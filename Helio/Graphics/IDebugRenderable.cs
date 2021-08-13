using Microsoft.Xna.Framework;

namespace Helio.Graphics
{
    public interface IDebugRenderable
    {
        void DebugDraw(GameTime gameTime, Renderer renderer);
    }
}
