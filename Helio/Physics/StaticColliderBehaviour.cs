using Microsoft.Xna.Framework;

namespace Helio.Physics
{
    public class StaticColliderBehaviour : IColliderBehaviour
    {
        private Rectangle _collider;

        public StaticColliderBehaviour(Rectangle collider)
        {
            _collider = collider;
        }

        public Vector2 CheckCollision(PhysicObject otherPhysicObject)
        {
            return Vector2.Zero;
        }

        public Rectangle GetCollider()
        {
            return _collider;
        }

        public void MoveCollider(Vector2 newPosition)
        {
        }
    }
}
