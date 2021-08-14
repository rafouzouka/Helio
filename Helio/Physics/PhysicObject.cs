using Helio.Core;
using Microsoft.Xna.Framework;
namespace Helio.Physics
{
    public class PhysicObject
    {
        private Entity _id;
        private PhysicMaterial _physicMaterial;
        private IPhysicBehaviour _physicBehaviour;

        public PhysicObject(Entity id, PhysicMaterial physicMaterial, IPhysicBehaviour physicBehaviour)
        {
            _id = id;
            _physicMaterial = physicMaterial;
            _physicBehaviour = physicBehaviour;
        }

        public void AddForce(Vector2 force)
        {
            _physicBehaviour.AddForce(force);
        }

        public void RemoveForce(Vector2 force)
        {
            _physicBehaviour.RemoveForce(force);
        }

        public void AddImpulse(Vector2 force)
        {
            _physicBehaviour.AddImpulse(force);
        }

        public void RemoveImpulse(Vector2 force)
        {
            _physicBehaviour.RemoveImpulse(force);
        }

        public void CalcIndependentMotion(GameTime gameTime)
        {
            _physicBehaviour.CalcIndependentMotion(gameTime);
        }

        public void CheckCollision(GameTime gameTime, PhysicObject otherObject)
        {
            _physicBehaviour.CheckCollision(gameTime, otherObject);
        }

        public void ResolveRealMotion(GameTime gameTime)
        {
            _physicBehaviour.ResolveRealMotion(gameTime);
        }
    }
}
