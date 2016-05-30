using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools;

namespace ThreatMaps
{



    public partial class ThreatMapsForm : Form
    {

        private const int drawSpace = 5;
        private const int gridXSize = 500;
        private const int gridYSize = 500;
        
        private int squareSize = 125;
        private int squareXCount;
        private int squareYCount;

        private Point clickedPoint;
        private Point startPoint;
       

        public ThreatMapsForm()
        {
            InitializeComponent();
            calcGridValues();
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
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                clickedPoint = gridPanel.PointToClient(Cursor.Position);
            }
            
        }

        private void cm_setStartPointEvent(object sender, EventArgs e)
        {

            gridPanel.Refresh();
        }
        private void cm_setEndPointEvent(object sender, EventArgs e)
        {
        }


        //functions
        private void drawGrid(PaintEventArgs e)
        {
            Pen blackpen = new Pen(Color.Black, 1);
            Graphics g = e.Graphics;
            
            
            int ySpace = gridYSize / squareSize;
            int xSpace = gridXSize / squareSize;


            GridLines gridLines = new GridLines();
            // draw vertical lines
            for(int i = 0; i <= squareXCount; ++i)
            {
                LineValues l = gridLines.calcVerticalLine(i, squareSize, gridXSize, drawSpace);
                g.DrawLine(blackpen, l.startX, l.startY, l.endX, l.endY);
            }

            // draw horizontal lines
            for (int i = 0; i <= squareYCount; ++i)
            {
                LineValues l = gridLines.calcHorizontalLine(i, squareSize, gridXSize, drawSpace);
                g.DrawLine(blackpen, l.startX, l.startY, l.endX, l.endY);
            }

            g.Dispose();
        }

        private void calcGridValues()
        {
            squareXCount = gridXSize / squareSize;
            squareYCount = gridYSize / squareSize;
        }
    }
}
