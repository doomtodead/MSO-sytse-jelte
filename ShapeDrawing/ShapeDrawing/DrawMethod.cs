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
        void Circle(int x, int y, int d);
    }

    public class WindowsForm : DrawMethod
    {
        Pen pen = new Pen(Color.Black);
        public Graphics graphics; 
        public void Line(int[] points)
        {
            graphics.DrawLine(pen, points[0], points[1], points[2], points[3]);
        }

        public void Circle(int x, int y, int d)
        {
            graphics.DrawEllipse(pen, x, y, d, d);
        }        
    }

    public class GenerateSVG : DrawMethod
    {
        public StreamWriter streamWriter;
        public void Line(int[] Points)
        {
            int[] points = Points;
            streamWriter.WriteLine("    <polyline points = \"" + points[0].ToString() + "," + points[1].ToString() + "," + points[2].ToString() + "," + points[3].ToString() + "\"");
            streamWriter.WriteLine("        style=\"fill: none; stroke: black; stroke - width:1\" />");
        }

        public void Circle(int x, int y, int d)
        {
            streamWriter.WriteLine("    <circle cx=\""+ (x + (d/2)) + "\" cy =\"" + (y + (d / 2)) + "\" r =\"" + (d/2) + "\" stroke-width=\"1\" fill=\"none\" stroke=\"black\" />");
        }
    }
}
