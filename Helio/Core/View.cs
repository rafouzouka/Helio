using Helio.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace Helio.Core
{
    public abstract class View
    {
        protected List<GameSystem> _systems = new List<GameSystem>();

        public virtual void Init()
        {
            foreach (GameSystem system in _systems)
            {
                system.Init();
            }
        }

        public virtual void LoadContent(ContentManager contentManager)
        {
            foreach (GameSystem system in _systems)
            {
                system.LoadContent(contentManager);
            }
        }

        public virtual void Start()
        {
            foreach (GameSystem system in _systems)
            {
                system.Start();
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (GameSystem system in _systems)
            {
                system.Update(gameTime);
            }
        }

        public virtual void Draw(GameTime gameTime, Renderer renderer)
        {
            foreach (GameSystem system in _systems)
            {
                if (system is IRenderable renderable)
                {
                    renderable.Draw(gameTime, renderer);
                }
            }
        }
    }
}
