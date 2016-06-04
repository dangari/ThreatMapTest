using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Priority_Queue;
using System.Collections;

namespace ThreatMaps.Pathfinding
{

   

    class AStar
    {

        private int heuristic(Point node, Point goal)
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



        public List<Point> calcPath(Grid g, Point start, Point end)
        {
            Point currentPoint = start;
            int currentCost = 0;
            Square currentSquare = g.getSqaure(start);
            SimplePriorityQueue<Square> priorityQueue = new SimplePriorityQueue<Square>();
            Hashtable closed = new Hashtable();

            priorityQueue.Enqueue(currentSquare, 0);

            int steps = 0;
            while (currentPoint != end && priorityQueue.Count > 0)
            {

                currentSquare = priorityQueue.Dequeue();
                currentPoint = currentSquare.realPos;
                currentSquare.cost = getCost(steps, currentSquare, end);
                closed.Add(currentSquare.realPos.ToString(),currentSquare);
                currentCost = currentSquare.cost;

                //add neighbors
                List<Square> neighbors = g.getNeighbors(currentSquare.realPos);
                foreach(Square s in neighbors)
                {
                    if (priorityQueue.Contains(s) && priorityQueue.GetPriority(s) > currentCost)
                    {
                        priorityQueue.Remove(s);
                    }
                    if (closed.Contains(s.realPos.ToString()))
                    {
                        Square x = (Square)closed[s.realPos.ToString()];
                        if (x.cost > currentCost)
                            closed.Remove(s);
                    }
                    if (!priorityQueue.Contains(s) && !closed.Contains(s.realPos.ToString()))
                    {
                        Square neighbor = s;
                        neighbor.cost = getCost(steps, s, end);
                        neighbor.prevSquareID = currentSquare.realPos.ToString();
                        priorityQueue.Enqueue(neighbor, neighbor.cost);
                    }
                }
                ++steps;
            }
            ////add endPoint
            //currentSquare = g.getSqaure(end);
            //currentSquare.realPos = end;
            //currentSquare.prevSquareID = preSquare.realPos.ToString();
            //closed.Add(currentSquare.realPos.ToString(), currentSquare);

            List<Point> finalPath = new List<Point>();

            // calculates the final Path
            if(closed.Contains(end.ToString()))
            {
                finalPath.Add(end);
                Square s = g.getSqaure(end);
                while(currentSquare.realPos != start)
                {
                    currentSquare = (Square)closed[currentSquare.prevSquareID];
                    finalPath.Add(currentSquare.realPos);
                }
            }
            return finalPath;
        }

        private int getCost(int steps, Square node, Point end)
        {
            return (2 * steps + heuristic(node.realPos, end) + node.Threat);
        }

    }
}
