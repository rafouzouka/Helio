using Helio.Core;
using Helio.Graphics;
using Helio.Inputs;
using Microsoft.Xna.Framework;

namespace Helio.Screens
{
    public interface IScreen : ISystem
    {
        bool OnInput(InputEvent input);

        void Draw(GameTime gameTime, Renderer renderer);
    }
}
