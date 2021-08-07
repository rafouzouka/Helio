using Helio.Actors;
using Helio.Box.Logics.Events;
using Helio.Box.Views.Events;
using Helio.Components;
using Helio.Core;
using Helio.Events;
using Microsoft.Xna.Framework.Content;
using System;

namespace Helio.Box.Logics.Systems
{
    public enum EntityType
    {
        Player,
        Block,
        Enemy,
    }

    public class Entities : GameSystem
    {
        public override void Init()
        {
            EventManager.Instance.AddListener(RequestPlayerMove, typeof(RequestPlayerMove));
        }

        public override void LoadContent(ContentManager contentManager)
        {
            Actor player = ActorFactory.CreateEmptyActor();
            TransformComponent tran = new TransformComponent();
            tran.position.X = 100;
            tran.position.Y = 100;
            player.AddComponent(tran);
            _actors.Add(player.GetId(), player);

            EventManager.Instance.QueueEvent(new EntityCreated(player.GetId(), EntityType.Player, tran.position));
        }

        public void RequestPlayerMove(Event ev)
        {
            RequestPlayerMove e = (RequestPlayerMove)ev;
            TransformComponent t = _actors[e.id].GetComponent<TransformComponent>();

            switch (e.direction)
            {
                case PlayerMoveDirection.Right:
                    t.position.X += 10;
                    break;

                case PlayerMoveDirection.Left:
                    t.position.X -= 10;
                    break;

                case PlayerMoveDirection.Up:
                    t.position.Y -= 10;
                    break;

                case PlayerMoveDirection.Down:
                    t.position.Y += 10;
                    break;

                default:
                    throw new Exception("Must create case for this enum.");
            }
            EventManager.Instance.QueueEvent(new EntityMoved(e.id, t.position));
        }
    }
}
