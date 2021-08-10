using System;
using System.Collections.Generic;
using System.Text;

namespace Helio.Graphics
{
    public struct Tile
    {
        public int id;
        public int x;
        public int y;

        public Tile(int id, int x, int y)
        {
            this.id = id;
            this.x = x;
            this.y = y;
        }
    }
}
