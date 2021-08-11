using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Helio.Core;
using Helio.Events;
using System.Collections.Generic;
using Helio.Inputs;
using Helio.Graphics;

namespace Helio
{
    public abstract class App : Game
    {
        private Renderer _renderer;
        private Window _window;

        public Logic gameLogic;
        public List<View> views;
        public Input input;

        public App(string title, int windowWidth, int windowHeight, int targetWidth, int targetHeight)
        {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _window = new Window(title, windowWidth, windowHeight, targetWidth, targetHeight, new GraphicsDeviceManager(this), Window);

            gameLogic = null;
            views = new List<View>();
            input = new Input();
        }

        sealed protected override void Initialize()
        {
            _window.Initialize();
            Init();
            
            gameLogic.Init();

            foreach (View view in views)
            {
                view.Init();
            }

            base.Initialize();
        }

        protected virtual void Init() { }

        sealed protected override void LoadContent()
        {
            SpriteBatch spriteBatch = new SpriteBatch(GraphicsDevice);
            _renderer = new Renderer(spriteBatch);
            _window.LoadContent(spriteBatch);

            gameLogic.LoadContent(Content);
            foreach (View view in views)
            {
                view.LoadContent(Content);
            }

            gameLogic.Start();
            foreach (View view in views)
            {
                view.Start();
            }
        }

        sealed protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            input.PollEvents();

            EventManager.Instance.Update();
            gameLogic.Update(gameTime);
            foreach (View view in views)
            {
                view.Update(gameTime);
            }

            base.Update(gameTime);
        }

        sealed protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _window.Set();

            _renderer.Begin();
            foreach (View view in views)
            {
                view.Draw(gameTime, _renderer);
            }
            _renderer.End();

            _window.Unset();
            _window.Present();

            base.Draw(gameTime);
        }
    }
}
