using Microsoft.Xna.Framework;

namespace Helio.Physics
{
    public interface IImpulseBehaviour
    {
        void AddImpulse(Vector2 impulse);

        void RemoveImpulse(Vector2 impulse);

        Vector2 GetForceResulting();
    }
}
