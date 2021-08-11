using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Helio.Core
{
    public interface ISystem
    {
        void Init();

        void LoadContent(ContentManager contentManager);

        void Start();

        void Update(GameTime gameTime);
    }
}
