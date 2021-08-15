using Helio.Actors;
using Helio.Core;
using Helio.Events;
using Helio.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Helio.Box.Logics.Events
{
    public class TerrainLoaded : Event
    {
        public Entity terrain;

        public int width;
        public Rectangle renderableRect;
        public List<(Entity, Tile, Rectangle)> map;

        public TerrainLoaded(Entity terrain, int width, Rectangle renderableRect, List<(Entity, Tile, Rectangle)> map)
        {
            this.terrain = terrain;
            this.width = width;
            this.renderableRect = renderableRect;
            this.map = map;
        }
    }
}
