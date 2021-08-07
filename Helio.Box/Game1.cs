
// nice to see
// Two bit: https://www.youtube.com/channel/UCsCBEU7sWvEMlTzP3jE0olg/videos
// Kyle Schaub: https://www.youtube.com/watch?v=UbsIYm0mQ3Q
// Kodbold: https://www.youtube.com/watch?v=xFlAmQL4FJY
// Grashadows: https://www.youtube.com/watch?v=AF5YMfrIkuk
// AdamCYounis: https://www.youtube.com/channel/UC08QfQDLAd9D7aYPFgBUIng

using Helio.Box.Logics;
using Helio.Box.Views;

namespace Helio.Box
{
    public class Game1 : App
    {
        protected override void Init()
        {
            gameLogic = new GameLogic();
            views.Add(new HumanView());
        }
    }
}
