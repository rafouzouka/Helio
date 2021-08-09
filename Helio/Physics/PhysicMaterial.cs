using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Physics
{
    public struct PhysicMaterial
    {
        public float restitution;
        public float friction;

        public PhysicMaterial(float restitution, float friction)
        {
            this.restitution = restitution;
            this.friction = friction;
        }
    }
}
