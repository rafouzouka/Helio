using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Helio.Core
{
    public class Window
    {
        private RenderTarget2D _target;

        private SpriteBatch _spriteBatch;
        private GameWindow _gameWindow;
        private GraphicsDeviceManager _graphics;
        private string _title;

        private int _windowWidth;
        private int _windowHeight;
        
        private int _targetWidth;
        private int _targetHeight;


        public Window(string title, int windowWidth, int windowHeight, int targetWidth, int targetHeight, GraphicsDeviceManager graphics, GameWindow gameWindow)
        {
            _title = title;

            _windowWidth = windowWidth;
            _windowHeight = windowHeight;

            _targetWidth = targetWidth;
            _targetHeight = targetHeight;

            _gameWindow = gameWindow;
            _graphics = graphics;
            _spriteBatch = null;
            _target = null;
        }

        public void Initialize()
        {
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = _windowWidth;
            _graphics.PreferredBackBufferHeight = _windowHeight;
            _gameWindow.AllowUserResizing = true;
            _gameWindow.Title = _title;
            _graphics.ApplyChanges();
        }

        public void LoadContent(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            _target = new RenderTarget2D(_graphics.GraphicsDevice, _targetWidth, _targetHeight);
        }

        public void Set()
        {
            _graphics.GraphicsDevice.SetRenderTarget(_target);
        }

        public void Unset()
        {
            _graphics.GraphicsDevice.SetRenderTarget(null);
        }

        public void Present()
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            _spriteBatch.Draw(_target, _graphics.GraphicsDevice.PresentationParameters.Bounds, Color.White);
            _spriteBatch.End();
        }
    }
}
