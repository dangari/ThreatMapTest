using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Priority_Queue;

namespace ThreatMaps.Pathfinding
{

   

    class AStar
    {
       
        private int heuristic(Point node, Point goal)
        {
            int dx = Math.Abs(node.X - goal.X);
            int dy = Math.Abs(node.Y - goal.Y);
            return 1 * (dx + dy) + (1 - 2 * 1) * Math.Min(dx, dy);
        }

        public void calcPath(Grid g, Point start, Point end)
        {
            Point currentPoint = start;
            Square preSquare;
            int currentCost = 0;
            Square currentSquare = g.getSqaure(currentPoint);
            SimplePriorityQueue<Point> priorityQueue = new SimplePriorityQueue<Point>();
            List<Square> closed = new List<Square>();
            
            priorityQueue.Enqueue(start, 0);

            while (currentPoint != end && priorityQueue.Count > 0)
            {
                preSquare = currentSquare;
                currentPoint = priorityQueue.Dequeue();
                currentSquare = g.getSqaure(currentPoint);
                currentSquare.cost = currentCost + currentSquare.Threat;
                currentSquare.prevSquare = preSquare;
                
                currentCost = currentSquare.cost;

                //add neighbors
                List<Square> neighbors = g.getNeighbors(currentPoint);
                foreach(Square s in neighbors)
                {
                    if(priorityQueue.Contains(s.realPos))
                    {
                       
                    }
                    else if (closed.Contains(s))
                    {

                    }
                }
            }
        }

    }
}
