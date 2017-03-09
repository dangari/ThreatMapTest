namespace ThreatMaps.Pathfinding
{
    public struct LineValues
    {
        public int StartX { get; set; }
        public int StartY { get; set; }

        public int EndX { get; set; }
        public int EndY { get; set; }
    }

    class GridLines
    {
        public LineValues CalcVerticalLine(int gridPosition, int squareSize, int gridLength, int spacing = 0)
        {
            LineValues lineValue = new LineValues
            {
                StartX = gridPosition * squareSize + spacing,
                StartY = 0 + spacing
            };
            lineValue.EndX = lineValue.StartX;
            lineValue.EndY = gridLength + spacing;

            return lineValue;
        }

        public LineValues CalcHorizontalLine(int gridPosition, int squareSize, int gridWidth, int spacing = 0)
        {
            return new LineValues
            {
                StartX = 0 + spacing,
                StartY = gridPosition * squareSize + spacing,
                EndX = gridWidth + spacing,
                EndY = gridPosition * squareSize + spacing
            };
        }
    }
}
