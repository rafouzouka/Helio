using Helio.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

namespace Helio.Physics
{
    public class PhysicSystem : ISystem
    {
        private Dictionary<Entity, PhysicObject> _objects;

        public PhysicSystem()
        {
            _objects = new Dictionary<Entity, PhysicObject>();
        }

        public void AddPhysicObject(Entity id, PhysicObject obj)
        {
            _objects.Add(id, obj);
        }

        public void RemovePhysicObject(Entity id, PhysicObject obj)
        {
            _objects.Remove(id);
        }

        public void AddForceToObject(Entity id, Vector2 force)
        {
            if (_objects.ContainsKey(id) == false)
            {
                throw new Exception("ACTOR MUST ALREADY EXIST");
            }

            _objects[id].AddForce(force);
        }

        public void AddImpulseToObject(Entity id, Vector2 impulse)
        {
            if (_objects.ContainsKey(id) == false)
            {
                throw new Exception("ACTOR MUST ALREADY EXIST");
            }

            _objects[id].AddImpulse(impulse);
        }

        private void CalcIndependentMotions(GameTime gameTime)
        {
            foreach (KeyValuePair<Entity, PhysicObject> valuePair in _objects)
            {
                valuePair.Value.CalcIndependentMotion(gameTime);
            }
        }

        private void CheckCollisions(GameTime gameTime)
        {
            foreach (KeyValuePair<Entity, PhysicObject> collider in _objects)
            {
                foreach (KeyValuePair<Entity, PhysicObject> otherCollider in _objects)
                {
                    if (collider.Key.id != otherCollider.Key.id)
                    {
                        collider.Value.CheckCollisionX(gameTime, otherCollider.Value);
                    }
                }
            }

            foreach (KeyValuePair<Entity, PhysicObject> collider in _objects)
            {
                foreach (KeyValuePair<Entity, PhysicObject> otherCollider in _objects)
                {
                    if (collider.Key.id != otherCollider.Key.id)
                    {
                        collider.Value.CheckCollisionY(gameTime, otherCollider.Value);
                    }
                }
            }
        }   

        public void Update(GameTime gameTime)
        {
            CalcIndependentMotions(gameTime);
            CheckCollisions(gameTime);
        }

        public virtual void Init()
        {
        }

        public virtual void LoadContent(ContentManager contentManager)
        {
        }

        public virtual void Start()
        {
        }
    }
}
