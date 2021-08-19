using Helio.Core;
using Helio.Graphics;
using Helio.Inputs;
using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

namespace Helio.UI
{
    public class TextButton : UIElement
    {
        private Action _onPressed;
        private Color _backgroundColor;
        private Vector2 _size;
        private Vector2 _position;
        private Rectangle _rect;

        public TextButton(Color backgroundColor, Action onPressed)
        {
            _backgroundColor = backgroundColor;
            _onPressed = onPressed;

            _size = new Vector2(150f, 50f);
            _rect = new Rectangle();
        }

        public Vector2 SetConstraints(Constraints constraints)
        {
            _size.X = Utils.Clamp(_size.X, constraints.minWidth, constraints.maxWidth);
            _size.Y = Utils.Clamp(_size.Y, constraints.minHeight, constraints.maxHeight);

            return _size;
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;
            _rect.Location = _position.ToPoint();
            _rect.Size = _size.ToPoint();
        }

        public void Draw(GameTime gameTime, Renderer renderer)
        {
            renderer.DrawRectFill(_rect, _backgroundColor);
        }

        public bool OnInput(InputEvent input)
        {
            if (input is MouseLeftButtonPressed mouse)
            {
                if (_rect.Contains(mouse.position) == true)
                {
                    Debug.WriteLine($"left pressed in the rect button");
                }
            }

            return true;
        }
    }
}
