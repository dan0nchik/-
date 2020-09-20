using System;
using System.Drawing;
using System.Windows.Forms;

namespace Многоугольники
{
    public partial class Form1 : Form
    {
        Shape square = new Square(100, 100);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            square.dragged = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            square.Draw(e.Graphics);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            if (square.IsInside(e.X, e.Y)==true)
            {
                square.dragged = true;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {   
            if (square.dragged == true)
            {
                square = new Circle(e.X, e.Y);
                square.dragged = true;
                Refresh();
            }

        }
    }
    public abstract class Shape
    {
        protected int x, y;
        protected static int r;
        public bool dragged;
        protected static Color lineC, fillC;
        protected int X
        {
            get => x;
            set
            {
                x = value;
            }
        }
        protected int Y
        {
            get => y;
            set
            {
                y = value;
            }
        }
        protected  int R
        {
            get => r;
            set
            {
                r = value;
            }
        }
        
        public Shape(int xx, int yy)
        {
            x = xx;
            y = yy;
        }

        static Shape()
        {
            r = 35;
        }
        

        public abstract void Draw(Graphics g);
        public abstract bool IsInside(int xx, int yy);
    }

    public class Circle : Shape
    {
        public Circle(int xx, int yy) : base(xx,yy)
        {
        }
        public override void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(x-R, y-R, 2*R, 2*R));
        }
        public override bool IsInside(int xx, int yy)
        {
            return Math.Sqrt(Math.Pow(x - xx, 2) + Math.Pow(y - yy, 2)) <= R;
        }

    }
    

    public class Triangle : Shape
    {
        
        public Triangle(int xx, int yy) : base(xx, yy)
        {
        }
        public override void Draw(Graphics g)
        {
            //плохой код
            Point B = new Point(x, y - r);
            Point A = new Point(x - (int)(r * Math.Sqrt(3) / 2), (int)(y + (0.5 * r)));
            Point C = new Point(x + (int)(r * Math.Sqrt(3) / 2), (int)(y + (0.5 * r)));
            g.FillPolygon(new SolidBrush(Color.Black), new Point[] { A, B, C });
        }
        public override bool IsInside(int xx, int yy)
        {
            //плохой код
            Point B = new Point(x, y - R);
            Point A = new Point(x - (int)(R * Math.Sqrt(3) / 2), (int)(y + (0.5 * R)));
            Point C = new Point(x + (int)(R * Math.Sqrt(3) / 2), (int)(y + (0.5 * R)));
            var first = (A.X - xx) * (B.Y - A.Y) - (B.X - A.X) * (A.Y - yy);
            var second = (B.X - xx) * (C.Y - B.Y) - (C.X - B.X) * (B.Y - yy);
            var third = (C.X - xx) * (A.Y - C.Y) - (A.X - C.X) * (C.Y - yy);
            if (first == 0 || second == 0 || third == 0) return true;
            if ((first > 0 && second > 0 && third > 0) || (first < 0 && second < 0 && third < 0)) return true;
            return false;
        }
    }

    public class Square : Shape
    {
        public Square(int xx, int yy) : base(xx, yy)
        {
        }
        public override void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(x-R, y-R, 50, 50));
        }
        public override bool IsInside(int xx, int yy)
        {
            int side = 50;
            if (xx>=x && xx<=x+side && yy >= y && yy <= y+side) return true;
            return false;
        }
    }
}
