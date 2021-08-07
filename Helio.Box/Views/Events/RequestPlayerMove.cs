using Helio.Actors;
using Helio.Events;
using System;
using System.Collections.Generic;
using System.Text;

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
        public ActorId id;
        public PlayerMoveDirection direction;
   
        public RequestPlayerMove(ActorId id, PlayerMoveDirection direction)
        {
            this.id = id;
            this.direction = direction;
        }
    }
}
