using Helio.Core;
using Helio.Events;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Helio.Physics
{
    public class DynamicObject : PhysicObject
    {
        private List<Vector2> _forces;
        private List<Vector2> _impulses;

        private Vector2 _position;
        private Vector2 _velocity;
        private Vector2 _acceleration;

        //private Vector2 _penetrationMotion;
        private Vector2 _collisionMotion;

        public DynamicObject(Entity id, PhysicMaterial physicMaterial) : base(id, physicMaterial)
        {
            _forces = new List<Vector2>();
            _impulses = new List<Vector2>();

            
            _position = new Vector2(physicMaterial.collider.X, physicMaterial.collider.Y);
            _velocity = Vector2.Zero;
            _acceleration = Vector2.Zero;

            //_independentPosition = new Vector2(physicMaterial.collider.X, physicMaterial.collider.Y);
            //_penetrationMotion = Vector2.Zero;
            _collisionMotion = Vector2.Zero;
        }

        public override void AddForce(Vector2 force)
        {
            _forces.Add(force);
        }

        public override void AddImpulse(Vector2 impulse)
        {
            _impulses.Add(impulse);
        }

        public override void RemoveForce(Vector2 force)
        {
            _forces.Remove(force);
        }

        public override void RemoveImpulse(Vector2 impulse)
        {
            _impulses.Remove(impulse);
        }

        private Vector2 GetForceResulting()
        {
            Vector2 calc = Vector2.Zero;

            foreach (Vector2 force in _forces)
            {
                calc += force;
            }

            return calc;
        }

        private Vector2 GetImpulseResulting()
        {
            Vector2 calc = Vector2.Zero;

            foreach (Vector2 impulse in _impulses)
            {
                calc += impulse;
            }
            
            _impulses.Clear();
            return calc;
        }

        public override void CalcIndependentMotion(GameTime gameTime)
        {
            if (_physicMaterial.mass == 0f)
            {
                return;
            }
            
            Vector2 force = GetForceResulting();
            force += GetImpulseResulting();

            _acceleration = force / _physicMaterial.mass;
            _velocity += _acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _position += _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            _physicMaterial.collider.X = (int)_position.X;
            _physicMaterial.collider.Y = (int)_position.Y;
        }

        public override void CheckCollision(GameTime gameTime, PhysicObject otherObject)
        {
            Rectangle intersection = Rectangle.Intersect(_physicMaterial.collider, otherObject._physicMaterial.collider);
            if (intersection == Rectangle.Empty)
            {
                return;
            }

            otherObject.AddCollisonForce(_acceleration);
            _velocity.Y = 0;
            _position.Y -= intersection.Height; 

            _velocity -= _velocity * otherObject._physicMaterial.friction;
        }

        public override void ResolveRealMotion(GameTime gameTime)
        {
            _physicMaterial.collider.X = (int)_position.X;
            _physicMaterial.collider.Y = (int)_position.Y;

            EventManager.Instance.QueueEvent(new EntityPhysicMoved(_id, _physicMaterial.collider));
        }

        public override void AddCollisonForce(Vector2 force)
        {
        }
    }
}
