using Microsoft.Xna.Framework.Content;

using Helio.Core;
using TiledCS;
using Helio.Events;
using Helio.Box.Logics.Events;
using Microsoft.Xna.Framework;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using Helio.Graphics;

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

        private void LoadTileMap(TiledLayer tilesLayer)
        {
            Entity tilesMapId = EntityCreator.Create();
            EventManager.Instance.QueueEvent(
                new LevelTilesLoaded(
                    id: tilesMapId,
                    tileMapWidth: tilesLayer.width,
                    tileMapHeight: tilesLayer.height,
                    tiles: tilesLayer.data
                )
            );
        }

        private void LoadMapColliders(TiledLayer tilesLayer)
        {
            Dictionary<Entity, Rectangle> colliders = new Dictionary<Entity, Rectangle>();
            
            foreach(TiledObject obj in tilesLayer.objects)
            {
                colliders.Add(EntityCreator.Create(), new Rectangle((int)obj.x, (int)obj.y, (int)obj.width, (int)obj.height));
            }

            EventManager.Instance.QueueEvent(new MapCollidersLoaded(colliders));
        }

        private void PlayerSpawn(TiledLayer tilesLayer)
        {
            Rectangle renderable = new Rectangle((int)tilesLayer.objects[0].x, (int)tilesLayer.objects[0].y, 32, 32);

            EventManager.Instance.QueueEvent(new EntityCreated(
                EntityCreator.Create(),
                EntityType.Player,
                renderable,
                renderable
            ));
        }

        private void EnemiesSpawn(TiledLayer tilesLayer)
        {
            foreach (TiledObject enemy in tilesLayer.objects)
            {
                Rectangle renderable = new Rectangle((int)enemy.x, (int)enemy.y, 32, 36);

                EventManager.Instance.QueueEvent(new EntityCreated(
                    EntityCreator.Create(),
                    EntityType.Enemy,
                    renderable,
                    renderable
                ));
            }
        }

        private void LoadLevel()
        {
            TiledMap tiledMap = new TiledMap("Content/tiles/tilemap.tmx");

            foreach (TiledLayer layer in tiledMap.Layers)
            {
                switch (layer.name)
                {
                    case "Foreground":
                        LoadTileMap(layer);
                        break;

                    case "Background":
                        LoadTileMap(layer);
                        break;

                    case "Colliders":
                        LoadMapColliders(layer);
                        break;

                    case "Player":
                        PlayerSpawn(layer);
                        break;

                    case "Enemies":
                        EnemiesSpawn(layer);
                        break;

                    default:
                        Debug.WriteLine(layer.name);
                        throw new Exception("Layer must be handled.");
                }
            }
        }

        public void LoadContent(ContentManager contentManager)
        {
            LoadLevel();

/*            Entity player = EntityCreator.Create();
            Rectangle PlayerRect = new Rectangle(40, 50, 24, 36);
            EventManager.Instance.QueueEvent(new EntityCreated(player, EntityType.Player, PlayerRect, PlayerRect));*/
        }

        public void Start()
        {
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
