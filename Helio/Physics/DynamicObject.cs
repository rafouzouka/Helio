using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Physics
{
    public class DynamicObject : IPhysicBehaviour
    {
        private List<Vector2> _forces;
        private List<Vector2> _impulses;

        private Vector2 _independentPosition;
        private Vector2 _position;
        private Vector2 _velocity;
        private Vector2 _acceleration;
        private Vector2 _penetrationMotion;

        public DynamicObject()
        {
            _forces = new List<Vector2>();
            _impulses = new List<Vector2>();

/*            _independentPosition = new Vector2(physicMaterial.collider.X, physicMaterial.collider.Y);
            _position = new Vector2(physicMaterial.collider.X, physicMaterial.collider.Y);
            _velocity = Vector2.Zero;
            _acceleration = Vector2.Zero;
            _penetrationMotion = Vector2.Zero;*/
        }

        public void AddForce(Vector2 force)
        {
            _forces.Add(force);
        }

        public void AddImpulse(Vector2 impulse)
        {
            _impulses.Add(impulse);
        }

        public void RemoveForce(Vector2 force)
        {
            _forces.Remove(force);
        }

        public void RemoveImpulse(Vector2 impulse)
        {
            _impulses.Remove(impulse);
        }

        public void CalcIndependentMotion(GameTime gameTime)
        {
            /*            if (_physicMaterial.mass == 0f)
            {
                return;
            }

            Vector2 force = _forceBehaviour.GetForceResulting();
            force += _impulseBehaviour.GetForceResulting();

            _acceleration = force / _physicMaterial.mass;
            _velocity += _acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _position += _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            _physicMaterial.collider.X = (int)_position.X;
            _physicMaterial.collider.Y = (int)_position.Y;*/
        }

        public void CheckCollision(GameTime gameTime, PhysicObject otherObject)
        {
            /*            Rectangle intersection = Rectangle.Intersect(_physicMaterial.collider, otherObject._physicMaterial.collider);
            if (intersection == Rectangle.Empty)
            {
                return;
            }

            _penetrationMotion.Y = intersection.Height;
            _velocity.Y = 0;*/
        }

        public void ResolveRealMotion(GameTime gameTime)
        {
            /*            _position -= _penetrationMotion;

            _physicMaterial.collider.X = (int)_position.X;
            _physicMaterial.collider.Y = (int)_position.Y;

            _penetrationMotion.X = 0;
            _penetrationMotion.Y = 0;

            EventManager.Instance.QueueEvent(new EntityPhysicMoved(_id, _physicMaterial.collider));*/
        }
    }
}
