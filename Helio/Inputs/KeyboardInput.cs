using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Helio.Inputs
{
    public class KeyboardInput : IControllerInput
    {
        private KeyboardState _previouskeyboardState;
        private KeyboardState _currentkeyboardState;
        private Keys[] _previousKeysPressed;
        private Keys[] _currentKeysPressed;

        public KeyboardInput()
        {
            _currentkeyboardState = Keyboard.GetState();
            _currentKeysPressed = _currentkeyboardState.GetPressedKeys();
        }

        public void PollEvents(List<InputEvent> inputEvents)
        {
            _previouskeyboardState = _currentkeyboardState;
            _previousKeysPressed = _currentKeysPressed;

            _currentkeyboardState = Keyboard.GetState();
            _currentKeysPressed = _currentkeyboardState.GetPressedKeys();

            foreach (Keys key in _currentKeysPressed)
            {
                if (_previouskeyboardState[key] == KeyState.Up)
                {
                    inputEvents.Add(new KeyboardPressed((KeyboardKeys)key));
                }
                else
                {
                    inputEvents.Add(new KeyboardPress((KeyboardKeys)key));
                }
            }

            foreach (Keys key in _previousKeysPressed)
            {
                if (_currentkeyboardState[key] == KeyState.Up)
                {
                    inputEvents.Add(new KeyboardReleased((KeyboardKeys)key));
                }
            }
        }
    }
}
