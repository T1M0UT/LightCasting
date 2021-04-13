using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightWF
{
    public partial class Form1 : Form
    {
        private static Random rand;
        private Bitmap bitmap;
        private Graphics graphics;
        private Pen boundaryPen;
        private Pen rayPen;
        private List<Boundary> walls;
        private Particle particle;
        private double xoff;
        private double yoff;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            rand = new Random();
            bitmap = new Bitmap(picture.Width, picture.Height);
            graphics = Graphics.FromImage(bitmap);
            boundaryPen = new Pen(Color.WhiteSmoke, 3f);
            rayPen = new Pen(Color.FromArgb(100, Color.White), 1f);

            walls = new List<Boundary>();
            walls.Add(new Boundary(0, 0, 0, Height));
            walls.Add(new Boundary(0, 0, Width, 0));
            walls.Add(new Boundary(0, Height, Width, Height));
            walls.Add(new Boundary(Width, 0, Width, Height));
            for(int i = 0; i < 5; i++)
            {
                int x1 = rand.Next(Width);
                int y1 = rand.Next(Height);
                int x2 = rand.Next(Width);
                int y2 = rand.Next(Height);
                walls.Add(new Boundary(x1, y1, x2, y2));
            }
            particle = new Particle(200, 200);
            Draw();
        }

        private void Draw()
        {
            graphics.Clear(Color.FromArgb(20, 20, 20));
            particle.Draw(graphics, rayPen);
            particle.Look(walls, graphics, rayPen);
            foreach(Boundary wall in walls)
            {
                //boundaryPen = new Pen(Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255)), 2);
                wall.Draw(graphics, boundaryPen);
            }

            picture.Image = bitmap;
        }

        private void picture_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void OnUpdate()
        {
            Perlin perlin = new Perlin();
            float noisex = (float)perlin.perlin(xoff, xoff, 1);
            float noisey = (float)perlin.perlin(yoff, yoff, 1);
            xoff += 0.01;
            yoff += 0.005;
            particle.Update(noisex * Width, noisey * Height);
            //graphics.DrawEllipse(new Pen(Color.White, 10), e.X, e.Y, 10, 10);
            Draw();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            OnUpdate();
        }
    }
}
