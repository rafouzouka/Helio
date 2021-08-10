using Microsoft.Xna.Framework;

namespace Helio.Actors
{
    public struct ComponentId
    {
        public string id;
    }

    public abstract class Component
    {
        protected PActor owner;

        public void SetOwner(PActor owner)
        {
            this.owner = owner;
        }

        public virtual void Start() { }

        public abstract void Update(GameTime gameTime);
    }
}
