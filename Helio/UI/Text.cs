using Helio.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helio.UI
{
    public class Text : UIElement
    {
        private SpriteFont _spriteFont;
        private string _text;
        private Color _color;

        public Text(SpriteFont spriteFont, string text, Color color)
        {
            _spriteFont = spriteFont;
            _text = text;
            _color = color;
        }

        public void Draw(GameTime gameTime, Renderer renderer)
        {
            renderer.DrawText(_spriteFont, _text, new Vector2(50, 50), Color.White, 0.0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0.0f); ;
        }
    }
}
