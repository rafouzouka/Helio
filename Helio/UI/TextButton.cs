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

        public TextButton(Color backgroundColor, Action onPressed)
        {
            _backgroundColor = backgroundColor;
            _onPressed = onPressed;

            _size = new Vector2(150f, 50f);
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
        }

        public void Draw(GameTime gameTime, Renderer renderer)
        {
            renderer.DrawRectFill(new Rectangle(_position.ToPoint(), _size.ToPoint()), _backgroundColor);
        }

        public bool OnInput(InputEvent input)
        {
            if (input is KeyboardReleased released)
            {
                Debug.WriteLine("FROM TEXT BUTTON DETECTION OF KEYBOARD PRESSED");
                _onPressed();
                return false;
            }
            return true;
        }
    }
}
