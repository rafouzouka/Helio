using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Physics
{
    public struct PhysicMaterial
    {
        public float friction;
        public float restitution;

        public PhysicMaterial(float friction, float restitution)
        {
            this.friction = friction;
            this.restitution = restitution;
        }
    }
}
