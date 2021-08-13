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
        private IMotionCalculation _motionCalculation;
        private IColliderBehaviour _colliderBehaviour;

        public PhysicObject(Entity id, PhysicMaterial physicMaterial, IImpulseBehaviour impulseBehaviour, IForceBehaviour forceBehaviour, IMotionCalculation motionCalculation, IColliderBehaviour colliderBehaviour)
        {
            _id = id;

            _position = new Vector2(colliderBehaviour.GetCollider().X, colliderBehaviour.GetCollider().Y);
            _velocity = new Vector2(0, 0);
            _acceleration = new Vector2(0, 0);

            _physicMaterial = physicMaterial;

            _impulseBehaviour = impulseBehaviour;
            _forceBehaviour = forceBehaviour;
            _motionCalculation = motionCalculation;
            _colliderBehaviour = colliderBehaviour;
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

        public void CalcPhysicMotion(GameTime gameTime)
        {
            Vector2 force = _forceBehaviour.GetForceResulting();
            force += _impulseBehaviour.GetForceResulting();

            Vector2 newPosition = _motionCalculation.CalcNewPosition(ref _acceleration, ref _velocity, ref _position, force, _physicMaterial, gameTime);
            _colliderBehaviour.MoveCollider(newPosition);
        }

        public void CheckCollision(PhysicObject otherPhysicObject)
        {
            Vector2 penetrationCollision = _colliderBehaviour.CheckCollision(otherPhysicObject);

            if (penetrationCollision != Vector2.Zero)
            {
                _position.Y -= penetrationCollision.Y;
                _velocity.Y = 0f;

                _colliderBehaviour.MoveCollider(_position);
            }

            EventManager.Instance.QueueEvent(new EntityPhysicMoved(_id, _colliderBehaviour.GetCollider()));
        }

        public Rectangle GetCollider()
        {
            return _colliderBehaviour.GetCollider();
        }
    }
}
