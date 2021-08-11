using Helio.Core;
using Helio.Events;
using Helio.Graphics;
using Microsoft.Xna.Framework;

namespace Helio.Screens
{
    public interface IScreen : ISystem
    {
        bool OnEvent(Event ev);

        void Draw(GameTime gameTime, Renderer renderer);
    }
}
