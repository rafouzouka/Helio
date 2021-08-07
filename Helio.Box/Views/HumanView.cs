using Helio.Box.Systems;
using Helio.Core;

namespace Helio.Box.Views
{
    public class HumanView : View
    {
        public HumanView()
        {
            _systems.Add(new RenderSystem());
            _systems.Add(new SoundSystem());
            _systems.Add(new PlayerControlSystem());
        }
    }
}
