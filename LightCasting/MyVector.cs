using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightWF
{
    public class MyVector
    {
        public float X;
        public float Y;
        public float Length { get => (float)Math.Sqrt(X * X + Y     * Y); }

        public float LengthSquared { get =>  X * X + Y * Y; }

        public MyVector(float x, float y)
        {
            X = x;
            Y = y;
        }

        public MyVector()
        {

        }

        public void Normalize()
        {
            if (Length == 0.0f)
                return;
            X /= Length; 
            Y /= Length;
            Debug.WriteLine($"NORM x = {X}, y = {Y}, Length = {Length}");
        }
    }
}
