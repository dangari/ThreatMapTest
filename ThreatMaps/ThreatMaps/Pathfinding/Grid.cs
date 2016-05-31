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
        public Point realPos;
        public int Threat;
        public bool occupied;
        public int cost;
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
            initGrid();
        }

        public int squarePos(int x, int y)
        {
           return y * width + x;
        }

        public List<Square> getNeighbors(Point p)
        {
            List<Square> neighbors = new List<Square>();
            //left neighbor
            if(p.X > 0)
            {
                neighbors.Add(grid[squarePos(p.X -1, p.Y)]);
            }
            //right neighbor
            if(p.X < width - 1)
            {
                neighbors.Add(grid[squarePos(p.X + 1, p.Y)]);
            }
            //up neighbor
            if(p.Y > 0)
            {
                neighbors.Add(grid[squarePos(p.X, p.Y - 1)]);
            }
            //down neighbor
            if (p.Y < length - 1)
            {
                neighbors.Add(grid[squarePos(p.X, p.Y + 1)]);
            }
            //left up neighbor
            if(p.X > 0 && p.Y > 0)
            {
                neighbors.Add(grid[squarePos(p.X - 1, p.Y - 1)]);
            }
            //right up neighbor
            if (p.X < width - 1 && p.Y > 0)
            {
                neighbors.Add(grid[squarePos(p.X + 1, p.Y - 1)]);
            }
            // left down neighbor
            if (p.X > 0 && p.Y < length - 1)
            {
                neighbors.Add(grid[squarePos(p.X - 1, p.Y + 1)]);
            }
            // right down neighbor
            if (p.X < width - 1 && p.Y < length - 1)
            {
                neighbors.Add(grid[squarePos(p.X + 1, p.Y + 1)]);
            }
            return neighbors;
        }

        private void initGrid()
        {
            for(int y = 0; y  < length; ++y)
            {
                for(int x = 0; x < width; ++x)
                {
                    grid[squarePos(x, y)].realPos = new Point(x, y);
                }
            }
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
