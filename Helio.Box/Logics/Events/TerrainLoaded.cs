using Helio.Actors;
using Helio.Core;
using Helio.Events;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Helio.Box.Logics.Events
{
    public class TerrainLoaded : Event
    {
        public Entity id;
        public Rectangle renderableRect;
        public int width;
        public int[] tiles;
        public List<Rectangle> colliders;

        public TerrainLoaded(Entity id, int width, int[] tiles, Rectangle renderableRect, List<Rectangle> colliders)
        {
            this.id = id;
            this.renderableRect = renderableRect;
            this.width = width;
            this.tiles = tiles;
            this.colliders = colliders;
        }
    }
}
