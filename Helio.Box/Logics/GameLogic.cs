using Helio.Box.Logics.Systems;
using Helio.Box.Systems;
using Helio.Core;

namespace Helio.Box.Logics
{
    public class GameLogic : Logic
    {
        public GameLogic()
        {
            _systems.Add(new Loading());
            _systems.Add(new Physic());
        }
    }
}
