using Helio.Box.Logics.Events;
using Helio.Box.Logics.Systems;
using Helio.Events;
using Helio.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Helio.Box.Systems
{
    public class Render : RenderEngine
    {
        private Texture2D _playerTexture;
        private Texture2D _enemyTexture;

        private Texture2D _tileSet;

        public override void Init()
        {
            EventManager.Instance.AddListener(EntityCreated, typeof(EntityCreated));
            EventManager.Instance.AddListener(TerrainLoaded, typeof(TerrainLoaded));
        }

        public override void LoadContent(ContentManager contentManager)
        {
            _tileSet = contentManager.Load<Texture2D>("tile/tileset");
            _playerTexture = contentManager.Load<Texture2D>("player1");
            _enemyTexture = contentManager.Load<Texture2D>("enemy1");
        }

        public void TerrainLoaded(Event ev)
        {
            TerrainLoaded e = (TerrainLoaded)ev;

            List<Tile> map = new List<Tile>();
            for (int i = 0; i < e.tiles.Length; i++)
            {
                map.Add(new Tile(e.tiles[i] - 1, i % e.width, i / e.width));
            }
            AddRenderableItem(e.id, new TileMap(_tileSet, 8, 8, map));
        }

        public void EntityCreated(Event ev)
        {
            EntityCreated e = (EntityCreated)ev;

            switch (e.type)
            {
                case EntityType.Player:
                    Sprite sprite = new Sprite(_playerTexture, e.rect, null);
                    AddRenderableItem(e.id, sprite);
                    break;

                case EntityType.Enemy:
                    Sprite enemySprite = new Sprite(_enemyTexture, e.rect, null);
                    AddRenderableItem(e.id, enemySprite);
                    break;

                default:
                    throw new Exception("The Type of the entity doesn't match with the renderer.");
            }
        }
    }
}
