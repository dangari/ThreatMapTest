using System;
using System.Collections.Generic;
using System.Drawing;

namespace ThreatMaps.Pathfinding
{

    public struct Square : IComparable
    {
        public Point RealPos { get; set; }
        public int Threat { get; set; }
        public bool Occupied { get; set; }
        public int Cost { get; set; }
        public string PrevSquareID { get; set; }

        public int CompareTo(object obj)
        {
            Square s = (Square)obj;
            return Cost.CompareTo(s.Cost);
        }

        public override bool Equals(object obj)
        {
            return this == (Square)obj;
        }

        public static bool operator ==(Square a, Square b)
        {
            return a.RealPos == b.RealPos;
        }

        public static bool operator !=(Square a, Square b)
        {
           return a.RealPos == b.RealPos;
        }

        public override int GetHashCode()
        {
            return RealPos.GetHashCode();
        }
    }

    public class Grid
    {

        private readonly Square[] m_Grid;
        private readonly int m_Width;
        private readonly int m_Height;

        public Grid(int x, int y)
        {
            m_Grid = new Square[x * y];
            m_Width = x;
            m_Height = y;
            InitGrid();
        }

        public int SquarePos(int x, int y)
        {
           return y * m_Width + x;
        }

        public int SquarePos(Point p)
        {
            return p.Y * m_Width + p.X;
        }

        public List<Square> GetNeighbors(Point p)
        {
            List<Square> neighbors = new List<Square>();
            int minX = Math.Max(p.X - 1, 0);
            int maxX = Math.Min(p.X + 1, m_Width - 1);
            int minY = Math.Max(p.Y - 1, 0);
            int maxY = Math.Min(p.Y + 1, m_Height - 1);

            for (int x = minX; x <= maxX; ++x)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    if (new Point(x, y) != p)
                    {
                        Square s = m_Grid[SquarePos(x, y)];
                        if (!s.Occupied && CanReach(s.RealPos, p))
                            neighbors.Add(s);
                    }
                        
                }
            }

            return neighbors;
        }

        private bool CanReach(Point p, Point origin)
        {
            Point p1 = new Point(p.X, origin.Y);
            Point p2 = new Point(origin.X, p.Y);

            Square s1 = m_Grid[SquarePos(p1)];
            Square s2 = m_Grid[SquarePos(p2)];

            return !s1.Occupied && !s2.Occupied;
        }

        public Square GetSqaure(Point p)
        {
            return m_Grid[SquarePos(p.X, p.Y)];
        }

        private void InitGrid()
        {
            for(int y = 0; y  < m_Height; ++y)
            {
                for(int x = 0; x < m_Width; ++x)
                {
                    m_Grid[SquarePos(x, y)].RealPos = new Point(x, y);
                }
            }
        }

        /// <summary>
        /// Returns true when wall gets removed
        /// </summary>
        public bool SetRemWall(Point p)
        {
            bool b = m_Grid[SquarePos(p.X, p.Y)].Occupied;
            m_Grid[SquarePos(p.X, p.Y)].Occupied = !b;
            return b;
        }


        public List<Point> GenerateRandomWalls(int cycles)
        {
            
            //resets the walls
            for (int i = 0; i < m_Grid.Length; i++)
            {
                m_Grid[i].Occupied = false;
            }

            int baseCount = (int)Math.Round(m_Grid.Length  * 0.05, 0);
            Random r = new Random();
            List<Point> walls = new List<Point>();

            for (int i = 0; i < cycles; ++i)
            {
                for(int j = 0; j < baseCount; ++j)
                {
                    int x = r.Next(0, m_Width - 1);
                    int y = r.Next(0, m_Height - 1);
                    Point p = new Point(x, y);
                    if(!GetSqaure(p).Occupied)
                    {
                        m_Grid[SquarePos(x, y)].Occupied = true;
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

        public Point StartPoint { get; set; }

        public Point EndPoint { get; set; }
    }
}
