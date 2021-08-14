using Microsoft.Xna.Framework.Content;

using Helio.Core;
using Helio.Actors;
using TiledCS;
using Helio.Events;
using Helio.Box.Logics.Events;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Helio.Box.Logics.Systems
{
    public enum EntityType
    {
        Player,
        Block,
        Enemy,
    }

    public class Loading : ISystem
    {
        public void Init()
        {
        }

        public void LoadContent(ContentManager contentManager)
        {
            Entity terrain = EntityCreator.Create();
            TiledMap tiledMap = new TiledMap("Content/tile/testmap.tmx");
            Rectangle renderableRect = new Rectangle(0, 16 * 16, 26 * 16, 4 * 16);
            List<Rectangle> colliders = new List<Rectangle> {
                new Rectangle(0, 240, 1280/2, 100)
            };
            EventManager.Instance.QueueEvent(new TerrainLoaded(terrain, tiledMap.Layers[0].width, tiledMap.Layers[0].data, renderableRect, colliders));

            Entity player = EntityCreator.Create();
            Rectangle PlayerRect = new Rectangle(40, 50, 16, 32);
            EventManager.Instance.QueueEvent(new EntityCreated(player, EntityType.Player, PlayerRect, PlayerRect));

/*            Entity enemy = EntityCreator.Create();
            Rectangle enemyRect = new Rectangle(40, 40, 16, 32);
            EventManager.Instance.QueueEvent(new EntityCreated(enemy, EntityType.Enemy, enemyRect, enemyRect));*/
        }

        public void Start()
        {
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
