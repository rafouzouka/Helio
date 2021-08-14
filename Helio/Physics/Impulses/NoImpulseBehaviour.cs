using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Physics
{
    public class NoImpulseBehaviour : IImpulseBehaviour
    {
        public void AddImpulse(Vector2 impulse)
        {
        }

        public Vector2 GetForceResulting()
        {
            return new Vector2(0, 0);
        }

        public void RemoveImpulse(Vector2 impulse)
        {
        }
    }
}
