using Microsoft.Xna.Framework;

namespace Helio.Physics
{
    public interface IColliderBehaviour
    {
        void MoveCollider(Vector2 newPosition);

        Rectangle GetCollider();

        Vector2 CheckCollision(PhysicObject otherPhysicObject);
    }
}
