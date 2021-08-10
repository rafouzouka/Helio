using Helio.Actors;
using Helio.Events;
using Microsoft.Xna.Framework;

namespace Helio.Physics
{
    public class ActorPhysicMoved : Event
    {
        public ActorId id;
        public Vector2 newPosition;

        public ActorPhysicMoved(ActorId id, Vector2 newPosition)
        {
            this.id = id;
            this.newPosition = newPosition;
        }
    }
}
