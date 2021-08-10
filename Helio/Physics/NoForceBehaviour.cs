using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Physics
{
    public class NoForceBehaviour : IForceBehaviour
    {
        public void AddForce(Vector2 force)
        {
        }

        public Vector2 ApplyToForce(Vector2 force)
        {
            return force;
        }

        public Vector2 GetForceResulting()
        {
            return new Vector2(0, 0);
        }

        public void RemoveForce(Vector2 force)
        {
        }
    }
}
