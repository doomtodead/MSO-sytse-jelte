using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ShapeDrawing
{
    public interface DrawMethod
    {
        void Line(int x1, int y1, int x2, int y2);
        void Circle(int x, int y, int d, int d1);
    }

    public class WindowsForm : DrawMethod
    {
        Pen pen = new Pen(Color.Black);
        public Graphics graphics; 
        public void Line(int x1, int y1, int x2, int y2)
        {
            graphics.DrawLine(pen,x1,y1,x2,y2);
        }

        public void Circle(int x, int y, int d, int d1)
        {
            graphics.DrawEllipse(pen, x, y, d, d1);
        }        
    }

    public class GenerateSVG : DrawMethod
    {
        public void Line(int x1, int y1, int x2, int y2)
        {

        }

        public void Circle(int x, int y, int d, int d1)
        {

        }
    }
}
