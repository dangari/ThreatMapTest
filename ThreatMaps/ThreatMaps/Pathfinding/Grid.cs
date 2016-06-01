using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ThreatMaps.Pathfinding
{

    struct Square : IComparable
    {
        public Point realPos;
        public int Threat;
        public bool occupied;
        public int cost;
        public Square prevSquare; 

        int IComparable.CompareTo(object obj)
        {
            Square s = (Square)obj;
            return cost.CompareTo(s.cost);
        }


        public override bool Equals(object obj)
        {
            return this == (Square)obj;
        }

        public static bool operator ==(Square a, Square b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            return a.realPos == b.realPos;
        }
    }

    class Grid
    {

        private Square[] grid;
        private int width;
        private int height;

        private Point startPoint;
        private Point endPoint;

      

        public Grid(int x, int y)
        {
            this.grid = new Square[x * y];
            this.width = x;
            this.height = y;
            initGrid();
        }

        public int squarePos(int x, int y)
        {
           return y * width + x;
        }

        public List<Square> getNeighbors(Point p)
        {
            List<Square> neighbors = new List<Square>();
            int minX = Math.Max(p.X - 1, 0);
            int maxX = Math.Min(p.X + 1, width - 1);
            int minY = Math.Max(p.Y - 1, 0);
            int maxY = Math.Min(p.Y + 1, height - 1);

            for (int x = minX; x <= maxX; ++x)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    if (new Point(x, y) != p)
                        neighbors.Add(grid[squarePos(x, y)]);
                }
            }

            return neighbors;
        }

        public Square getSqaure(Point p)
        {
            return grid[squarePos(p.X, p.Y)];
        }

        private void initGrid()
        {
            for(int y = 0; y  < height; ++y)
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
