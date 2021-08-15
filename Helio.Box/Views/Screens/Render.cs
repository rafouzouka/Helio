using Helio.Box.Logics.Events;
using Helio.Box.Logics.Systems;
using Helio.Core;
using Helio.Events;
using Helio.Graphics;
using Helio.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Helio.Box.Systems
{
    public class Render : RenderEngine, IDebugRenderable
    {
        private Texture2D _playerTexture;
        private Texture2D _enemyTexture;

        private Texture2D _tileSet;
        private Dictionary<Entity, Rectangle> _entityCollidersDebug;

        public Render() : base()
        {
            _entityCollidersDebug = new Dictionary<Entity, Rectangle>();
        }

        public override void Init()
        {
            EventManager.Instance.AddListener(EntityCreated, typeof(EntityCreated));
            EventManager.Instance.AddListener(EntityPhysicMoved, typeof(EntityPhysicMoved));
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

            List<Tile> tiles = new List<Tile>();
            foreach ((Entity, Tile, Rectangle) tile in e.map)
            {
                tiles.Add(tile.Item2);
                _entityCollidersDebug.Add(tile.Item1, tile.Item3);
            }
            AddRenderableItem(e.terrain, new TileMap(_tileSet, 8, 8, tiles));
        }

        public void EntityCreated(Event ev)
        {
            EntityCreated e = (EntityCreated)ev;

            _entityCollidersDebug.Add(e.id, e.collider);

            switch (e.type)
            {
                case EntityType.Player:
                    Sprite sprite = new Sprite(_playerTexture, e.renderableRect, null);
                    AddRenderableItem(e.id, sprite);
                    break;

                case EntityType.Enemy:
                    Sprite enemySprite = new Sprite(_enemyTexture, e.renderableRect, null);
                    AddRenderableItem(e.id, enemySprite);
                    break;

                default:
                    throw new Exception("The Type of the entity doesn't match with the renderer.");
            }
        }

        public void EntityPhysicMoved(Event ev)
        {
            EntityPhysicMoved e = (EntityPhysicMoved)ev;

            MoveRenderableItem(e.id, new Vector2(e.collider.X, e.collider.Y));
            _entityCollidersDebug[e.id] = e.collider;
        }

        public void DebugDraw(GameTime gameTime, Renderer renderer)
        {
            foreach (KeyValuePair<Entity, Rectangle> keyValue in _entityCollidersDebug)
            {
                renderer.DrawRect(keyValue.Value, Color.Turquoise);
            }
        }
    }
}
