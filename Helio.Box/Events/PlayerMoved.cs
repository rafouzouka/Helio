using Helio.Actors;
using Helio.Events;
using Microsoft.Xna.Framework;

namespace Helio.Box.Events
{
    public class PlayerMoved : Event
    {
        public ActorId playerId;
        public Vector3 newPosition;

        public PlayerMoved(ActorId id, Vector3 newPosition)
        {
            this.playerId = id;
            this.newPosition = newPosition;
        }
    }
}
