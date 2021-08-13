using Helio.Graphics;
using Helio.Inputs;
using Helio.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

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

        public virtual bool OnInput(InputEvent input)
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
