using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Inputs
{
    public class MouseMoved : InputEvent
    {
        public Point previousPosition;
        public Point currentPosition;

        public MouseMoved(Point previousPosition, Point currentPosition)
        {
            this.previousPosition = previousPosition;
            this.currentPosition = currentPosition;
        }
    }

    public class MouseLeftButtonReleased : InputEvent
    {
        public Point position;

        public MouseLeftButtonReleased(Point position)
        {
            this.position = position;
        }
    }

    public class MouseRightButtonReleased : InputEvent
    {
        public Point position;

        public MouseRightButtonReleased(Point position)
        {
            this.position = position;
        }
    }

    public class MouseMiddleButtonReleased : InputEvent
    {
        public Point position;

        public MouseMiddleButtonReleased(Point position)
        {
            this.position = position;
        }
    }

    public class MouseLeftButtonPressed : InputEvent
    {
        public Point position;

        public MouseLeftButtonPressed(Point position)
        {
            this.position = position;
        }
    }

    public class MouseRightButtonPressed : InputEvent
    {
        public Point position;

        public MouseRightButtonPressed(Point position)
        {
            this.position = position;
        }
    }

    public class MouseMiddleButtonPressed : InputEvent
    {
        public Point position;

        public MouseMiddleButtonPressed(Point position)
        {
            this.position = position;
        }
    }

    public class MouseLeftButtonPress : InputEvent
    {
        public Point position;

        public MouseLeftButtonPress(Point position)
        {
            this.position = position;
        }
    }

    public class MouseRightButtonPress : InputEvent
    {
        public Point position;

        public MouseRightButtonPress(Point position)
        {
            this.position = position;
        }
    }

    public class MouseMiddleButtonPress : InputEvent
    {
        public Point position;

        public MouseMiddleButtonPress(Point position)
        {
            this.position = position;
        }
    }
}
