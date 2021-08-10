using Microsoft.Xna.Framework.Content;

using Helio.Core;
using Helio.Actors;
using TiledCS;
using Helio.Events;
using Helio.Box.Logics.Events;
using Microsoft.Xna.Framework;

namespace Helio.Box.Logics.Systems
{
    public enum EntityType
    {
        Player,
        Block,
        Enemy,
    }

    public class Loading : GameSystem
    {
        public override void Init()
        {
            //EventManager.Instance.AddListener(RequestPlayerMove, typeof(RequestPlayerMove));
        }

        public override void LoadContent(ContentManager contentManager)
        {
            Entity terrain = EntityCreator.Create();
            TiledMap tiledMap = new TiledMap("Content/tile/testmap.tmx");
            Rectangle rect = new Rectangle(0, 16 * 16, 26 * 16, 4 * 16);
            EventManager.Instance.QueueEvent(new TerrainLoaded(terrain, rect, tiledMap.Layers[0].width, tiledMap.Layers[0].data));

            Entity player = EntityCreator.Create();
            Rectangle PlayerRect = new Rectangle(10, 40, 16, 32);
            EventManager.Instance.QueueEvent(new EntityCreated(player, EntityType.Player, PlayerRect));

            Entity enemy = EntityCreator.Create();
            Rectangle enemyRect = new Rectangle(40, 40, 16, 32);
            EventManager.Instance.QueueEvent(new EntityCreated(enemy, EntityType.Enemy, enemyRect));
        }
    }
}
