using Helio.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Helio.Box.Views.Screens
{
    public class PlayerHUD : UICanvas
    {
        public PlayerHUD() : base()
        {
        }

        public override void LoadContent(ContentManager contentManager)
        {
            SpriteFont aria = contentManager.Load<SpriteFont>("fonts/Aria");
            //AddUIElement(new Text(aria, "Salut les gens", Color.Red));
        }
    }
}
