﻿using Microsoft.Xna.Framework.Content;

using Helio.Core;

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
            //EventManager.Instance.AddListener(RequestPlayerMove, typeof(RequestPlayerMove));
        }

        public override void LoadContent(ContentManager contentManager)
        {
            /*Actor player = ActorFactory.CreateEmptyActor();
            Rectangle PlayerRect = new Rectangle(100, 400, 80, 80);
            EventManager.Instance.QueueEvent(new EntityCreated(player.GetId(), EntityType.Player, PlayerRect));

            Actor enemy = ActorFactory.CreateEmptyActor();
            Rectangle enemyRect = new Rectangle(400, 400, 80, 80);
            EventManager.Instance.QueueEvent(new EntityCreated(enemy.GetId(), EntityType.Enemy, enemyRect));

            Actor block = ActorFactory.CreateEmptyActor();
            Rectangle blockRect = new Rectangle(600, 400, 80, 80);
            EventManager.Instance.QueueEvent(new EntityCreated(block.GetId(), EntityType.Block, blockRect));*/
        }
    }
}
