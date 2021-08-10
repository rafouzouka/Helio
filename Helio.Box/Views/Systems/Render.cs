using Helio.Actors;
using Helio.Box.Logics.Events;
using Helio.Box.Logics.Systems;
using Helio.Events;
using Helio.Graphics;
using Helio.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TiledCS;

namespace Helio.Box.Systems
{
    public class Render : RenderEngine
    {
        /*private Texture2D _playerTexture;
        private Texture2D _enemyTexture;
        private Texture2D _blockTexture;
        */

        private Texture2D _tileSet;

        public override void Init()
        {
            //    EventManager.Instance.AddListener(EntityCreated, typeof(EntityCreated));
            //    EventManager.Instance.AddListener(ActorPhysicMoved, typeof(ActorPhysicMoved));

            Debug.WriteLine(20 / 8);
            Debug.WriteLine(20 % 8);
        }

        public override void LoadContent(ContentManager contentManager)
        {
            _tileSet = contentManager.Load<Texture2D>("tile/tileset");

            TiledMap tiledMap = new TiledMap("Content/tile/testmap.tmx");
            List<Tile> map = new List<Tile>();

            foreach (TiledLayer layer in tiledMap.Layers)
            {

                for (int i = 0; i < layer.data.Length; i++)
                {
                    map.Add(new Tile(layer.data[i] - 1, i % layer.width, i / layer.width));
                }
            }

            AddRenderableItem(new ActorId(10), new TileMap(_tileSet, 8, 8, map));
        }

        public void EntityCreated(Event ev)
        {
/*            EntityCreated e = (EntityCreated)ev;

            switch (e.type)
            {
                case EntityType.Player:
                    Sprite sprite = new Sprite(_playerTexture, e.rect);
                    AddSprite(e.id, sprite);
                    break;

                case EntityType.Enemy:
                    Sprite enemySprite = new Sprite(_enemyTexture, e.rect);
                    AddSprite(e.id, enemySprite);
                    break;

                case EntityType.Block:
                    Sprite blockSprite = new Sprite(_blockTexture, e.rect);
                    AddSprite(e.id, blockSprite);
                    break;

                default:
                    throw new Exception("The Type of the entity doesn't match with the renderer.");
            }*/
        }

        public void ActorPhysicMoved(Event ev)
        {
/*            ActorPhysicMoved e = (ActorPhysicMoved)ev;
            MoveSprite(e.id, e.newPosition);*/
        }
    }
}
