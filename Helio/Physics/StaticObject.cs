using Helio.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Physics
{
    public class StaticObject : PhysicObject
    {
        public StaticObject(Entity id, PhysicMaterial physicMaterial) : base(id, physicMaterial)
        {
        }

        public override void AddCollisonForce(Vector2 force)
        {
        }

        public override void AddForce(Vector2 force)
        {
        }

        public override void AddImpulse(Vector2 force)
        {
        }

        public override void CalcIndependentMotion(GameTime gameTime)
        {
        }

        public override void CheckCollision(GameTime gameTime, PhysicObject otherObject)
        {
        }

        public override void RemoveForce(Vector2 force)
        {
        }

        public override void RemoveImpulse(Vector2 force)
        {
        }

        public override void ResolveRealMotion(GameTime gameTime)
        {
        }
    }
}
