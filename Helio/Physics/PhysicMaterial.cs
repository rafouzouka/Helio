using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Physics
{
    public struct PhysicMaterial
    {
        public float mass;
        public float friction;
        public float restitution;

        public PhysicMaterial(float mass, float friction, float restitution)
        {
            this.mass = mass;
            this.friction = friction;
            this.restitution = restitution;
        }
    }
}
