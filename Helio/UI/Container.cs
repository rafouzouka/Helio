using Helio.Core;
using Helio.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Helio.UI
{
    public class Container : UIElement
    {
        Color _color;
        private Vector2 _size;
        private Vector2 _position;
        private UIElement _child;

        public Container(Color color, float width = 0.0f, float height = 0.0f, UIElement child = null)
        {
            _color = color;

            _size.X = width;
            _size.Y = height;

            _child = child;
        }

        public Vector2 SetConstraints(Constraints constraints)
        {
            Debug.WriteLine($"constraints: {constraints.minWidth} {constraints.maxWidth} {constraints.minHeight} { constraints.maxHeight}");

            _size.X = Utils.Clamp(_size.X, constraints.minWidth, constraints.maxWidth);
            _size.Y = Utils.Clamp(_size.Y, constraints.minHeight, constraints.maxHeight);

            return _size;
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;

            _child.SetPosition(_position);
        }

        public void Draw(GameTime gameTime, Renderer renderer)
        {
            renderer.DrawRectFill(new Rectangle(_position.ToPoint(), _size.ToPoint()), _color);
            _child.Draw(gameTime, renderer);
        }
    }
}
