using Helio.Box.Logics.Events;
using Helio.Box.Logics.Systems;
using Helio.Box.Views.Events;
using Helio.Core;
using Helio.Events;
using Helio.Graphics;
using Helio.Inputs;
using Helio.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Helio.Box.Views.Screens
{
    public class PlayerControl : IScreen
    {
        private Entity _player;

        public void Draw(GameTime gameTime, Renderer renderer)
        {
        }

        public void Init()
        {
            EventManager.Instance.AddListener(RegisterPlayerEntity, typeof(EntityCreated));
        }

        public void LoadContent(ContentManager contentManager)
        {
        }

        public bool OnInput(InputEvent input)
        {
            if (input is KeyboardPressed keyboardPressed)
            {
                switch (keyboardPressed.key)
                {
                    case KeyboardKeys.Space:
                        EventManager.Instance.QueueEvent(new RequestPlayerMove(_player, PlayerMovementType.Jump));
                        break;

                    default:
                        return true;
                }
            }

            return true;
        }

        public void RegisterPlayerEntity(Event ev)
        {
            EntityCreated e = (EntityCreated)ev;

            if (e.type == EntityType.Player)
            {
                _player = e.id;
            }
        }

        public void Start()
        {
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
