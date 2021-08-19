using Helio.Events;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Inputs
{
    public class Input
    {
        private IControllerInput _keyboardInput;
        private IControllerInput _mouseInput;
        private List<InputEvent> _inputEvents;

        public Input()
        {
            _keyboardInput = new KeyboardInput();
            _mouseInput = new MouseInput();
            _inputEvents = new List<InputEvent>();
        }

        public List<InputEvent> GetInputs()
        {
            return _inputEvents;
        }

        public void PollEvents()
        {
            _inputEvents.Clear();
            _keyboardInput.PollEvents(_inputEvents);
            _mouseInput.PollEvents(_inputEvents);
        }
    }
}

