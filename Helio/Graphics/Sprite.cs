using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helio.Graphics
{
    public class Sprite : IRenderableItem
    {
        private Texture2D _texture;
        private Rectangle _spriteRect;

        public Sprite(Texture2D texture, Rectangle spriteRect)
        {
            _texture = texture;
            _spriteRect = spriteRect;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime, Renderer renderer)
        {
            renderer.Draw(_texture, _spriteRect, null);
        }
    }
}
