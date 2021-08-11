﻿using Helio.Events;
using Helio.Graphics;
using Helio.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Core
{
    public class HumanView : View
    {
        private ScreenManager _screenManager;

        public HumanView()
        {
            _screenManager = new ScreenManager();
        }

        public void AddScreen(IScreen screen)
        {
            _screenManager.AddScreen(screen);
        }

        public void RemoveScreen(IScreen screen)
        {
            _screenManager.RemoveScreen(screen);
        }

        public override void Init()
        {
            _screenManager.Init();
        }

        public override void LoadContent(ContentManager contentManager)
        {
            _screenManager.LoadContent(contentManager);
        }

        public override void Start()
        {
            _screenManager.Start();
        }

        public void OnInputs(List<Event> events)
        {
            foreach (Event ev in events)
            {
                _screenManager.OnEvent(ev);
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _screenManager.Update(gameTime);
        }

        public void Draw(GameTime gameTime, Renderer renderer)
        {
            _screenManager.Draw(gameTime, renderer);
        }
    }
}