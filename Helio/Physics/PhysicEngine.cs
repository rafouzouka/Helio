using Helio.Actors;
using Helio.Core;
using Helio.Events;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Helio.Physics
{
    public class PhysicEngine : GameSystem
    {
        private Dictionary<ActorId, PhysicObject> _objects;

        public PhysicEngine()
        {
            _objects = new Dictionary<ActorId, PhysicObject>();
        }

        public void AddPhysicObject(ActorId id, PhysicObject obj)
        {
            _objects.Add(id, obj);
        }

        public void RemovePhysicObject(ActorId id, PhysicObject obj)
        {
            _objects.Remove(id);
        }

        public void AddForceToObject(ActorId id, Vector2 force)
        {
            if (_objects.ContainsKey(id) == false)
            {
                throw new Exception("ACTOR MUST ALREADY EXIST");
            }

            _objects[id].AddForce(force);
        }

        public void AddImpulseToObject(ActorId id, Vector2 impulse)
        {
            if (_objects.ContainsKey(id) == false)
            {
                throw new Exception("ACTOR MUST ALREADY EXIST");
            }

            _objects[id].AddImpulse(impulse);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (KeyValuePair<ActorId, PhysicObject> valuePair in _objects)
            {
                valuePair.Value.Update(gameTime);
            }
        }
    }
}
