using Helio.Actors;
using Helio.Core;
using Helio.Events;
using Microsoft.Xna.Framework;

namespace Helio.Box.Logics.Events
{
    public class TerrainLoaded : Event
    {
        public Entity id;
        public Rectangle rect;
        public int width;
        public int[] tiles;

        public TerrainLoaded(Entity id, Rectangle rect, int width, int[] tiles)
        {
            this.id = id;
            this.rect = rect;
            this.width = width;
            this.tiles = tiles;
        }
    }
}
