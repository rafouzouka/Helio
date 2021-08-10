using Helio.Actors;
using Helio.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Helio.Physics
{
    public class PhysicEngine : GameSystem
    {
        private Dictionary<Entity, PhysicObject> _objects;

        public PhysicEngine()
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

        public override void Update(GameTime gameTime)
        {
            foreach (KeyValuePair<Entity, PhysicObject> valuePair in _objects)
            {
                valuePair.Value.Update(gameTime);
            }
        }
    }
}
