using Microsoft.Xna.Framework;

namespace Helio.Graphics
{
    public interface IRenderableItem : IRenderable
    {
        void Update(GameTime gameTime);
    }
}
