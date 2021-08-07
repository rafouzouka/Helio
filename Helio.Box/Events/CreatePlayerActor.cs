using Helio.Actors;
using Helio.Events;
using Microsoft.Xna.Framework;

namespace Helio.Box.Events
{
    public class CreatePlayerActor : Event
    {
        
        public ActorId actorId;
        public Vector3 position;

        public CreatePlayerActor(ActorId id, Vector3 position)
        {
            actorId = id;
            this.position = position;
        }
    }
}
