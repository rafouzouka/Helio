using Helio.Graphics;
using Helio.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace Helio.Box.Views.Screens
{
    public class PlayerHUD : UICanvas, IDebugRenderable
    {
        private SpriteFont _font;
        public double fps = 0f;

        public override void Init()
        {
        }

        public override void LoadContent(ContentManager contentManager)
        {
            _font = contentManager.Load<SpriteFont>("fonts/Aria");

            SetUIElement(
                new Column(
                    mainAxisAlignement: MainAxisAlignement.End,
                    crossAxisAlignement: CrossAxisAlignement.Center,
                    childs: new List<UIElement> {
                        new Container(Color.AliceBlue, 100, 100),
                        new Container(Color.Chocolate, 200, 150),
                    }
                )
            );
        }

        /*
         * new Row(
                    mainAxisAlignement: MainAxisAlignement.Center,
                    crossAxisAlignement: CrossAxisAlignement.Start,
                    childs: new List<UIElement> {
                        new Container(Color.Aquamarine, 100, 100),
                        new Container(Color.Orange, 200, 200),
                        new Container(Color.Pink, 400, 400),
                        new TextButton(Color.Green, onPressed: OnButtonPressed)
                    }
                )
         */

        private void OnButtonPressed()
        {
            Debug.WriteLine("The button as been pressed!!");
        }

        public void DebugDraw(GameTime gameTime, Renderer renderer)
        {
            if (gameTime.TotalGameTime.Ticks % 100 == 0)
            {
                fps = 1.0 / gameTime.ElapsedGameTime.TotalSeconds;
            }
            renderer.DrawText(_font, $"{(int)fps} FPS", new Vector2(10, 10), Color.White);
        }
    }
}
