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

        private List<Event> _events;

        public Input()
        {
            _currentkeyboardState = Keyboard.GetState();
            _currentKeysPressed = _currentkeyboardState.GetPressedKeys();
            _events = new List<Event>();
        }

        public List<Event> GetEvents()
        {
            return _events;
        }

        public void PollEvents()
        {
            _events.Clear();

            _previouskeyboardState = _currentkeyboardState;
            _previousKeysPressed = _currentKeysPressed;

            _currentkeyboardState = Keyboard.GetState();
            _currentKeysPressed = _currentkeyboardState.GetPressedKeys();

            foreach (Keys key in _currentKeysPressed)
            {
                if (_previouskeyboardState[key] == KeyState.Up)
                {
                    _events.Add(new KeyboardPressed((KeyboardKeys)key));
                }
                else
                {
                    _events.Add(new KeyboardPress((KeyboardKeys)key));
                }
            }

            foreach (Keys key in _previousKeysPressed)
            {
                if (_currentkeyboardState[key] == KeyState.Up)
                {
                    _events.Add(new KeyboardReleased((KeyboardKeys)key));
                }
            }
        }
    }
}

