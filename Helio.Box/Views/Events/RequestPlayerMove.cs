using Helio.Core;
using Helio.Events;

namespace Helio.Box.Views.Events
{
    public enum PlayerMoveDirection
    {
        Left,
        Right,
        Up,
        Down
    }

    public class RequestPlayerMove : Event
    {
        public Entity id;
        public PlayerMoveDirection direction;
   
        public RequestPlayerMove(Entity id, PlayerMoveDirection direction)
        {
            this.id = id;
            this.direction = direction;
        }
    }
}
