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
            EventManager.Instance.AddListener(CreatePhysicObject, typeof(EntityCreated));
            EventManager.Instance.AddListener(LevelLoaded, typeof(LevelLoaded));
            EventManager.Instance.AddListener(RequestPlayerMove, typeof(RequestPlayerMove));
        }

        public void LevelLoaded(Event ev)
        {
            LevelLoaded e = (LevelLoaded)ev;

            foreach (KeyValuePair<Entity, Rectangle> tile in e.tileColliders)
            {
                AddPhysicObject(tile.Key, new StaticObject(
                    tile.Key,
                    new PhysicMaterial(0.0f, 0f, 0f, tile.Value)
                ));
            }
        }

        public void CreatePhysicObject(Event ev)
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
