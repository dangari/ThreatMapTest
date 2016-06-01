using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
            int currentCost = 0;
            List<Square> priorityQueue;

            while(currentPoint != end)
            {
                Square currentSquare = g.getSqaure(currentPoint);
                currentSquare.cost = currentCost + heuristic(currentPoint, end) + currentSquare.Threat;
            }
        }

    }
}
