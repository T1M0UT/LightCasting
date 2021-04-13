using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows;

namespace LightWF
{
    public class Ray
    {
        public MyVector pos;
        public MyVector dir;

        public Ray(MyVector pos, float angle)
        {
            this.pos = pos;
            dir = new MyVector((float)Math.Cos(angle), (float)Math.Sin(angle));
        }

        public void LookAt(float x, float y)
        {
            dir.X = x - pos.X;
            dir.Y = y - pos.Y;
            //Debug.WriteLine($"x = {dir.X} = {x} - {pos.X}, y = {dir.Y} = {y} - {pos.Y}, Length = {dir.Length}");
            dir.Normalize();
        }

        public void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawLine(pen, pos.X, pos.Y, pos.X + 15f * dir.X, pos.Y + 15f * dir.Y);
        }

        public bool TryCast(Boundary wall, out MyVector point)
        {
            point = new MyVector();
            float x1 = wall.p1.X;
            float y1 = wall.p1.Y;
            float x2 = wall.p2.X;
            float y2 = wall.p2.Y;

            float x3 = pos.X;
            float y3 = pos.Y;
            float x4 = pos.X + dir.X;
            float y4 = pos.Y + dir.Y;

            float denominator = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
            if (denominator == 0f) 
                return false;
            float tPartial = ((x1 - x3) * (y3 - y4) - (y1 - y3) * (x3 - x4));
            float uPartial = ((x2 - x1) * (y1 - y3) - (y2 - y1) * (x1 - x3));
            float t = tPartial / denominator;
            float u = uPartial / denominator;
            if (t > 0 && t < 1 && u > 0)
            {
                point.X = x1 + t * (x2 - x1);
                point.Y = y1 + t * (y2 - y1);
                return true;
            }
            return false;
        }
    }
}
