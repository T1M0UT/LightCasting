using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightWF
{
    public class MathHelper
    {
        public static float DistPointLineSegment(MyVector C, MyVector A, MyVector B)
        {
            float numerator = Math.Abs((C.X - A.X) * (-B.Y + A.Y) + (C.Y - A.Y) * (B.X  - A.X));
            float denominator = (float)Math.Sqrt((-B.Y + A.Y) * (-B.Y + A.Y) + (B.X - A.X) * (B.X - A.X));
            return numerator / denominator;
        }
    }
}
