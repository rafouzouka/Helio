using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Graphics
{
    public class Carre : IRenderableItem
    {
        private Rectangle _rect;
        private Color _color;

        public Carre(Rectangle rect, Color color)
        {
            _rect = rect;
            _color = color;
        }

        public void Draw(GameTime gameTime, Renderer renderer)
        {
            //renderer.DrawRectangleFill(_rect, _color);
        }

        public void Move(Vector2 newPosition)
        {
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
