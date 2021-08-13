using Helio.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Inputs
{
    public class KeyboardPressed : InputEvent
    {
        public KeyboardKeys key;

        public KeyboardPressed(KeyboardKeys key)
        {
            this.key = key;
        }
    }
    
    public class KeyboardReleased : InputEvent
    {
        public KeyboardKeys key;

        public KeyboardReleased(KeyboardKeys key)
        {
            this.key = key;
        }
    }

    public class KeyboardPress : InputEvent
    {
        public KeyboardKeys key;

        public KeyboardPress(KeyboardKeys key)
        {
            this.key = key;
        }
    }
}
