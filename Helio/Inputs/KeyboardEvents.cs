using Helio.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Inputs
{
    public class KeyboardPressed : Event
    {
        public KeyboardKeys key;

        public KeyboardPressed(KeyboardKeys key)
        {
            this.key = key;
        }
    }
    
    public class KeyboardReleased : Event
    {
        public KeyboardKeys key;

        public KeyboardReleased(KeyboardKeys key)
        {
            this.key = key;
        }
    }

    public class KeyboardPress : Event
    {
        public KeyboardKeys key;

        public KeyboardPress(KeyboardKeys key)
        {
            this.key = key;
        }
    }
}
