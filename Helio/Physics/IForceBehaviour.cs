using Microsoft.Xna.Framework;

namespace Helio.Physics
{
    public interface IForceBehaviour
    {
        void AddForce(Vector2 force);

        void RemoveForce(Vector2 force);

        Vector2 GetForceResulting();
    }
}
