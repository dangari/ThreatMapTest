﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;
using ThreatMaps.Pathfinding;

namespace ThreatMaps
{



    public partial class ThreatMapsForm : Form
    {

        private const int drawSpace = 5;
        private const int gridXSize = 500;
        private const int gridYSize = 500;
        
        private int squareSize = 20;
        private int squareXCount;
        private int squareYCount;

        private Point startPoint;
        private Point endPoint;
        private Point selectedSquarePoint;


        private bool startPointSet;
        private bool endPointSet;
        private bool squareMarked;

        private Grid grid;

        public ThreatMapsForm()
        {
            InitializeComponent();
            initGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //events
        private void gridPanel_Paint(object sender, PaintEventArgs e)
        {
            drawGrid(e);
        }

        private void gridPanel_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                squareMarked = true;
                Point clickedPoint = gridPanel.PointToClient(Cursor.Position);
           
                selectedSquarePoint = calcRectPosition(clickedPoint);
                debugText.Text = "X: " + clickedPoint.X + " Y: " + clickedPoint.Y;
                gridPanel.Refresh();
            }
            
        }

        private void cm_setStartPointEvent(object sender, EventArgs e)
        {
            startPointSet = true;
            startPoint = selectedSquarePoint;
            grid.StartPoint = startPoint;
            gridPanel.Refresh();
        }
        private void cm_setEndPointEvent(object sender, EventArgs e)
        {
            endPointSet = true;
            endPoint = selectedSquarePoint;
            grid.EndPoint = endPoint;
            gridPanel.Refresh();
        }


        //functions
        private void drawGrid(PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 1);
            Graphics g = e.Graphics;
            
            
            int ySpace = gridYSize / squareSize;
            int xSpace = gridXSize / squareSize;


            GridLines gridLines = new GridLines();
            // draw vertical lines
            for(int i = 0; i <= squareXCount; ++i)
            {
                LineValues l = gridLines.calcVerticalLine(i, squareSize, gridXSize, drawSpace);
                g.DrawLine(blackPen, l.startX, l.startY, l.endX, l.endY);
            }

            // draw horizontal lines
            for (int i = 0; i <= squareYCount; ++i)
            {
                LineValues l = gridLines.calcHorizontalLine(i, squareSize, gridXSize, drawSpace);
                g.DrawLine(blackPen, l.startX, l.startY, l.endX, l.endY);
            }

            if(squareMarked)
            {
                Pen squarePen = new Pen(Color.Red, 2);
                Rectangle rect = generateRectangle(selectedSquarePoint);
                g.DrawRectangle(squarePen, rect);
            }

            if(startPointSet)
            {
                SolidBrush startBrush = new SolidBrush(Color.Green);
                Rectangle rect = generateRectangle(startPoint);
                g.FillRectangle(startBrush, rect);
                squareMarked = false;
            }


            if (endPointSet)
            {
                SolidBrush startBrush = new SolidBrush(Color.Blue);
                Rectangle rect = generateRectangle(endPoint);
                g.FillRectangle(startBrush, rect);
                squareMarked = false;
            }

            g.Dispose();
        }

        private void initGrid()
        {
            //calculates size of the grid
            squareXCount = gridXSize / squareSize;
            squareYCount = gridYSize / squareSize;

            //init Grid
            grid = new Grid(squareXCount, squareYCount);
        }

        private Point calcRectPosition(Point p)
        {
            Point tempPoint = new Point();
            tempPoint.X = (p.X - drawSpace) / squareSize;
            tempPoint.Y = (p.Y - drawSpace) / squareSize;
            return tempPoint;
        }

        private Rectangle generateRectangle(Point p)
        {
            Rectangle rect = new Rectangle(p.X * squareSize + drawSpace + 1, p.Y * squareSize + drawSpace + 1, squareSize - 1, squareSize - 1);
            return rect;
        }
    }
}
