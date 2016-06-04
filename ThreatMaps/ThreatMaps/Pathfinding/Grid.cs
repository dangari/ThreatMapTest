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
        public string prevSquareID; 




        public int CompareTo(object obj)
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

        public static bool operator !=(Square a, Square b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return false;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return true;
            }

            return a.realPos == b.realPos;
        }

        public override int GetHashCode()
        {
            return realPos.GetHashCode();
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
                    {
                        Square s = grid[squarePos(x, y)];
                        if (!s.occupied)
                            neighbors.Add(s);
                    }
                        
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

        /// <summary>
        /// Returns true when wall gets removed
        /// </summary>
        public bool setRemWall(Point p)
        {
            bool b = grid[squarePos(p.X, p.Y)].occupied;
            grid[squarePos(p.X, p.Y)].occupied = !b;
            return b;
        }


        public List<Point> generateRandomWalls(int cycles)
        {
            
            //resets the walls
            for (int i = 0; i < grid.Length; i++)
            {
                grid[i].occupied = false;
            }

            int baseCount = (int)Math.Round(grid.Length  * 0.05, 0);
            Random r = new Random();
            List<Point> walls = new List<Point>();

            for (int i = 0; i < cycles; ++i)
            {
                for(int j = 0; j < baseCount; ++j)
                {
                    int x = r.Next(0, width - 1);
                    int y = r.Next(0, height - 1);
                    Point p = new Point(x, y);
                    if(!getSqaure(p).occupied)
                    {
                        grid[squarePos(x, y)].occupied = true;
                        walls.Add(p);
                    }
                    else
                    {
                        --j;
                    }                    
                }
            }

            return walls;
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
