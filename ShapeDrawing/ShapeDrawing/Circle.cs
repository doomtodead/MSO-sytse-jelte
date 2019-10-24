using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShapeDrawing;

class Circle : Shape
{

    private int x;
	private int y;
	private int size;

    public Circle(int x, int y, int size)
    {
		this.x = x;
		this.y = y;
		this.size = size;
    }

    public override void Draw(DrawMethod Canvas)
    {
        Canvas.Circle(x, y, size);
    }

}
