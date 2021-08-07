using Microsoft.Xna.Framework;

namespace Helio.Core
{
    public interface ILogic
    {
        void Init();

        void Start();

        void Update(GameTime gameTime);
    }
}
