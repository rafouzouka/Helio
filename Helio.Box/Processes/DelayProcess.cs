using Helio.Core;
using Helio.Processes;
using Microsoft.Xna.Framework;

namespace Helio.Box.Processes
{
    public class DelayProcess : Process
    {
        private double _timeToDelay;
        private double _timeDelayedSoFar;

        public DelayProcess(uint timeToDelay)
        {
            _timeToDelay = timeToDelay;
            _timeDelayedSoFar = 0;
        }

        public override void OnUpdate(GameTime gameTime)
        {
            _timeDelayedSoFar += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (_timeDelayedSoFar >= _timeToDelay)
            {
                Succeed();
            }
        }
    }
}
