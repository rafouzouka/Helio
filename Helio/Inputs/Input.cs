using Helio.Events;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Inputs
{
    public class Input
    {
        private KeyboardState _previouskeyboardState;
        private KeyboardState _currentkeyboardState;
        private Keys[] _previousKeysPressed;
        private Keys[] _currentKeysPressed;

        public Input()
        {
            _currentkeyboardState = Keyboard.GetState();
            _currentKeysPressed = _currentkeyboardState.GetPressedKeys();
        }

        public void PollEvents()
        {
            _previouskeyboardState = _currentkeyboardState;
            _previousKeysPressed = _currentKeysPressed;

            _currentkeyboardState = Keyboard.GetState();
            _currentKeysPressed = _currentkeyboardState.GetPressedKeys();

            foreach (Keys key in _currentKeysPressed)
            {
                if (_previouskeyboardState[key] == KeyState.Up)
                {
                    EventManager.Instance.QueueEvent(new KeyboardPressed((KeyboardKeys)key));
                }
                else
                {
                    EventManager.Instance.QueueEvent(new KeyboardPress((KeyboardKeys)key));
                }
            }

            foreach (Keys key in _previousKeysPressed)
            {
                if (_currentkeyboardState[key] == KeyState.Up)
                {
                    EventManager.Instance.QueueEvent(new KeyboardReleased((KeyboardKeys)key));
                }
            }
        }
    }
}

