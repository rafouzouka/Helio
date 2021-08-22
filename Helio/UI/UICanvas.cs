using Helio.Graphics;
using Helio.Inputs;
using Helio.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Helio.UI
{
    public class UICanvas : IScreen
    {
        private UIElement _child;

        public void SetUIElement(UIElement element)
        {
            _child = element;
        }

        public virtual void Init()
        {
        }

        public virtual void LoadContent(ContentManager contentManager)
        {
        }

        public virtual bool OnInput(InputEvent input)
        {
            return _child.OnInput(input);
        }

        public virtual void Start()
        {
            _child.SetConstraints(new Constraints(1280/2, 1280/2, 720/2, 720/2));
            _child.SetPosition(Vector2.Zero);
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public void Draw(GameTime gameTime, Renderer renderer)
        {
            _child.Draw(gameTime, renderer);
        }
    }
}
