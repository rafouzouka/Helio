using Helio.Graphics;
using Microsoft.Xna.Framework;

namespace Helio.UI
{
    public interface UIElement : IRenderable
    {
        Vector2 SetConstraints(Constraints constraints);

        void SetPosition(Vector2 position);
    }
}
