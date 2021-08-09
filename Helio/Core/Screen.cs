using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Helio.Core
{
    public class Screen
    {
        private RenderTarget2D _target;
        private GraphicsDevice _graphicsDevice;
        private SpriteBatch _spriteBatch;
        private int _width;
        private int _height;

        public Screen(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, int width, int height)
        {
            _width = width;
            _height = height;
            _spriteBatch = spriteBatch;
            _graphicsDevice = graphicsDevice;
            _target = new RenderTarget2D(graphicsDevice, width, height);
        }

        public void Set()
        {
            _graphicsDevice.SetRenderTarget(_target);
        }

        public void Unset()
        {
            _graphicsDevice.SetRenderTarget(null);
        }

        public void Present()
        {
            Rectangle destRect = CalculateDestRect();

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            _spriteBatch.Draw(_target, destRect, Color.White);
            _spriteBatch.End();
        }

        private Rectangle CalculateDestRect()
        {
            Rectangle backBufferBounds = _graphicsDevice.PresentationParameters.Bounds;
            double backBufferAspectRatio = (double)backBufferBounds.Width / backBufferBounds.Height;
            double screenAspectRatio = (double)_width/ _height;

            Rectangle dest = new Rectangle();
            dest.X = 0;
            dest.Y = 0;
            dest.Width = backBufferBounds.Width;
            dest.Height = backBufferBounds.Height;

            if (backBufferAspectRatio > screenAspectRatio)
            {
                dest.Width = dest.Height * (int)screenAspectRatio;
                dest.X = (backBufferBounds.Width - dest.Width) / 2;
            }
            else if (backBufferAspectRatio < screenAspectRatio)
            {
                dest.Height = dest.Width / (int)screenAspectRatio;
                dest.Y = (backBufferBounds.Height - dest.Height) / 2;
            }

            return dest;
        }
    }
}
