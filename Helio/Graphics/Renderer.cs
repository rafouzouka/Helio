using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Helio.Graphics
{
    public class Renderer
    {
        private SpriteBatch _spriteBatch;
        private GraphicsDevice _graphicsDevice;
        private Texture2D _baseTexture;

        public Renderer(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
        {
            _spriteBatch = spriteBatch;
            _graphicsDevice = graphicsDevice;
        }

        private Texture2D GetBaseTexture()
        {
            if (_baseTexture == null)
            {
                _baseTexture = new Texture2D(_graphicsDevice, 1, 1, false, SurfaceFormat.Color);
                _baseTexture.SetData(new[] { Color.White });
            }

            return _baseTexture;
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

        public void DrawRectFill(Rectangle rectangle, Color color)
        {
            _spriteBatch.Draw(GetBaseTexture(), rectangle, color);
        }

        public void DrawRect(Rectangle rectangle, Color color)
        {
            DrawLine(new Vector2(rectangle.X, rectangle.Y), new Vector2(rectangle.X + rectangle.Width, rectangle.Y), color);
            DrawLine(new Vector2(rectangle.X + rectangle.Width, rectangle.Y), new Vector2(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), color);
            DrawLine(new Vector2(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height), new Vector2(rectangle.X, rectangle.Y + rectangle.Height), color);
            DrawLine(new Vector2(rectangle.X, rectangle.Y + rectangle.Height), new Vector2(rectangle.X, rectangle.Y), color);
        }

        public void DrawLine(Vector2 a, Vector2 b, Color color, float thickness = 1.0f)
        {
            float length = Vector2.Distance(a, b);
            float angle = (float)Math.Atan2(b.Y - a.Y, b.X - a.X);
            DrawLine(a, length, angle, color, thickness);
        }

        public void DrawLine(Vector2 point, float length, float angle, Color color, float thickness = 1f)
        {
            var scale = new Vector2(length, thickness);
            _spriteBatch.Draw(GetBaseTexture(), point, null, color, angle, Vector2.Zero, scale, SpriteEffects.None, 0);
        }
    }
}
