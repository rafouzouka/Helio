using Helio.Core;
using Helio.Events;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Box.Logics.Events
{
    public class MapCollidersLoaded : Event
    {
        public Dictionary<Entity, Rectangle> colliders;

        public MapCollidersLoaded(Dictionary<Entity, Rectangle> colliders)
        {
            this.colliders = colliders;
        }
    }
}
