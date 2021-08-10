using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace Helio.Graphics
{
    public class TileMap : IRenderableItem
    {
        private List<Tile> _tiles;
        private Texture2D _tileSet;
        private int _tileColumnNum;
        private int _tileWidth;
        private int _tileHeight;

        public TileMap(Texture2D tileSet, int tileColumnNum, int tileRownNum, List<Tile> tiles)
        {
            _tileSet = tileSet;

            _tileColumnNum = tileColumnNum;

            _tileWidth = tileSet.Width / tileColumnNum;
            _tileHeight = tileSet.Height / tileRownNum;

            _tiles = tiles;
        }

        public void Move(Vector2 newPosition)
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime, Renderer renderer)
        {
            Rectangle dst = new Rectangle(0, _tileHeight, _tileWidth, _tileHeight);
            Rectangle src = new Rectangle(0, 0, _tileWidth, _tileHeight);

            foreach (Tile tile in _tiles)
            {
                if (tile.id < 0)
                {
                    continue;
                }

                src.Y = (tile.id / _tileColumnNum) * _tileHeight;
                src.X = (tile.id % _tileColumnNum) * _tileWidth;

                dst.X = tile.x * _tileWidth;
                dst.Y = tile.y * _tileHeight;

                renderer.Draw(_tileSet, dst, src);
            }
        }
    }
}
