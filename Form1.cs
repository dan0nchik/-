using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Многоугольники
{
    public partial class Form1 : Form
    {
        List<Shape> shapes = new List<Shape>();
        int shapeFlag;
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
            foreach (Shape i in shapes)
            {
                i.Draw(e.Graphics);
            }
            double k, b;
            int topCount = 0, bottomCount = 0;
            if (shapes.Count > 2)
            {
                foreach (Shape first in shapes)
                {
                    foreach (Shape second in shapes)
                    {
                       if (second == first) continue;
                        
                        foreach (Shape third in shapes)
                        {
                            if (third == second) continue;
                            if (second.X == first.X)
                            {
                                if (third.X >= second.X)
                                    topCount++;
                                else continue;
                                if (third.X < second.X) bottomCount++;
                                else continue;
                            }
                            else
                            {
                                k = (second.Y - first.Y) / (second.X - first.X);
                                b = first.Y - k * first.X;
                                if (third.Y < k * third.X + b)
                                {
                                    topCount++;
                                }
                                else continue;
                                if (third.Y > k * third.X + b) bottomCount++;
                                else continue;
                            }
                        }
                        if( topCount == 0 || bottomCount == 0) {
                            e.Graphics.DrawLine(new Pen(new SolidBrush(Color.Black)), new Point(first.X, first.Y), new Point(second.X, second.Y));
                            first.connected = true;
                            second.connected = true;
                            topCount = 0; bottomCount = 0;
                        }
                        
                    }
                }
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            bool shifted = false;
            foreach (Shape i in shapes.ToList())
            {
                if (i.IsInside(e.X, e.Y))
                {
                    i.dragged = true;
                    shifted = true;
                    i.ChosenX =  i.X-e.X;
                    i.ChosenY =  i.Y-e.Y;
                }
                
                
            }
            if(shifted == false)
                {
                switch (shapeFlag)
                {
                    case 0:
                        shapes.Add(new Circle(e.X, e.Y));
                        break;
                    case 1:
                        shapes.Add(new Square(e.X, e.Y));
                        break;
                    case 2:
                        shapes.Add(new Triangle(e.X, e.Y));
                        break;
                }
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

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeFlag = 0;
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeFlag = 1;
        }

        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapeFlag = 2;
        }
    }
    public abstract class Shape
    {
        protected int x, y, chosenX, chosenY;
        protected static int r;
        public bool dragged, connected = false;
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
            r = 10;
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
            Point[] points = new Point[]
            {
            new Point(X - (int)(Math.Sqrt(2) * R / 2), Y + (int)(Math.Sqrt(2) * R / 2)),
            new Point(X - (int)(Math.Sqrt(2) * R / 2), Y - (int)(Math.Sqrt(2) * R / 2)),
            new Point(X + (int)(Math.Sqrt(2) * R / 2), Y - (int)(Math.Sqrt(2) * R / 2)),
            new Point(X + (int)(Math.Sqrt(2) * R / 2), Y + (int)(Math.Sqrt(2) * R / 2))
            };

            g.FillPolygon(new SolidBrush(Color.Black), points);
        }
        public override bool IsInside(int xx, int yy)
        {
            //TODO
            Point A = new Point(X - (int)(Math.Sqrt(2) * R / 2), Y + (int)(Math.Sqrt(2) * R / 2));
            Point B = new Point(X - (int)(Math.Sqrt(2) * R / 2), Y - (int)(Math.Sqrt(2) * R / 2));
            Point C = new Point(X + (int)(Math.Sqrt(2) * R / 2), Y - (int)(Math.Sqrt(2) * R / 2));
            Point D = new Point(X + (int)(Math.Sqrt(2) * R / 2), Y + (int)(Math.Sqrt(2) * R / 2));

            return (A.X <= xx) && (xx <= C.X) && (B.Y <= yy) && (yy <= D.Y);
        }
    }
}
