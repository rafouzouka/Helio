using Helio.Actors;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace Helio.Core
{
    public abstract class GameSystem
    {
        protected Dictionary<ActorId, Actor> _actors;

        public GameSystem()
        {
            _actors = new Dictionary<ActorId, Actor>();
        }

        public virtual void Init() { }

        public virtual void LoadContent(ContentManager contentManager) { }

        public virtual void Start() { }

        public virtual void Update(GameTime gameTime)
        {
            foreach (KeyValuePair<ActorId, Actor> actor in _actors)
            {
                actor.Value.Update(gameTime);
            }
        }
    }
}
