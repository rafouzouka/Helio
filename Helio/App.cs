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

        private Logic _gameLogic;
        private HumanView _humanView;

        public List<View> views;
        public Input input;

        public App(string title, int windowWidth, int windowHeight, int targetWidth, int targetHeight, Logic gameLogic, HumanView humanView)
        {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            IsFixedTimeStep = false;

            _window = new Window(title, windowWidth, windowHeight, targetWidth, targetHeight, new GraphicsDeviceManager(this), Window);

            _gameLogic = gameLogic;
            _humanView = humanView;
            views = new List<View>();
            input = new Input();
        }

        sealed protected override void Initialize()
        {
            _window.Initialize();
            
            _gameLogic.Init();
            _humanView.Init();

            foreach (View view in views)
            {
                view.Init();
            }

            base.Initialize();
        }

        sealed protected override void LoadContent()
        {
            SpriteBatch spriteBatch = new SpriteBatch(GraphicsDevice);

            _renderer = new Renderer(spriteBatch, GraphicsDevice);
            _window.LoadContent(spriteBatch);

            _gameLogic.LoadContent(Content);
            _humanView.LoadContent(Content);
            foreach (View view in views)
            {
                view.LoadContent(Content);
            }

            _gameLogic.Start();
            _humanView.Start();
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
            _humanView.OnInputs(input.GetInputs());

            EventManager.Instance.Update();
            _gameLogic.Update(gameTime);
            _humanView.Update(gameTime);
            foreach (View view in views)
            {
                view.Update(gameTime);
            }

            base.Update(gameTime);
        }

        sealed protected override void Draw(GameTime gameTime)
        {
            _window.Set();
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _renderer.Begin();
            _humanView.Draw(gameTime, _renderer);
            _renderer.End();

            _window.Unset();
            _window.Present();

            base.Draw(gameTime);
        }
    }
}
