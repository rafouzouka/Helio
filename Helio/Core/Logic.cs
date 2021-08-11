using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace Helio.Core
{
    public abstract class Logic
    {
        protected List<ISystem> _systems = new List<ISystem>();

        public virtual void Init()
        {
            foreach (ISystem system in _systems)
            {
                system.Init();
            }
        }

        public virtual void LoadContent(ContentManager contentManager)
        {
            foreach (ISystem system in _systems)
            {
                system.LoadContent(contentManager);
            }
        }

        public virtual void Start()
        {
            foreach (ISystem system in _systems)
            {
                system.Start();
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (ISystem system in _systems)
            {
                system.Update(gameTime);
            }
        }
    }
}
