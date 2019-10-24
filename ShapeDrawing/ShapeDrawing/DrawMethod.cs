using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace ShapeDrawing
{
    public interface DrawMethod
    {
        void Line(int[] points);
        void Circle(int x, int y, int d, int d1);
    }

    public class WindowsForm : DrawMethod
    {
        Pen pen = new Pen(Color.Black);
        public Graphics graphics; 
        public void Line(int[] points)
        {
            graphics.DrawLine(pen, points[0], points[1], points[2], points[3]);
        }

        public void Circle(int x, int y, int d, int d1)
        {
            graphics.DrawEllipse(pen, x, y, d, d1);
        }        
    }

    public class GenerateSVG : DrawMethod
    {
        public StreamWriter streamWriter;
        public void Line(int[] points)
        {
            string cords = "";
            for (int i = 0; i <= points.Length - 1; i += 2) 
            {
                cords += points[i].ToString() + points[i + 1].ToString();
            }
            cords += points[1].ToString() + points[2].ToString();
            streamWriter.WriteLine(" polyline points = \" " + cords + "\"");
        }

        public void Circle(int x, int y, int d, int d1)
        {

        }
    }
}
