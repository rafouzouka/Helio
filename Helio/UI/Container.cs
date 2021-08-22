using Helio.Core;
using Helio.Graphics;
using Helio.Inputs;
using Microsoft.Xna.Framework;

namespace Helio.UI
{
    public class Container : UIElement
    {
        Color _color;
        private Vector2 _size;
        private Vector2 _position;
        private UIElement _child;

        public Container(Color color, float width = float.PositiveInfinity, float height = float.PositiveInfinity, UIElement child = null)
        {
            _color = color;

            _size.X = width;
            _size.Y = height;

            _child = child;
        }

        public Vector2 SetConstraints(Constraints constraints)
        {
            constraints.minHeight = 0f;
            constraints.minWidth = 0f;


            if (_child != null)
            {
                Vector2 childSize = _child.SetConstraints(constraints);
                _size.X = Utils.Max(_size.X, childSize.X);
                _size.Y = Utils.Max(_size.Y, childSize.Y);
            }

            _size.X = Utils.Clamp(_size.X, constraints.minWidth, constraints.maxWidth);
            _size.Y = Utils.Clamp(_size.Y, constraints.minHeight, constraints.maxHeight);

            return _size;
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;

            _child?.SetPosition(_position);
        }

        public void Draw(GameTime gameTime, Renderer renderer)
        {
            renderer.DrawRectFill(new Rectangle(_position.ToPoint(), _size.ToPoint()), _color);
            _child?.Draw(gameTime, renderer);

            //renderer.DrawRect(new Rectangle(_position.ToPoint(), _size.ToPoint()), _color);
        }

        public bool OnInput(InputEvent input)
        {
            if (_child != null)
            {
                return _child.OnInput(input);
            }
            return true;
        }
    }
}
