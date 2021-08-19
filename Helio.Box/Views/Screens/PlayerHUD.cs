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
                new Row(new List<UIElement>{
                        new Container(Color.Orange, width: 1280/2),
                        new Column(new List<UIElement> {
                            new Container(Color.CadetBlue, 100, 100),
                            new TextButton(Color.Green, OnButtonPressed)
                        }),
                    }
                )
            );
        }

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
