using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightWF
{
    public class Particle
    {
        public static Random rand;
        public MyVector pos;
        public List<Ray> rays;

        public Particle(float x, float y)
        {
            pos = new MyVector(x, y);
            rays = new List<Ray>();

            for (double a = 0; a < 360; a += 0.5)
            {
                rays.Add(new Ray(pos, (float)(a * Math.PI / 180.0)));
            }
            rand = new Random();
        }

        public void Update(float x, float y)
        {
            pos.X = x;
            pos.Y = y;
        }

        public void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawEllipse(pen, pos.X, pos.Y, 5, 5);
            foreach(Ray ray in rays)
            {
                ray.Draw(graphics, pen);
            }
        }

        public void Look(List<Boundary> walls, Graphics graphics, Pen pen)
        {
            foreach (Ray ray in rays)
            {
                MyVector closest = new MyVector();
                float record = float.MaxValue; 
                foreach(Boundary wall in walls)
                {
                    if (ray.TryCast(wall, out MyVector point))
                    {
                        float d = (float)Math.Sqrt((point.X - pos.X) * (point.X - pos.X) + (point.Y - pos.Y) * (point.Y - pos.Y));
                        if(d < record)
                        {
                            record = d;
                            closest = point;
                        }
                    }
                }
                //if (closest.X != 0 && closest.Y != 0)
                //{
                    graphics.DrawLine(pen, pos.X, pos.Y, closest.X, closest.Y);
                //}
            }
        }
    }
}
