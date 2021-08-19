using Helio.Graphics;
using Helio.Inputs;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Helio.UI
{
    public class Center : UIElement
    {
        private UIElement _child;

        private Vector2 _position;
        private Vector2 _size;
        private Vector2 _childSize;

        public Center(UIElement child = null)
        {
            _size = Vector2.Zero;
            _child = child;
        }

        public Vector2 SetConstraints(Constraints constraints)
        {
            _size.X = constraints.maxWidth;
            _size.Y = constraints.maxHeight;

            constraints.minHeight = 0f;
            constraints.minWidth = 0f;

            _childSize = _child.SetConstraints(constraints);

            return new Vector2(constraints.maxWidth, constraints.maxHeight);
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;

            _child.SetPosition(
                new Vector2(
                    ((_size.X - _childSize.X) / 2) + _position.X,
                    ((_size.Y - _childSize.Y) / 2) + _position.Y
                )
            );
        }

        public void Draw(GameTime gameTime, Renderer renderer)
        {
            _child.Draw(gameTime, renderer);
        }

        public bool OnInput(InputEvent input)
        {
            return _child.OnInput(input);
        }
    }
}
