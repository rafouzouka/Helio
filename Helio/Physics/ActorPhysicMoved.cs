using Helio.Actors;
using Helio.Core;
using Helio.Events;
using Microsoft.Xna.Framework;

namespace Helio.Physics
{
    public class EntityPhysicMoved : Event
    {
        public Entity id;
        public Vector2 newPosition;

        public EntityPhysicMoved(Entity id, Vector2 newPosition)
        {
            this.id = id;
            this.newPosition = newPosition;
        }
    }
}
