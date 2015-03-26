using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelCreator.Environment
{
    class Tile
    {
        public bool isUsed;
        public int X;
        public int Y;
        public int Height;
        public int Width;
        public bool markTile;
        public Tile(int x,int y)
        {
            this.X = x;
            this.Y = y;
            this.isUsed = true;
            this.markTile = false;
        }
    }
}
