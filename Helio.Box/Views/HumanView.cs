using Helio.Box.Systems;
using Helio.Core;

namespace Helio.Box.Views
{
    public class HumanView : View
    {
        public HumanView()
        {
            _systems.Add(new Render());
            _systems.Add(new Sound());
            _systems.Add(new PlayerControl());
        }
    }
}
