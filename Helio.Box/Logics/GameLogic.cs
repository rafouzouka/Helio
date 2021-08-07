using Helio.Actors;
using Helio.Box.Events;
using Helio.Components;
using Helio.Core;
using Helio.Events;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Helio.Box.Logics
{
    public class GameLogic : ILogic
    {
        Dictionary<ActorId, Actor> actors;

        public GameLogic()
        {
            actors = new Dictionary<ActorId, Actor>();
        }

        public void Init()
        {
            EventManager.Instance.AddListener(RequestPlayerMove, typeof(RequestPlayerMove));
        }

        public void Start()
        {
            Actor actor = ActorFactory.CreateEmptyActor();
            actor.AddComponent(new TransformComponent());
            actors.Add(actor.GetId(), actor);
            EventManager.Instance.QueueEvent(new CreatePlayerActor(actor.GetId(), new Vector3(0, 0, 0)));
        }

        public void Update(GameTime gameTime)
        {

        }

        public void RequestPlayerMove(Event e)
        {
            RequestPlayerMove ev = (RequestPlayerMove)e;
            ActorId player = new ActorId(0);
            TransformComponent tc = actors[player].GetComponent<TransformComponent>();

            if (ev.direction == PlayerMoveDirection.Right)
            {
                tc.position.X += 10;
                EventManager.Instance.QueueEvent(new PlayerMoved(new ActorId(0), tc.position));
            }
        }
    }
}
