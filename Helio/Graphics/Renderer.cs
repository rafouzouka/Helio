using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helio.Graphics
{
    public class Renderer
    {
        private SpriteBatch _spriteBatch;

        public Renderer(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }

        public void Begin()
        {
            _spriteBatch.Begin();
        }

        public void Draw(Texture2D texture, Rectangle dest, Rectangle? src)
        {
            _spriteBatch.Draw(texture, dest, src, Color.White);
        }

        public void End()
        {
            _spriteBatch.End();
        }
    }
}
