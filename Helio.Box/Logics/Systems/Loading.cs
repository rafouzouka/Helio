using Microsoft.Xna.Framework.Content;

using Helio.Core;
using Helio.Actors;
using TiledCS;
using Helio.Events;
using Helio.Box.Logics.Events;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using Helio.Graphics;
using System;

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

        private void LoadTerrain()
        {
            Entity terrain = EntityCreator.Create();
            TiledMap tiledMap = new TiledMap("Content/tile/testmap.tmx");
            Rectangle renderableRect = new Rectangle(0, 16 * 16, 26 * 16, 4 * 16);

            TiledLayer mapLayer = tiledMap.Layers[0];
            List<(Entity, Tile, Rectangle)> map = new List<(Entity, Tile, Rectangle)>();

            for (int i = 0; i < mapLayer.data.Length; i++)
            {
                int tileId = mapLayer.data[i] - 1;
                if (tileId < 0)
                {
                    continue;
                }
                //if (tileId == 0 || tileId == 1 || tileId == 2)

                Entity tileEntity = EntityCreator.Create();
                Tile newTile = new Tile(tileId, i % mapLayer.width, i / mapLayer.width);
                Rectangle tileCollider = new Rectangle(newTile.x * 16, newTile.y * 16, 16, 16);
                Debug.WriteLine($"tileCollider: x: {tileCollider.X}, y: {tileCollider.Y}");
                map.Add((tileEntity, newTile, tileCollider));
            }
     
            EventManager.Instance.QueueEvent(new TerrainLoaded(terrain, tiledMap.Layers[0].width, renderableRect, map));
        }

        public void LoadContent(ContentManager contentManager)
        {
            LoadTerrain();

            Entity player = EntityCreator.Create();
            Rectangle PlayerRect = new Rectangle(40, 50, 16, 32);
            EventManager.Instance.QueueEvent(new EntityCreated(player, EntityType.Player, PlayerRect, PlayerRect));

            /*Entity enemy = EntityCreator.Create();
            Rectangle enemyRect = new Rectangle(100, 50, 16, 32);
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
