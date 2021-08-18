using Helio.Box.Logics.Events;
using Helio.Box.Logics.Systems;
using Helio.Core;
using Helio.Events;
using Helio.Graphics;
using Helio.Physics;
using Helio.Physics.Events;
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
        private Dictionary<Entity, (Rectangle, Color)> _entityCollidersDebug;

        public Render() : base()
        {
            _entityCollidersDebug = new Dictionary<Entity, (Rectangle, Color)>();
        }

        public override void Init()
        {
            EventManager.Instance.AddListener(EntityCreated, typeof(EntityCreated));
            EventManager.Instance.AddListener(EntityPhysicMoved, typeof(EntityPhysicMoved));
            EventManager.Instance.AddListener(LevelLoaded, typeof(LevelLoaded));
            EventManager.Instance.AddListener(EntityCollided, typeof(EntityCollided));
        }

        public override void LoadContent(ContentManager contentManager)
        {
            _tileSet = contentManager.Load<Texture2D>("tile/tileset");
            _playerTexture = contentManager.Load<Texture2D>("player1");
            _enemyTexture = contentManager.Load<Texture2D>("enemy1");
        }

        public void EntityCollided(Event ev)
        {
            EntityCollided e = (EntityCollided)ev;

            _entityCollidersDebug[e.a] = (_entityCollidersDebug[e.a].Item1, Color.Red);
            _entityCollidersDebug[e.b] = (_entityCollidersDebug[e.b].Item1, Color.Red);
        }

        public void LevelLoaded(Event ev)
        {
            LevelLoaded e = (LevelLoaded)ev;

            List<Tile> tiles = new List<Tile>();
            foreach (KeyValuePair<Entity, Tile> tile in e.tiles)
            {
                tiles.Add(tile.Value);
            }
            AddRenderableItem(e.terrain, new TileMap(_tileSet, 8, 8, tiles));

            foreach (KeyValuePair<Entity, Rectangle> tile in e.tileColliders)
            {
                _entityCollidersDebug.Add(tile.Key, (tile.Value, Color.Turquoise));
            }
        }

        public void EntityCreated(Event ev)
        {
            EntityCreated e = (EntityCreated)ev;

            _entityCollidersDebug.Add(e.id, (e.collider, Color.Turquoise));

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
            _entityCollidersDebug[e.id] = (e.collider, Color.Turquoise);
        }

        public void DebugDraw(GameTime gameTime, Renderer renderer)
        {
            foreach (KeyValuePair<Entity, (Rectangle, Color)> keyValue in _entityCollidersDebug)
            {
                renderer.DrawRect(keyValue.Value.Item1, keyValue.Value.Item2);
            }
        }
    }
}
