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


        private void LoadLevel()
        {
            Entity terrain = EntityCreator.Create();
            TiledMap tiledMap = new TiledMap("Content/tile/testmap.tmx");
            Rectangle renderableRect = new Rectangle(0, 16 * 16, 26 * 16, 4 * 16);
            Dictionary<Entity, Tile> tiles = new Dictionary<Entity, Tile>();
            Dictionary<Entity, Rectangle> tileColliders = new Dictionary<Entity, Rectangle>();

            foreach (TiledLayer layer in tiledMap.Layers)
            {
                if (layer.name == "Background")
                {
                    for (int i = 0; i < layer.data.Length; i++)
                    {
                        int tileId = layer.data[i] - 1;

                        Entity tileEntity = EntityCreator.Create();
                        Tile newTile = new Tile(tileId, i % layer.width, i / layer.width);
                        tiles.Add(tileEntity, newTile);
                    }
                }
                if (layer.name == "Walls")
                {
                    for (int i = 0; i < layer.data.Length; i++)
                    {
                        int tileId = layer.data[i] - 1;

                        Entity tileEntity = EntityCreator.Create();
                        Tile newTile = new Tile(tileId, i % layer.width, i / layer.width);
                        tiles.Add(tileEntity, newTile);
                    }
                }
            }

            EventManager.Instance.QueueEvent(new LevelLoaded(terrain, tiledMap.Layers[0].width, renderableRect, tiles, tileColliders));
        }

        public void LoadContent(ContentManager contentManager)
        {
            LoadLevel();

            Entity player = EntityCreator.Create();
            Rectangle PlayerRect = new Rectangle(40, 50, 16, 32);
            EventManager.Instance.QueueEvent(new EntityCreated(player, EntityType.Player, PlayerRect, PlayerRect));
        }

        public void Start()
        {
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
