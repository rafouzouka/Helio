using Helio.Box.Systems;
using Helio.Box.Views.Screens;
using Helio.Core;

namespace Helio.Box.Views
{
    public class PlayerView : HumanView
    {
        public PlayerView()
        {
            AddScreen(new Render());
            AddScreen(new PlayerHUD());

            AddSystem(new Musics());
        }
    }
}
