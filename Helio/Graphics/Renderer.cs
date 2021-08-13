using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helio.Graphics
{
    public class Renderer
    {
        private SpriteBatch _spriteBatch;
        private GraphicsDevice _graphicsDevice;

        public Renderer(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            _spriteBatch = spriteBatch;
            _graphicsDevice = graphicsDevice;
        }

        public void Begin()
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullNone);
        }

        public void End()
        {
            _spriteBatch.End();
        }

        public void Draw(Texture2D texture, Rectangle dest, Rectangle? src)
        {
            _spriteBatch.Draw(texture, dest, src, Color.White);
        }

        public void DrawText(SpriteFont spriteFont, string text, Vector2 position, Color color)
        {
            _spriteBatch.DrawString(spriteFont, text, position, color);
        }

        public void DrawText(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effect, float layerDepth)
        {
            _spriteBatch.DrawString(spriteFont, text, position, color, rotation, origin, scale, effect, layerDepth);
        }
    }
}
