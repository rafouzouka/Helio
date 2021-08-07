using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Helio.Actors;
using Helio.Components;
using Helio.Core;
using System.Diagnostics;

namespace Helio.Graphics
{
    public class SpriteComponent : Component, IRenderable
    {
        private Texture2D _texture;
        private TransformComponent _transform;
        private Rectangle _spriteRect;

        public SpriteComponent(Texture2D texture)
        {
            _texture = texture;
            _transform = null;
            _spriteRect = new Rectangle(0, 0, _texture.Width, _texture.Height);
        }

        public override void Start()
        {
            _transform = owner.GetComponent<TransformComponent>();
        }

        public override void Update(GameTime gameTime)
        {
            /*
            _spriteRect.X = _transform.position.x;
            _spriteRect.Y = _transform.position.y;*/
        }

        public void Draw(GameTime gameTime, Renderer renderer)
        {
            renderer.Draw(_texture, _spriteRect, null);
        }
    }
}
