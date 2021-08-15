using Helio.Core;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Helio.Physics
{
    public abstract class PhysicObject
    {
        public Entity _id;
        public PhysicMaterial _physicMaterial;

        public PhysicObject(Entity id, PhysicMaterial physicMaterial)
        {
            _id = id;
            _physicMaterial = physicMaterial;
        }

        public abstract void AddForce(Vector2 force);

        public abstract void RemoveForce(Vector2 force);

        public abstract void AddImpulse(Vector2 force);

        public abstract void RemoveImpulse(Vector2 force);

        public abstract void CalcIndependentMotion(GameTime gameTime);

        public abstract void CheckCollisionX(GameTime gameTime, PhysicObject physicObject);

        public abstract void CheckCollisionY(GameTime gameTime, PhysicObject physicObject);
    }
}
