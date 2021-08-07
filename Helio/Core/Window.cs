using Microsoft.Xna.Framework;

namespace Helio.Core
{
    public class Window
    {
        private GameWindow _gameWindow;
        private GraphicsDeviceManager _graphics;

        public Window(GraphicsDeviceManager graphics, GameWindow gameWindow)
        {
            _gameWindow = gameWindow;
            _graphics = graphics;
        }

        public void Initialize()
        {
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
        }
    }
}
