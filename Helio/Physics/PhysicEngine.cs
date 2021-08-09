﻿using Helio.Actors;
using Helio.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

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

        public override void Update(GameTime gameTime)
        {
            foreach (KeyValuePair<ActorId, PhysicObject> valuePair in _objects)
            {
                valuePair.Value.Update(gameTime);
            }
        }

        public void AddForceToObject(ActorId id, Vector2 force)
        {
            if (_objects.ContainsKey(id) == false)
            {
                throw new Exception("ACTOR MUST ALREADY EXIST");
            }

            //_objects[id].
        }
    }
}