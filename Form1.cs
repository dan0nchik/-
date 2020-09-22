using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Многоугольники
{
    public partial class Form1 : Form
    {
        List<Shape> shapes = new List<Shape>();
        public Form1()
        {
            shapes.Add(new Circle(50, 50));
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Shape i in shapes) i.dragged = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Shape i in shapes) i.Draw(e.Graphics);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            bool shifted = false;
            foreach (Shape i in shapes.ToList())
            {
                if (i.IsInside(e.X, e.Y) == true)
                {
                    i.dragged = true;
                    shifted = true;
                    i.ChosenX =  i.X-e.X;
                    i.ChosenY =  i.Y-e.Y;
                }
                
                
            }
            if(shifted == false)
                {
                    shapes.Add(new Circle(e.X, e.Y));
                    Refresh();
                }
            if (e.Button == MouseButtons.Right)
            {
                foreach (Shape i in shapes.ToList())
                {
                    if (i.IsInside(e.X, e.Y) == true)
                    {
                        shapes.RemoveAt(shapes.IndexOf(i));
                        Refresh();
                    }
                }
            }
           
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (Shape i in shapes.ToList())
            {
                if (i.dragged == true)
                {

                    i.X = e.X+i.ChosenX;
                    i.Y = e.Y+i.ChosenY;
                    Refresh();
                }
            }
        }
    }
    public abstract class Shape
    {
        protected int x, y, chosenX, chosenY;
        protected static int r;
        public bool dragged;
        protected static Color lineC, fillC;
        public int X
        {
            get => x;
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get => y;
            set
            {
                y = value;
            }
        }
        public int ChosenX
        {
            get => chosenX;
            set
            {
                chosenX = value;
            }
        }
        public int ChosenY
        {
            get => chosenY;
            set
            {
                chosenY = value;
            }
        }

        public int R
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
            r = 20;
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
             g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(x - R, y - R, 2 * R, 2 * R));
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
            int halfSide = (int)Math.Sqrt(R * R / 2);
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(x-R, y-R, 2*halfSide, 2*halfSide));
        }
        public override bool IsInside(int xx, int yy)
        {
            //TODO
            int halfSide = (int)Math.Sqrt(R * R / 2);
            if ((xx >= x && xx <= x + halfSide && yy >= y && yy <= -y - halfSide)|| 
            (xx >= x && xx <= x + halfSide && yy >= y && yy <= y + halfSide) ||
            (xx <= x && xx >= x - halfSide && yy >= y && yy <= y + halfSide) ||
            (xx <= x && xx >= x - halfSide && yy >= y && yy <= -(y + halfSide)))return true;
            return false;
        }
    }
}
