using Helio.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Box.Components
{
    public abstract class Pickup : Component
    {
        public abstract void Apply(Actor actor);
    }
}
