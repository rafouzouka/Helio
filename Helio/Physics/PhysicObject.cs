using Microsoft.Xna.Framework;

namespace Helio.Physics
{

    public abstract class PhysicObject
    {
        private Rectangle _collider;

        public PhysicObject(Rectangle collider)
        {
            _collider = collider;
        }

        public abstract void AddForce(Vector2 force);

        public abstract void RemoveForce(Vector2 force);

        public abstract void AddImpulse(Vector2 force);

        public abstract void RemoveImpulse(Vector2 force);

        public abstract void Update(GameTime gameTime);
    }
}


/*


public class PhysicObject
    {
        private Vector2 _position;
        private Vector2 _velocity;
        private Vector2 _acceleration;

        private List<Vector2> _forces;
        private List<Vector2> _impules;

        private float _mass;

        public PhysicObject()
        {
            _forces = new List<Vector2>();
            _impules = new List<Vector2>();

            _mass = 0.0f;
        }

        public void AddForce(Vector2 force)
        {
            _forces.Add(force);
        }

        public void RemoveForce(Vector2 force)
        {
            _forces.Remove(force);
        }

        public void AddImpulse(Vector2 impulse)
        {
            _impules.Add(impulse);
        }

        public void Update(GameTime gameTime)
        {
            if (_mass == 0.0)
            {
                return;
            }

            Vector2 forcesAddition = new Vector2();
            foreach (Vector2 force in _forces)
            {
                forcesAddition += force;
            }

            foreach (Vector2 impulse in _impules)
            {
                forcesAddition += impulse;
            }

            _impules.Clear();

            _acceleration = forcesAddition / _mass;
            _velocity += _acceleration * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            _position += _velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }



*/