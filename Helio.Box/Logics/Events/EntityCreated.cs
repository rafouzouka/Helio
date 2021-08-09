using Helio.Actors;
using Helio.Box.Logics.Systems;
using Helio.Events;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Box.Logics.Events
{
    public class EntityCreated : Event
    {
        public ActorId id;
        public EntityType type;
        public Rectangle rect;

        public EntityCreated(ActorId id, EntityType type, Rectangle rect)
        {
            this.id = id;
            this.type = type;
            this.rect = rect;
        }
    }
}
