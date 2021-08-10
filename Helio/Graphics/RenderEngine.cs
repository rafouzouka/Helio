using Helio.Actors;
using Helio.Core;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Helio.Graphics
{
    public class RenderEngine : GameSystem, IRenderable
    {
        private Dictionary<ActorId, IRenderableItem> _sprites;

        public RenderEngine()
        {
            _sprites = new Dictionary<ActorId, IRenderableItem>();
        }

        protected void AddRenderableItem(ActorId actorId, IRenderableItem sprite)
        {
            _sprites.Add(actorId, sprite);
        }

        protected void RemoveRenderableItem(ActorId actorId)
        {
            _sprites.Remove(actorId);
        }

        protected void MoveRenderableItem(ActorId actorId, Vector2 newPosition)
        {
            _sprites[actorId].Move(newPosition);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (KeyValuePair<ActorId, IRenderableItem> keyValuePair in _sprites)
            {
                keyValuePair.Value.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime, Renderer renderer)
        {
            foreach (KeyValuePair<ActorId, IRenderableItem> keyValuePair in _sprites)
            {
                keyValuePair.Value.Draw(gameTime, renderer);
            }
        }
    }
}
