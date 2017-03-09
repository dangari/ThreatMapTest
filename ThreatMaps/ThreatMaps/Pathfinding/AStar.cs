using System;
using System.Collections.Generic;
using System.Drawing;
using Priority_Queue;
using System.Collections;

namespace ThreatMaps.Pathfinding
{

   

    public class AStar
    {

        private int Heuristic(Point node, Point goal)
        {
            int dx = Math.Abs(node.X - goal.X);
            int dy = Math.Abs(node.Y - goal.Y);
            return 1 * (dx + dy) + (2 - 2 * 1) * Math.Min(dx, dy);
        }

        //private int heuristic(Point node, Point goal)
        //{
        //    int dx = Math.Abs(node.X - goal.X);
        //    int dy = Math.Abs(node.Y - goal.Y);
        //    return 1 * (int)Math.Sqrt(dx * dx + dy * dy);
        //}



        public List<Point> CalcPath(Grid g, Point start, Point end)
        {
            Point currentPoint = start;
            Square currentSquare = g.GetSqaure(start);
            SimplePriorityQueue<Square> priorityQueue = new SimplePriorityQueue<Square>();
            Hashtable closed = new Hashtable();

            priorityQueue.Enqueue(currentSquare, 0);

            int steps = 0;
            while (currentPoint != end && priorityQueue.Count > 0)
            {

                currentSquare = priorityQueue.Dequeue();
                currentPoint = currentSquare.RealPos;
                currentSquare.Cost = GetCost(steps, currentSquare, end);
                closed.Add(currentSquare.RealPos.ToString(),currentSquare);
                int currentCost = currentSquare.Cost;

                //add neighbors
                List<Square> neighbors = g.GetNeighbors(currentSquare.RealPos);
                foreach(Square s in neighbors)
                {
                    if (priorityQueue.Contains(s) && priorityQueue.GetPriority(s) > currentCost)
                    {
                        priorityQueue.Remove(s);
                    }
                    if (closed.Contains(s.RealPos.ToString()))
                    {
                        Square x = (Square)closed[s.RealPos.ToString()];
                        if (x.Cost > currentCost)
                            closed.Remove(s);
                    }
                    if (!priorityQueue.Contains(s) && !closed.Contains(s.RealPos.ToString()))
                    {
                        Square neighbor = s;
                        neighbor.Cost = GetCost(steps, s, end);
                        neighbor.PrevSquareID = currentSquare.RealPos.ToString();
                        priorityQueue.Enqueue(neighbor, neighbor.Cost);
                    }
                }

                ++steps;
            }
            ////add endPoint
            //currentSquare = g.getSqaure(end);
            //currentSquare.RealPos = end;
            //currentSquare.PrevSquareID = preSquare.RealPos.ToString();
            //closed.Add(currentSquare.RealPos.ToString(), currentSquare);

            List<Point> finalPath = new List<Point>();

            // calculates the final Path
            if(closed.Contains(end.ToString()))
            {
                finalPath.Add(end);
                Square s = g.GetSqaure(end);
                while(currentSquare.RealPos != start)
                {
                    currentSquare = (Square)closed[currentSquare.PrevSquareID];
                    finalPath.Add(currentSquare.RealPos);
                }
            }

            return finalPath;
        }

        private int GetCost(int steps, Square node, Point end)
        {
            return (2 * steps + Heuristic(node.RealPos, end) + node.Threat);
        }

    }
}
