using Helio.Core;
using Helio.Events;

namespace Helio.Box.Views.Events
{

    public enum PlayerMovementType
    {
        Jump,
        WalkRight,
        WalkLeft,
    }

    public class RequestPlayerMove : Event
    {
        public Entity entity;
        public PlayerMovementType movementType;

        public RequestPlayerMove(Entity entity, PlayerMovementType movementType)
        {
            this.entity = entity;
            this.movementType = movementType;
        }
    }
}
