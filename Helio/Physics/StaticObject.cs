using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Physics
{
    public class StaticObject : PhysicObject
    {
        public StaticObject(Rectangle collider) : base(collider)
        {

        }

        public override void AddForce(Vector2 force)
        {
            throw new Exception("Cannot add any force to static object.");
        }

        public override void AddImpulse(Vector2 force)
        {
            throw new Exception("Cannot add any force to static object.");
        }

        public override void RemoveForce(Vector2 force)
        {
            throw new Exception("Cannot remove any force to static object.");
        }

        public override void RemoveImpulse(Vector2 force)
        {
            throw new Exception("Cannot remove any force to static object.");
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
