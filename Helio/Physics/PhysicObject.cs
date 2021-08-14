using Helio.Actors;
using Helio.Core;
using Helio.Events;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace Helio.Physics
{
    public class PhysicObject
    {
        private Entity _id;

        private Vector2 _position;
        private Vector2 _velocity;
        private Vector2 _acceleration;

        private PhysicMaterial _physicMaterial;

        private IImpulseBehaviour _impulseBehaviour;
        private IForceBehaviour _forceBehaviour;

        public PhysicObject(Entity id, PhysicMaterial physicMaterial, IImpulseBehaviour impulseBehaviour, IForceBehaviour forceBehaviour)
        {
            _id = id;

            //_position = new Vector2(colliderBehaviour.GetCollider().X, colliderBehaviour.GetCollider().Y);
            _position = Vector2.Zero;
            _velocity = Vector2.Zero;
            _acceleration = Vector2.Zero;

            _physicMaterial = physicMaterial;

            _impulseBehaviour = impulseBehaviour;
            _forceBehaviour = forceBehaviour;
        }

        public void AddForce(Vector2 force)
        {
            _forceBehaviour.AddForce(force);
        }

        public void RemoveForce(Vector2 force)
        {
            _forceBehaviour.RemoveForce(force);
        }

        public void AddImpulse(Vector2 force)
        {
            _impulseBehaviour.AddImpulse(force);
        }

        public void RemoveImpulse(Vector2 force)
        {
            _impulseBehaviour.RemoveImpulse(force);
        }
    }
}
