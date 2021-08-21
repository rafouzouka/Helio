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
using TiledCS;

namespace Helio.Box.Systems
{
    public class Render : RenderEngine, IDebugRenderable
    {
        private Texture2D _playerTexture;

        private TiledTileset _tileSet;
        private Texture2D _tileSetImage;

        private Dictionary<Entity, (Rectangle, Color)> _entityCollidersDebug;

        public Render() : base()
        {
            _entityCollidersDebug = new Dictionary<Entity, (Rectangle, Color)>();
        }

        public override void Init()
        {
            EventManager.Instance.AddListener(LevelTilesLoaded, typeof(LevelTilesLoaded));
            EventManager.Instance.AddListener(MapCollidersLoaded, typeof(MapCollidersLoaded));
            
            EventManager.Instance.AddListener(EntityCreated, typeof(EntityCreated));
            EventManager.Instance.AddListener(EntityPhysicMoved, typeof(EntityPhysicMoved));
            EventManager.Instance.AddListener(EntityCollided, typeof(EntityCollided));
        }

        public override void LoadContent(ContentManager contentManager)
        {
            _tileSet = new TiledTileset("Content/tile/backgroundsheet.tsx");
            _tileSetImage = contentManager.Load<Texture2D>($"tile/{_tileSet.Image.Split(".")[0]}");
            
            _playerTexture = contentManager.Load<Texture2D>("sprites/player/player1");
        }

        public void MapCollidersLoaded(Event ev)
        {
            MapCollidersLoaded e = (MapCollidersLoaded)ev;

            foreach (KeyValuePair<Entity, Rectangle> collider in e.colliders)
            {
                _entityCollidersDebug.Add(collider.Key, (collider.Value, Color.Turquoise));
            }
        }

        public void EntityCollided(Event ev)
        {
            EntityCollided e = (EntityCollided)ev;

/*            _entityCollidersDebug[e.a] = (_entityCollidersDebug[e.a].Item1, Color.Red);
            _entityCollidersDebug[e.b] = (_entityCollidersDebug[e.b].Item1, Color.Red);*/
        }

        public void LevelTilesLoaded(Event ev)
        {
            LevelTilesLoaded e = (LevelTilesLoaded)ev;
            
            List<Tile> tiles = new List<Tile>();

            for (int i = 0; i < e.tiles.Length; i++)
            {
                tiles.Add(new Tile(e.tiles[i] - 1, i % e.tileMapWidth, i / e.tileMapWidth));
            }
            
            AddRenderableItem(e.id, new TileMap(_tileSetImage, _tileSet.Columns, _tileSet.TileCount / _tileSet.Columns, tiles));
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
