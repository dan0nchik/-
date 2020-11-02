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
        private int shapeFlag;
        private Color lineColor = Color.Black, pointColor = Color.Black;
       
        public Form1()
        {
            shapes.Add(new Circle(50, 50));
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Shape i in shapes.ToList())
            {
                i.dragged = false;
                //if (shapes.Count > 2)
                    //if (!i.inShell) { shapes.Remove(i); Refresh(); }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //ByDefinitionAlgorithm(e, lineColor);
            JarvisAlgorithm(e, lineColor);
        }

        private void ByDefinitionAlgorithm(PaintEventArgs e, Color lineColor)
        {
            double k, b;
            int topCount, bottomCount, rightCount, leftCount;
            foreach (Shape shape in shapes)
            {
                shape.inShell = false;
            }
            if (shapes.Count > 2)
            {

                foreach (Shape first in shapes)
                {
                    foreach (Shape second in shapes)
                    {

                        if (second != first)
                        {
                            if ((second.X - first.X) == 0)
                            {
                                rightCount = 0;
                                leftCount = 0;
                                foreach (Shape third in shapes)
                                {
                                    if (third != first && third != second)
                                    {
                                        if (first.X >= third.X) rightCount++;
                                        else leftCount++;
                                    }
                                }
                                if (rightCount == 0 || leftCount == 0)
                                {
                                    second.inShell = true;
                                    first.inShell = true;
                                    e.Graphics.DrawLine(new Pen(new SolidBrush(lineColor)), new Point(first.X, first.Y), new Point(second.X, second.Y));
                                }
                            }
                            else
                            {
                                k = ((double)first.Y - (double)second.Y) / ((double)first.X - (double)second.X);
                                b = first.Y - (k * first.X);
                                topCount = 0;
                                bottomCount = 0;
                                foreach (Shape third in shapes)
                                {
                                    if (third != first && third != second)
                                    {
                                        if (third.Y >= k * third.X + b) topCount++;
                                        else bottomCount++;
                                    }
                                }
                                if (bottomCount == 0 || topCount == 0)
                                {
                                    second.inShell = true;
                                    first.inShell = true;
                                    e.Graphics.DrawLine(new Pen(new SolidBrush(lineColor)), new Point(first.X, first.Y), new Point(second.X, second.Y));
                                }
                            }

                        }
                    }
                }
           
            }
            foreach (Shape i in shapes.ToList()) i.Draw(e.Graphics, pointColor);
        }

        private void JarvisAlgorithm(PaintEventArgs e, Color lineColor)
        {
            Shape max = new Circle(int.MaxValue, int.MinValue);
            Shape realMax = new Circle(int.MaxValue, int.MinValue);
            foreach (Shape A in shapes)
            {
                if (A.Y > max.Y)
                {
                    max = A;
                }
                if(A.Y == max.Y)
                    {
                        if(A.X < max.X)
                        {
                            max = A;
                        }
                    }
            }
            Console.WriteLine("X: "+max.X + " Y: " + max.Y);

            foreach (Shape i in shapes.ToList()) i.Draw(e.Graphics, pointColor);
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
                    i.ChosenX = i.X - e.X;
                    i.ChosenY = i.Y - e.Y;
                }
            }
            if (shifted == false)
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

                    i.X = e.X + i.ChosenX;
                    i.Y = e.Y + i.ChosenY;
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
        private ColorDialog MyDialog = new ColorDialog();
        private void linesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyDialog.ShowDialog() == DialogResult.OK) { lineColor = MyDialog.Color; Refresh(); }
        }
        private void pointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MyDialog.ShowDialog() == DialogResult.OK) { pointColor = MyDialog.Color; Refresh(); }
        }
    }
}

