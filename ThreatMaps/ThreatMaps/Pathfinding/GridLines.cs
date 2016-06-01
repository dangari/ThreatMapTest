using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public struct LineValues
    {
        public int startX;
        public int startY;

        public int endX;
        public int endY;
    }

    class GridLines
    {
        public LineValues calcVerticalLine(int gridPosition, int squareSize, int gridLength, int spacing = 0)
        {
            LineValues lineValue;
            lineValue.startX = gridPosition * squareSize + spacing;
            lineValue.startY = 0 + spacing;
            lineValue.endX = lineValue.startX;
            lineValue.endY = gridLength + spacing;

            return lineValue;
        }

        public LineValues calcHorizontalLine(int gridPosition, int squareSize, int gridWidth, int spacing = 0)
        {
            LineValues lineValue;
            lineValue.startX = 0 + spacing;
            lineValue.startY = gridPosition * squareSize + spacing;
            lineValue.endX = gridWidth + spacing;
            lineValue.endY = gridPosition * squareSize + spacing;

            return lineValue;
        }
    }
}
