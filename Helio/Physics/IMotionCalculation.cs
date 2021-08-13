using Microsoft.Xna.Framework;

namespace Helio.Physics
{
    public interface IMotionCalculation
    {
        Vector2 CalcNewPosition(ref Vector2 acc, ref Vector2 vel, ref Vector2 pos, Vector2 force, PhysicMaterial material, GameTime gameTime);
    }
}