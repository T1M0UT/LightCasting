using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightWF
{
    public class Boundary
    {
        public MyVector p1;
        public MyVector p2;

        public Boundary(int x1, int y1, int x2, int y2)
        {
            p1 = new MyVector(x1, y1);
            p2 = new MyVector(x2, y2);
        }

        public void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
        }
    }
}
