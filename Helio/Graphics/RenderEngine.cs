using Helio.Actors;
using Helio.Core;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Helio.Graphics
{
    public class RenderEngine : GameSystem, IRenderable
    {
        private Dictionary<Entity, IRenderableItem> _sprites;

        public RenderEngine()
        {
            _sprites = new Dictionary<Entity, IRenderableItem>();
        }

        protected void AddRenderableItem(Entity actorId, IRenderableItem sprite)
        {
            _sprites.Add(actorId, sprite);
        }

        protected void RemoveRenderableItem(Entity actorId)
        {
            _sprites.Remove(actorId);
        }

        protected void MoveRenderableItem(Entity actorId, Vector2 newPosition)
        {
            _sprites[actorId].Move(newPosition);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (KeyValuePair<Entity, IRenderableItem> keyValuePair in _sprites)
            {
                keyValuePair.Value.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime, Renderer renderer)
        {
            foreach (KeyValuePair<Entity, IRenderableItem> keyValuePair in _sprites)
            {
                keyValuePair.Value.Draw(gameTime, renderer);
            }
        }
    }
}
