using Helio.Box.Events;
using Helio.Core;
using Helio.Events;
using Helio.Inputs;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Helio.Box.Systems
{
    public class PlayerControlSystem : GameSystem
    {
        public override void Init()
        {
            EventManager.Instance.AddListener(OnKeyPressed, typeof(KeyboardPressed));
            EventManager.Instance.AddListener(OnKeyPress, typeof(KeyboardPress));
            EventManager.Instance.AddListener(OnKeyReleased, typeof(KeyboardReleased));
        }

        public void OnKeyPress(Event e)
        {
            KeyboardPress ev = (KeyboardPress)e;

            switch (ev.key)
            {
                case KeyboardKeys.Q:
                    EventManager.Instance.QueueEvent(new RequestPlayerMove(PlayerMoveDirection.Left));
                    break;

                case KeyboardKeys.D:
                    EventManager.Instance.QueueEvent(new RequestPlayerMove(PlayerMoveDirection.Right));
                    break;

                case KeyboardKeys.Z:
                    EventManager.Instance.QueueEvent(new RequestPlayerMove(PlayerMoveDirection.Up));
                    break;

                case KeyboardKeys.S:
                    EventManager.Instance.QueueEvent(new RequestPlayerMove(PlayerMoveDirection.Down));
                    break;

                default:
                    break;
            }
        }

        public void OnKeyPressed(Event e)
        {
            KeyboardPressed ev = (KeyboardPressed)e;
        }

        public void OnKeyReleased(Event e)
        {
            KeyboardReleased ev = (KeyboardReleased)e;
        }
    }
}
