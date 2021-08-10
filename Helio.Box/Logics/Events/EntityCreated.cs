﻿using Helio.Actors;
using Helio.Box.Logics.Systems;
using Helio.Core;
using Helio.Events;
using Microsoft.Xna.Framework;

namespace Helio.Box.Logics.Events
{
    public class EntityCreated : Event
    {
        public Entity id;
        public EntityType type;
        public Rectangle rect;

        public EntityCreated(Entity id, EntityType type, Rectangle rect)
        {
            this.id = id;
            this.type = type;
            this.rect = rect;
        }
    }
}
