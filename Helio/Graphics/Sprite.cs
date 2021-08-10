using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helio.Graphics
{
    public class Sprite : IRenderableItem
    {
        private Texture2D _texture;
        private Rectangle? _src;
        private Rectangle _dst;

        public Sprite(Texture2D texture, Rectangle dst, Rectangle? src)
        {
            _texture = texture;
            _src = src;
            _dst = dst;
        }

        public void Move(Vector2 newPosition)
        {
            _dst.X = (int)newPosition.X;
            _dst.Y = (int)newPosition.Y;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime, Renderer renderer)
        {
            renderer.Draw(_texture, _dst, _src);
        }
    }
}
