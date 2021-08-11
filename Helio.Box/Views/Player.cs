using Helio.Box.Systems;
using Helio.Core;

namespace Helio.Box.Views
{
    public class Player : HumanView
    {
        public Player()
        {
            AddScreen(new Render());

            AddSystem(new Sound());
            AddSystem(new PlayerControl());
        }
    }
}
