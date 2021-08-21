using Helio.Actors;
using Helio.Core;
using Helio.Events;
using Helio.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Helio.Box.Logics.Events
{
    public class LevelTilesLoaded : Event
    {
        public Entity id;

        public int tileMapWidth;
        public int tileMapHeight;

        public int[] tiles;

        public LevelTilesLoaded(Entity id, int tileMapWidth, int tileMapHeight, int[] tiles)
        {
            this.id = id;

            this.tileMapWidth = tileMapWidth;
            this.tileMapHeight = tileMapHeight;
            
            this.tiles = tiles;
        }
    }
}
