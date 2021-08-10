using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Helio.Physics
{
    public class BasicForceBehaviour : IForceBehaviour
    {
        private List<Vector2> _forces;

        public BasicForceBehaviour()
        {
            _forces = new List<Vector2>();
        }

        public void AddForce(Vector2 force)
        {
            _forces.Add(force);
        }

        public void RemoveForce(Vector2 force)
        {
            _forces.Remove(force);
        }

        public Vector2 GetForceResulting()
        {
            Vector2 vec = new Vector2(0, 0);

            foreach (Vector2 force in _forces)
            {
                vec += force;
            }

            return vec;
        }
    }
}
