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

        public ILogic gameLogic;
        public List<View> views;
        public Input input;

        public App()
        {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _window = new Window(new GraphicsDeviceManager(this), Window);

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
            _renderer = new Renderer(new SpriteBatch(GraphicsDevice));

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

            // Handling inputs
            input.PollEvents();

            // Normal
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

            _renderer.Begin();

            foreach (View view in views)
            {
                view.Draw(gameTime, _renderer);
            }

            _renderer.End();

            base.Draw(gameTime);
        }
    }
}
