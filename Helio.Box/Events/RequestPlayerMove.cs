using Helio.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Box.Events
{
    public enum PlayerMoveDirection
    {
        Left,
        Right,
        Up,
        Down,
    }

    public class RequestPlayerMove : Event
    {
        public PlayerMoveDirection direction;

        public RequestPlayerMove(PlayerMoveDirection direction)
        {
            this.direction = direction;
        }
    }
}
