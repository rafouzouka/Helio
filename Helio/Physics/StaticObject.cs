using Helio.Core;
using Microsoft.Xna.Framework;

namespace Helio.Physics
{
    public class StaticObject : PhysicObject
    {
        public StaticObject(Entity id, PhysicMaterial physicMaterial) : base(id, physicMaterial)
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

        public override void CheckCollisionX(GameTime gameTime, PhysicObject physicObject)
        {
        }

        public override void CheckCollisionY(GameTime gameTime, PhysicObject physicObject)
        {
        }

        public override void RemoveForce(Vector2 force)
        {
        }

        public override void RemoveImpulse(Vector2 force)
        {
        }
    }
}
