using Helio.Core;
using Helio.Events;
using Microsoft.Xna.Framework;

namespace Helio.Physics
{
    public class EntityPhysicMoved : Event
    {
        public Entity id;
        public Rectangle collider;

        public EntityPhysicMoved(Entity id, Rectangle collider)
        {
            this.id = id;
            this.collider = collider;
        }
    }
}
