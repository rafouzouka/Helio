using Helio.Box.Logics.Events;
using Helio.Box.Logics.Systems;
using Helio.Events;
using Helio.Physics;
using Microsoft.Xna.Framework;
using System;

namespace Helio.Box.Systems
{
    public class Physic : PhysicEngine
    {
        private Vector2 _gravity = new Vector2(0, 0.01f);

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
                    AddPhysicObject(e.id, new PhysicObject(e.id, e.rect, 10.0f, new BasicImpulseBehaviour(), new BasicForceBehaviour()));
                    AddForceToObject(e.id, _gravity);
                    break;

                case EntityType.Enemy:
                    AddPhysicObject(e.id, new PhysicObject(e.id, e.rect, 10.0f, new BasicImpulseBehaviour(), new BasicForceBehaviour()));
                    AddForceToObject(e.id, _gravity);
                    break;

                case EntityType.Block:
                    AddPhysicObject(e.id, new PhysicObject(e.id, e.rect, 0.0f, new NoImpulseBehaviour(), new NoForceBehaviour()));
                    break;

                default:
                    throw new Exception("The Type of the entity doesn't match with the renderer.");
            }
        }
    }
}
