using Microsoft.Xna.Framework;

namespace Helio.Physics
{
    public class DynamicColliderBehaviour : IColliderBehaviour
    {
        private Rectangle _collider;
        private Vector2 _penetrationCollision;

        public DynamicColliderBehaviour(Rectangle collider)
        {
            _collider = collider;
            _penetrationCollision = Vector2.Zero;
        }

        public Rectangle GetCollider()
        {
            return _collider;
        }

        public Vector2 CheckCollision(PhysicObject otherPhysicObject)
        {
            Rectangle collisionResult = Rectangle.Intersect(_collider, otherPhysicObject.GetCollider());

            if (collisionResult != Rectangle.Empty)
            {
                _penetrationCollision = new Vector2(0, collisionResult.Height);
            }
            else
            {
                _penetrationCollision.X = 0;
                _penetrationCollision.Y = 0;
            }
            return _penetrationCollision;
        }

        public void MoveCollider(Vector2 newPosition)
        {
            _collider.X = (int)newPosition.X;
            _collider.Y = (int)newPosition.Y;
        }
    }
}
