using Helio.Box.Logics.Events;
using Helio.Box.Views.Events;
using Helio.Core;
using Helio.Events;
using Helio.Graphics;
using Helio.Physics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace Helio.Box.Systems
{
    public class Physic : PhysicSystem
    {
        private Vector2 _gravity = new Vector2(0, 300f);

        public override void Init()
        {
            EventManager.Instance.AddListener(MapCollidersLoaded, typeof(MapCollidersLoaded));
            EventManager.Instance.AddListener(EntityCreated, typeof(EntityCreated));
            EventManager.Instance.AddListener(RequestPlayerMove, typeof(RequestPlayerMove));
        }

        public void MapCollidersLoaded(Event ev)
        {
            MapCollidersLoaded e = (MapCollidersLoaded)ev;

            foreach (KeyValuePair<Entity, Rectangle> collider in e.colliders)
            {
                AddPhysicObject(collider.Key, new StaticObject(
                    collider.Key,
                    new PhysicMaterial(0f, 0f, 0f, collider.Value)
                ));
            }
        }

        public void EntityCreated(Event ev)
        {
            EntityCreated e = (EntityCreated)ev;

            AddPhysicObject(e.id, new DynamicObject(
                e.id,
                new PhysicMaterial(1.0f, 0f, 0f, e.collider)
            ));
            
            AddForceToObject(e.id, _gravity);
        }

        public void RequestPlayerMove(Event ev)
        {
            RequestPlayerMove e = (RequestPlayerMove)ev;

            switch (e.movementType)
            {
                case PlayerMovementType.Jump:
                    AddImpulseToObject(e.entity, new Vector2(0f, -10000f));
                    break;

                case PlayerMovementType.WalkRight:
                    AddImpulseToObject(e.entity, new Vector2(1000f, 0f));
                    break;

                case PlayerMovementType.WalkLeft:
                    AddImpulseToObject(e.entity, new Vector2(-1000f, 0f));
                    break;

                default:
                    break;
            }

        }
    }
}
