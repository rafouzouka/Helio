using Helio.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Physics
{
    public class LimitedVelocity : IMotionCalculation
    {
        private float _minVelocity;
        private float _maxVelocity;

        public LimitedVelocity(float min, float max)
        {
            _minVelocity = min;
            _maxVelocity = max;
        }

        public Vector2 CalcNewPosition(ref Vector2 acc, ref Vector2 vel, ref Vector2 pos, Vector2 force, PhysicMaterial material, GameTime gameTime)
        {
            if (material.mass == 0.0f)
            {
                return pos;
            }

            acc = force / material.mass;
            vel += acc * (float)gameTime.ElapsedGameTime.TotalSeconds;
            /*
                        vel.X = Utils.Clamp(vel.X, _minVelocity, _maxVelocity);
                        vel.Y = Utils.Clamp(vel.Y, _minVelocity, _maxVelocity);*/

            vel *= material.friction * (float)gameTime.ElapsedGameTime.TotalSeconds;

            pos += vel * (float)gameTime.ElapsedGameTime.TotalSeconds;

            return pos;
        }
    }
}
