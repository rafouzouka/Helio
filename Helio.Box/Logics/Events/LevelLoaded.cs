using Helio.Actors;
using Helio.Core;
using Helio.Events;
using Helio.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Helio.Box.Logics.Events
{
    public class LevelLoaded : Event
    {
        public Entity terrain;

        public int width;
        public Rectangle renderableRect;
        public Dictionary<Entity, Tile> tiles;
        public Dictionary<Entity, Rectangle> tileColliders;

        public LevelLoaded(Entity terrain, int width, Rectangle renderableRect, Dictionary<Entity, Tile> tiles, Dictionary<Entity, Rectangle> tileColliders)
        {
            this.terrain = terrain;
            this.width = width;
            this.renderableRect = renderableRect;
            this.tiles = tiles;
            this.tileColliders = tileColliders;
        }
    }
}
