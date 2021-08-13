using Helio.Events;
using Helio.Graphics;
using Helio.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

namespace Helio.UI
{
    public class UICanvas : IScreen
    {
        //private UIElement _element;

        public UICanvas()
        {
          //  _element = element;
        }

        public virtual void Init()
        {
        }

        public virtual void LoadContent(ContentManager contentManager)
        {
        }

        public virtual bool OnEvent(Event ev)
        {
            return true;
        }

        public virtual void Start()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(GameTime gameTime, Renderer renderer)
        {
/*            foreach (UIElement element in _elements)
            {
                element.Draw(gameTime, renderer);
            }*/
        }
    }
}
