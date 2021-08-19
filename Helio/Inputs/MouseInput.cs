using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Helio.Inputs
{
    public class MouseInput : IControllerInput
    {
        MouseState _currentMouseState;
        MouseState _previousMouseState;

        public MouseInput()
        {
            _currentMouseState = Mouse.GetState();
        }

        public void PollEvents(List<InputEvent> inputEvents)
        {
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();

            Point previousPosition = _previousMouseState.Position;
            Point currentPosition = _currentMouseState.Position;
            if (previousPosition != currentPosition)
            {
                inputEvents.Add(new MouseMoved(previousPosition, currentPosition));
            }

            // Mouse Released
            if (_currentMouseState.LeftButton == ButtonState.Released && _previousMouseState.LeftButton == ButtonState.Pressed)
            {
                inputEvents.Add(new MouseLeftButtonReleased(currentPosition));
            }
            if (_currentMouseState.RightButton == ButtonState.Released && _previousMouseState.RightButton == ButtonState.Pressed)
            {
                inputEvents.Add(new MouseRightButtonReleased(currentPosition));
            }
            if (_currentMouseState.MiddleButton == ButtonState.Released && _previousMouseState.MiddleButton == ButtonState.Pressed)
            {
                inputEvents.Add(new MouseMiddleButtonReleased(currentPosition));
            }

            // Mouse Pressed
            if (_currentMouseState.LeftButton == ButtonState.Pressed && _previousMouseState.LeftButton == ButtonState.Released)
            {
                inputEvents.Add(new MouseLeftButtonPressed(currentPosition));
            }
            if (_currentMouseState.RightButton == ButtonState.Pressed && _previousMouseState.RightButton == ButtonState.Released)
            {
                inputEvents.Add(new MouseRightButtonPressed(currentPosition));
            }
            if (_currentMouseState.MiddleButton == ButtonState.Pressed && _previousMouseState.MiddleButton == ButtonState.Released)
            {
                inputEvents.Add(new MouseMiddleButtonPressed(currentPosition));
            }

            // Mouse Press
            if (_currentMouseState.LeftButton == ButtonState.Pressed)
            {
                inputEvents.Add(new MouseLeftButtonPress(currentPosition));
            }
            if (_currentMouseState.RightButton == ButtonState.Pressed)
            {
                inputEvents.Add(new MouseRightButtonPress(currentPosition));
            }
            if (_currentMouseState.MiddleButton == ButtonState.Pressed)
            {
                inputEvents.Add(new MouseMiddleButtonPress(currentPosition));
            }
        }
    }
}
