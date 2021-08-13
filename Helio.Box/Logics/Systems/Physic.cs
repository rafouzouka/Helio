using Helio.Box.Logics.Events;
using Helio.Box.Views.Events;
using Helio.Events;
using Helio.Physics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Helio.Box.Systems
{
    public class Physic : PhysicSystem
    {
        private Vector2 _gravity = new Vector2(0, 0.01f);

        public override void Init()
        {
            EventManager.Instance.AddListener(CreatePhysicObject, typeof(EntityCreated));
            EventManager.Instance.AddListener(TerrainLoaded, typeof(TerrainLoaded));
            EventManager.Instance.AddListener(RequestPlayerMove, typeof(RequestPlayerMove));
        }

        public void TerrainLoaded(Event ev)
        {
            TerrainLoaded e = (TerrainLoaded)ev;

            //AddPhysicObject(e.id, new PhysicObject(e.id, e.collider, 0.0f, new NoImpulseBehaviour(), new NoForceBehaviour()));
        }

        public void CreatePhysicObject(Event ev)
        {
            EntityCreated e = (EntityCreated)ev;

            AddPhysicObject(e.id, new PhysicObject(e.id, e.collider, 10.0f, new BasicImpulseBehaviour(), new NoForceBehaviour()));
        }

        public void RequestPlayerMove(Event ev)
        {
            RequestPlayerMove e = (RequestPlayerMove)ev;

            AddImpulseToObject(e.entity, new Vector2(0f, -0.01f));
            Debug.WriteLine($"REQUEST PLAYER MOVE: {e.movementType}");
        }
    }
}
