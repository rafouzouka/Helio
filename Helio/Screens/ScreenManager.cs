using Helio.Events;
using Helio.Graphics;
using Helio.Inputs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Screens
{
    public class ScreenManager
    {
        private List<IScreen> _screens;

        public ScreenManager()
        {
            _screens = new List<IScreen>();
        }

        public void AddScreen(IScreen screen)
        {
            _screens.Add(screen);
        }

        public void RemoveScreen(IScreen screen)
        {
            _screens.Remove(screen);
        }

        public void OnInput(InputEvent input)
        {
            foreach (IScreen screen in _screens)
            {
                if (screen.OnInput(input) == false)
                {
                    break;
                }
            }
        }

        public void Init()
        {
            foreach (IScreen screen in _screens)
            {
                screen.Init();
            }
        }

        public void LoadContent(ContentManager contentManager)
        {
            foreach (IScreen screen in _screens)
            {
                screen.LoadContent(contentManager);
            }
        }

        public void Start()
        {
            foreach (IScreen screen in _screens)
            {
                screen.Start();
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (IScreen screen in _screens)
            {
                screen.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime, Renderer renderer)
        {
            foreach (IScreen screen in _screens)
            {
                screen.Draw(gameTime, renderer);
            }
        }
    }
}
