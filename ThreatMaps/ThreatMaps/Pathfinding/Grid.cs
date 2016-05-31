using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ThreatMaps.Pathfinding
{

    struct Square
    {
        public int Threat;
        public bool occupied;
    }

    class Grid
    {

        private Square[] grid;
        private int width;
        private int length;

        private Point startPoint;
        private Point endPoint;

      

        public Grid(int x, int y)
        {
            this.grid = new Square[x * y];
            this.width = x;
            this.length = y;
        }

        public Square getSquare(int x, int y)
        {
            int pos = y * width + x;
            return grid[pos];
        }






        public Point StartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }

        public Point EndPoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }
    }
}
