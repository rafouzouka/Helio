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
        public Vector3 pos;

        public EntityCreated(ActorId id, EntityType type, Vector3 pos)
        {
            this.id = id;
            this.type = type;
            this.pos = pos;
        }
    }
}
