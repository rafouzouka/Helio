using Helio.Processes;
using Microsoft.Xna.Framework;

namespace Helio.Box.Processes
{
    public class KaboomProcess : Process
    {
        public override void OnUpdate(GameTime deltaTime)
        {
            Succeed();
        }
    }
}
