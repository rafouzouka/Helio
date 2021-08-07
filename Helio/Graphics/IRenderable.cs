using Helio.Core;
using Microsoft.Xna.Framework;

namespace Helio.Graphics
{
    public interface IRenderable
    {
        void Draw(GameTime gameTime, Renderer renderer);
    }
}
