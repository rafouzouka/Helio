using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace Helio.Core
{
    public abstract class Logic
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
    }
}
