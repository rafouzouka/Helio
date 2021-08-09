using Helio.Actors;
using Helio.Core;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Helio.Graphics
{
    public class RenderEngine : GameSystem, IRenderable
    {
        private Dictionary<ActorId, IRenderableItem> _renderableItems;

        public RenderEngine()
        {
            _renderableItems = new Dictionary<ActorId, IRenderableItem>();
        }

        protected void AddRenderableItem(ActorId actorId, IRenderableItem renderable)
        {
            _renderableItems.Add(actorId, renderable);
        }

        protected void RemoveRenderableItem(ActorId actorId)
        {
            _renderableItems.Remove(actorId);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (KeyValuePair<ActorId, IRenderableItem> keyValuePair in _renderableItems)
            {
                keyValuePair.Value.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime, Renderer renderer)
        {
            foreach (KeyValuePair<ActorId, IRenderableItem> keyValuePair in _renderableItems)
            {
                keyValuePair.Value.Draw(gameTime, renderer);
            }
        }
    }
}
