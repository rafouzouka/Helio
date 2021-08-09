using Helio.Box.Logics.Events;
using Helio.Box.Logics.Systems;
using Helio.Events;
using Helio.Physics;
using System;

namespace Helio.Box.Systems
{
    public class Physic : PhysicEngine
    {
        public override void Init()
        {
            EventManager.Instance.AddListener(CreatePhysicObject, typeof(EntityCreated));
        }

        public void CreatePhysicObject(Event ev)
        {
            EntityCreated e = (EntityCreated)ev;

            switch (e.type)
            {
                case EntityType.Player:
                    AddPhysicObject(e.id, new StaticObject(e.rect));
                    break;

                case EntityType.Enemy:
                    AddPhysicObject(e.id, new StaticObject(e.rect));
                    break;

                default:
                    throw new Exception("The Type of the entity doesn't match with the renderer.");
            }
        }
    }
}
