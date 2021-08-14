using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Helio.Physics
{
    public class BasicImpulseBehaviour : IImpulseBehaviour
    {
        private List<Vector2> _impulses;

        public BasicImpulseBehaviour()
        {
            _impulses = new List<Vector2>();
        }

        public void AddImpulse(Vector2 impulse)
        {
            _impulses.Add(impulse);
        }

        public void RemoveImpulse(Vector2 impulse)
        {
            _impulses.Remove(impulse);
        }

        public Vector2 GetForceResulting()
        {
            Vector2 vec = new Vector2(0, 0);

            foreach (Vector2 impulse in _impulses)
            {
                vec += impulse;
            }
            _impulses.Clear();

            return vec;
        }
    }
}
