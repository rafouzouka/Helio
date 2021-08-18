using Helio.Core;
using Helio.Events;

namespace Helio.Physics.Events
{
    public class EntityCollided : Event
    {
        public Entity a;
        public Entity b;

        public EntityCollided(Entity a, Entity b)
        {
            this.a = a;
            this.b = b;
        }
    }
}
