using Microsoft.Xna.Framework;

namespace Helio.Actors
{
    public struct ComponentId
    {
        public string id;
    }

    public abstract class Component
    {
        protected Actor owner;

        public void SetOwner(Actor owner)
        {
            this.owner = owner;
        }

        public virtual void Start() { }

        public abstract void Update(GameTime gameTime);
    }
}
