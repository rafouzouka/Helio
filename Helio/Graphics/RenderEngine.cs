using Helio.Core;
using Helio.Inputs;
using Helio.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace Helio.Graphics
{
    public abstract class RenderEngine : IScreen
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

        protected Dictionary<Entity, IRenderableItem> GetRenderableItems()
        {
            return _sprites;
        }

        protected void MoveRenderableItem(Entity actorId, Vector2 newPosition)
        {
            _sprites[actorId].Move(newPosition);
        }

        public void Update(GameTime gameTime)
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

        public virtual void Init()
        {
        }

        public virtual void LoadContent(ContentManager contentManager)
        {
        }

        public virtual void Start()
        {
        }

        public virtual bool OnInput(InputEvent ev)
        {
            return true;
        }
    }
}
