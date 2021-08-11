using Helio.Box.Systems;
using Helio.Core;

namespace Helio.Box.Views
{
    public class PlayerView : HumanView
    {
        public PlayerView()
        {
            AddScreen(new Render());

            AddSystem(new Sound());
            AddSystem(new PlayerControl());
        }
    }
}
