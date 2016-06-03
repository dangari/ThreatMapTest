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

        public List<Point> calcPath(Grid g, Point start, Point end)
        {
            Point currentPoint = start;
            int currentCost = 0;
            Square currentSquare = g.getSqaure(currentPoint);
            Square preSquare = currentSquare;
            SimplePriorityQueue<Point> priorityQueue = new SimplePriorityQueue<Point>();
            Hashtable closed = new Hashtable();
            
            priorityQueue.Enqueue(start, 0);

            int steps = 0;
            while (currentPoint != end && priorityQueue.Count > 0)
            {
                preSquare = currentSquare;
                currentPoint = priorityQueue.Dequeue();
                currentSquare = g.getSqaure(currentPoint);

                currentSquare.cost = getCost(steps, currentSquare, end);
                currentSquare.prevSquareID = preSquare.realPos.ToString();
                closed.Add(currentSquare.realPos.ToString(),currentSquare);
                currentCost = currentSquare.cost;

                //add neighbors
                List<Square> neighbors = g.getNeighbors(currentPoint);
                foreach(Square s in neighbors)
                {
                    if (priorityQueue.Contains(s.realPos) && priorityQueue.GetPriority(s.realPos) > currentCost)
                    {
                        priorityQueue.Remove(s.realPos);
                    }
                    if (closed.Contains(s.realPos.ToString()))
                    {
                        Square x = (Square)closed[s.realPos.ToString()];
                        if (x.cost > currentCost)
                            closed.Remove(s);
                    }
                    if (!priorityQueue.Contains(s.realPos))
                    {
                        Square neighbor = s;
                        neighbor.cost = currentCost + s.Threat + heuristic(s.realPos, end);
                        priorityQueue.Enqueue(neighbor.realPos, neighbor.cost);
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
            return (steps + heuristic(node.realPos, end) + node.Threat);
        }

    }
}
