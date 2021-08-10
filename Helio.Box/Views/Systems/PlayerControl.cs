using Helio.Box.Logics.Events;
using Helio.Box.Logics.Systems;
using Helio.Box.Views.Events;
using Helio.Core;
using Helio.Events;
using Helio.Inputs;

namespace Helio.Box.Systems
{
    public class PlayerControl : GameSystem
    {
        private Entity _player;
        
        public override void Init()
        {
            EventManager.Instance.AddListener(KeyboardPress, typeof(KeyboardPress));
            EventManager.Instance.AddListener(RegisterPlayerOnCreation, typeof(EntityCreated));
        }

        public void KeyboardPress(Event ev)
        {
            KeyboardPress e = (KeyboardPress)ev;

            switch (e.key)
            {
                case KeyboardKeys.D:
                    EventManager.Instance.QueueEvent(new RequestPlayerMove(_player, PlayerMoveDirection.Right));
                    break;

                case KeyboardKeys.Q:
                    EventManager.Instance.QueueEvent(new RequestPlayerMove(_player, PlayerMoveDirection.Left));
                    break;

                case KeyboardKeys.Z:
                    EventManager.Instance.QueueEvent(new RequestPlayerMove(_player, PlayerMoveDirection.Up));
                    break;

                case KeyboardKeys.S:
                    EventManager.Instance.QueueEvent(new RequestPlayerMove(_player, PlayerMoveDirection.Down));
                    break;

                default:
                    break;
            }
        }

        public void RegisterPlayerOnCreation(Event ev)
        {
            EntityCreated e = (EntityCreated)ev;

            if (e.type == EntityType.Player)
            {
                _player = e.id;
            }
        }
    }
}
