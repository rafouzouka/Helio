using Helio.Core;
using Helio.Events;
using Helio.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace Helio.Layers
{
    public abstract class Layer
    {
        public abstract bool OnEvent(Event e);
    }
}
