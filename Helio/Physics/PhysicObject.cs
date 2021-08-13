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
        private float _mass;

        private Rectangle _collider;
        private IImpulseBehaviour _impulseBehaviour;
        private IForceBehaviour _forceBehaviour;

        public PhysicObject(Entity id, Rectangle collider, float mass, IImpulseBehaviour impulseBehaviour, IForceBehaviour forceBehaviour)
        {
            _id = id;

            _position = new Vector2(collider.X, collider.Y);
            _velocity = new Vector2(0, 0);
            _acceleration = new Vector2(0, 0);
            _mass = mass;

            _collider = collider;
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

        private void CalcPhysicMotion(GameTime gameTime)
        {
            if (_mass == 0.0f)
            {
                return;
            }

            Vector2 force = _forceBehaviour.GetForceResulting();
            force += _impulseBehaviour.GetForceResulting();

            _acceleration = force / _mass;
            _velocity += _acceleration * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            _position += _velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            _collider.X = (int)_position.X;
            _collider.Y = (int)_position.Y;

            if (_velocity != Vector2.Zero)
            {
                EventManager.Instance.QueueEvent(new EntityPhysicMoved(_id, _collider));
            }
        }

        public void Update(GameTime gameTime)
        {
            CalcPhysicMotion(gameTime);
        }
    }
}
