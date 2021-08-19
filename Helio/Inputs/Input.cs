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

        //private MouseState _currentMouseState;

        private List<InputEvent> _inputEvents;

        public Input()
        {
            _currentkeyboardState = Keyboard.GetState();
            _currentKeysPressed = _currentkeyboardState.GetPressedKeys();
            _inputEvents = new List<InputEvent>();

            //_currentMouseState = Mouse.GetState();
            //_currentMouseState.
        }

        public List<InputEvent> GetInputs()
        {
            return _inputEvents;
        }

        public void PollEvents()
        {
            _inputEvents.Clear();
            PoolKeyboardEvents();
        }

        private void PoolKeyboardEvents()
        {
            _previouskeyboardState = _currentkeyboardState;
            _previousKeysPressed = _currentKeysPressed;

            _currentkeyboardState = Keyboard.GetState();
            _currentKeysPressed = _currentkeyboardState.GetPressedKeys();

            foreach (Keys key in _currentKeysPressed)
            {
                if (_previouskeyboardState[key] == KeyState.Up)
                {
                    _inputEvents.Add(new KeyboardPressed((KeyboardKeys)key));
                }
                else
                {
                    _inputEvents.Add(new KeyboardPress((KeyboardKeys)key));
                }
            }

            foreach (Keys key in _previousKeysPressed)
            {
                if (_currentkeyboardState[key] == KeyState.Up)
                {
                    _inputEvents.Add(new KeyboardReleased((KeyboardKeys)key));
                }
            }
        }
    }
}

