using Helio.Core;
using Helio.Events;
using Microsoft.Xna.Framework;

namespace Helio.Box.Logics.Events
{
    public class EntityMoved : Event
    {
        public Entity id;
        public Vector3 pos;

        public EntityMoved(Entity id, Vector3 pos)
        {
            this.id = id;
            this.pos = pos;
        }
    }
}
