using Microsoft.Xna.Framework;

namespace Helio.Physics
{
    public interface IPhysicBehaviour
    {
        void AddForce(Vector2 force);

        void RemoveForce(Vector2 force);

        void AddImpulse(Vector2 impulse);

        void RemoveImpulse(Vector2 impulse);

        void CalcIndependentMotion(GameTime gameTime);

        void CheckCollision(GameTime gameTime, PhysicObject otherObject);

        public void ResolveRealMotion(GameTime gameTime);
    }
}
