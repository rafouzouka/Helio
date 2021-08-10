using Microsoft.Xna.Framework;

namespace Helio.Core
{
    public class Window
    {
        private GameWindow _gameWindow;
        private GraphicsDeviceManager _graphics;
        private string _title;
        private int _width;
        private int _height;

        public Window(string title, int width, int height, GraphicsDeviceManager graphics, GameWindow gameWindow)
        {
            _title = title;
            _width = width;
            _height = height;
            _gameWindow = gameWindow;
            _graphics = graphics;
        }

        public void Initialize()
        {
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = _width;
            _graphics.PreferredBackBufferHeight = _height;
            _gameWindow.AllowUserResizing = true;
            _gameWindow.Title = _title;
            _graphics.ApplyChanges();
        }
    }
}
