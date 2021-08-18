using Helio.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace Helio.UI
{
    public class Text : UIElement
    {
        private SpriteFont _spriteFont;
        private string _text;
        private Color _color;

        private Constraints _constraints;
        private Vector2 _position;

        public Text(SpriteFont spriteFont, string text, Color color)
        {
            _spriteFont = spriteFont;
            _text = text;
            _color = color;
        }

        public Vector2 SetConstraints(Constraints constraints)
        {
            Debug.WriteLine(_spriteFont.MeasureString("Salut les gens"));

            _constraints = constraints;

            return Vector2.Zero;
        }

        public void SetPosition(Vector2 position)
        {
            _position = position;
        }

        public void Draw(GameTime gameTime, Renderer renderer)
        {
            renderer.DrawText(_spriteFont, _text, _position, _color, 0.0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0.0f); ;
        }
    }
}
