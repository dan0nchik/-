using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Многоугольники
{

    class Algorithm
    {
        public void ByDefinitionAlgorithm(PaintEventArgs e, Color lineColor, List<Shape> shapes)
        {
            double k, b;
            int topCount, bottomCount, rightCount, leftCount;

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

        public void ByDefinitionAlgorithm(List<Shape> shapes)
        {
            double k, b;
            int topCount, bottomCount, rightCount, leftCount;

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
                            }
                        }

                    }
                }

            }
        }

        public void JarvisAlgorithm(PaintEventArgs e, Color lineColor, List<Shape> shapes)
        {

            int indexA = 0, indexP = 0, nextIndex = 0;
            for (int i = 0; i < shapes.Count; ++i)
            {
                if (shapes[indexA].Y < shapes[i].Y)
                {
                    indexA = i;
                }
            }
            double minCos = double.MaxValue;
            Point M = new Point(shapes[indexA].X - 1000, shapes[indexA].Y);

            for (int i = 0; i < shapes.Count; i++)
            {
                if (i != indexA)
                {
                    if (Cos(shapes[i], shapes[indexA], M) < minCos)
                    {
                        indexP = i;
                        minCos = Cos(shapes[i], shapes[indexA], M);
                    }
                }
            }
            e.Graphics.DrawLine(new Pen(new SolidBrush(lineColor)), new Point(shapes[indexA].X, shapes[indexA].Y), new Point(shapes[indexP].X, shapes[indexP].Y));
            shapes[indexA].inShell = true;
            shapes[indexP].inShell = true;
            int endPointIndex = indexA;
            do
            {
                minCos = double.MaxValue;
                for (int j = 0; j < shapes.Count; j++)
                {
                    if (j != indexA)
                    {
                        if (Cos(shapes[indexA], shapes[indexP], new Point(shapes[j].X, shapes[j].Y)) < minCos)
                        {
                            minCos = Cos(shapes[indexA], shapes[indexP], new Point(shapes[j].X, shapes[j].Y));
                            nextIndex = j;
                        }
                    }
                }

                e.Graphics.DrawLine(new Pen(new SolidBrush(lineColor)), new Point(shapes[indexP].X, shapes[indexP].Y), new Point(shapes[nextIndex].X, shapes[nextIndex].Y));
                shapes[nextIndex].inShell = true;
                indexA = indexP;
                indexP = nextIndex;
            } while (indexP != endPointIndex);

        }
        public void JarvisAlgorithm(List<Shape> shapes)
        {

            {
                int indexA = 0, indexP = 0, nextIndex = 0;
                for (int i = 0; i < shapes.Count; ++i)
                {
                    if (shapes[indexA].Y < shapes[i].Y)
                    {
                        indexA = i;
                    }
                }
                double minCos = double.MaxValue;
                Point M = new Point(shapes[indexA].X - 1000, shapes[indexA].Y);

                for (int i = 0; i < shapes.Count; i++)
                {
                    if (i != indexA)
                    {
                        if (Cos(shapes[i], shapes[indexA], M) < minCos)
                        {
                            indexP = i;
                            minCos = Cos(shapes[i], shapes[indexA], M);
                        }
                    }
                }
                shapes[indexA].inShell = true;
                shapes[indexP].inShell = true;
                int endPointIndex = indexA;
                do
                {
                    minCos = double.MaxValue;
                    for (int j = 0; j < shapes.Count; j++)
                    {
                        if (j != indexA)
                        {
                            if (Cos(shapes[indexA], shapes[indexP], new Point(shapes[j].X, shapes[j].Y)) < minCos)
                            {
                                minCos = Cos(shapes[indexA], shapes[indexP], new Point(shapes[j].X, shapes[j].Y));
                                nextIndex = j;
                            }
                        }
                    }

                    shapes[nextIndex].inShell = true;
                    indexA = indexP;
                    indexP = nextIndex;
                } while (indexP != endPointIndex);
            }
        }

        public bool CheckIfInHull(List<Shape> shapes)
        {


            int indexA = 0, indexP = 0, nextIndex = 0;
            for (int i = 0; i < shapes.Count; ++i)
            {
                if (shapes[indexA].Y < shapes[i].Y)
                {
                    indexA = i;
                }
            }
            double minCos = double.MaxValue;
            Point M = new Point(shapes[indexA].X - 1000, shapes[indexA].Y);

            for (int i = 0; i < shapes.Count; i++)
            {
                if (i != indexA)
                {
                    if (Cos(shapes[i], shapes[indexA], M) < minCos)
                    {
                        indexP = i;
                        minCos = Cos(shapes[i], shapes[indexA], M);
                    }
                }
            }
            shapes[indexA].inShell = true;
            shapes[indexP].inShell = true;
            int endPointIndex = indexA;
            do
            {
                minCos = double.MaxValue;
                for (int j = 0; j < shapes.Count; j++)
                {
                    if (j != indexA)
                    {
                        if (Cos(shapes[indexA], shapes[indexP], new Point(shapes[j].X, shapes[j].Y)) < minCos)
                        {
                            minCos = Cos(shapes[indexA], shapes[indexP], new Point(shapes[j].X, shapes[j].Y));
                            nextIndex = j;
                        }
                    }
                }

                shapes[nextIndex].inShell = true;
                indexA = indexP;
                indexP = nextIndex;
            } while (indexP != endPointIndex);
            if (!shapes.Last().inShell) return false;
            return true;
        }

        public void ParallelJarvis(List<Shape> shapes)
        {
            int indexA = 0, indexA1 = 0, indexP = 0, nextIndex = 0, indexP1 = 0, nextIndex1 = 0;
            double minCos = double.MaxValue;
            double minCos1 = double.MaxValue;
            Point M = new Point(shapes[indexA].X - 1000, shapes[indexA].Y);
            Point M1 = new Point(shapes[indexA].X - 1000, shapes[indexA].Y);

            //схема алгоритма https://i.imgur.com/LiRMF0t.jpg

            async void Core()
            {

                await Task.Run(async () =>
                {
                    for (int i = 0; i < shapes.Count; ++i)
                    {
                        if (shapes[indexA].Y < shapes[i].Y)
                        {
                            indexA = i;
                        }
                    }


                    for (int i = 0; i < shapes.Count; i++)
                    {
                        if (i != indexA)
                        {
                            if (await AsyncCos(shapes[i], shapes[indexA], M) < minCos)
                            {
                                indexP = i;
                                minCos = await AsyncCos(shapes[i], shapes[indexA], M);
                            }
                        }
                    }
                    shapes[indexA].inShell = true;
                    shapes[indexP].inShell = true;

                    do
                    {
                        minCos = double.MaxValue;
                        for (int j = 0; j < shapes.Count; j++)
                        {
                            if (j != indexA)
                            {
                                if (await AsyncCos(shapes[indexA], shapes[indexP], new Point(shapes[j].X, shapes[j].Y)) < minCos)
                                {
                                    minCos = await AsyncCos(shapes[indexA], shapes[indexP], new Point(shapes[j].X, shapes[j].Y));
                                    nextIndex = j;
                                }
                            }
                        }

                        shapes[nextIndex].inShell = true;
                        indexA = indexP;
                        indexP = nextIndex;
                    } while (indexP != indexA1);
                });


            }

            async void Core1()
            {
                await Task.Run(async () =>
                {
                    for (int i = 0; i < shapes.Count; ++i)
                    {
                        if (shapes[indexA1].Y > shapes[i].Y)
                        {
                            indexA1 = i;
                        }
                    }

                    for (int i = 0; i < shapes.Count; i++)
                    {
                        if (i != indexA1)
                        {
                            if (await AsyncCos(shapes[i], shapes[indexA1], M1) < minCos1)
                            {
                                indexP1 = i;
                                minCos1 = await AsyncCos(shapes[i], shapes[indexA1], M1);
                            }
                        }
                    }
                    shapes[indexP1].inShell = true;
                    shapes[indexA1].inShell = true;
                    do
                    {
                        minCos1 = double.MaxValue;
                        for (int j = 0; j < shapes.Count; j++)
                        {
                            if (j != indexA1)
                            {
                                if (await AsyncCos(shapes[indexA1], shapes[indexP1], new Point(shapes[j].X, shapes[j].Y)) < minCos1)
                                {
                                    minCos1 = await AsyncCos(shapes[indexA1], shapes[indexP1], new Point(shapes[j].X, shapes[j].Y));
                                    nextIndex1 = j;
                                }
                            }
                        }

                        shapes[nextIndex1].inShell = true;
                        indexA1 = indexP1;
                        indexP1 = nextIndex1;
                    }
                    while (indexP1 != indexA);

                });
            }

            Core();
            Core1();

        }

        public double Cos(Shape one, Shape two, Point three)
        {
            Point v1 = new Point(two.X - one.X, two.Y - one.Y);
            Point v2 = new Point(two.X - three.X, two.Y - three.Y);
            return ((v1.X * v2.X) + (v1.Y * v2.Y)) / (Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y) * Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y));
        }

        public async Task<double> AsyncCos(Shape one, Shape two, Point three)
        {
            double angle = 0;
            await Task.Run(() =>
            {
                Point v1 = new Point(two.X - one.X, two.Y - one.Y);
                Point v2 = new Point(two.X - three.X, two.Y - three.Y);
                angle = ((v1.X * v2.X) + (v1.Y * v2.Y)) / (Math.Sqrt(v1.X * v1.X + v1.Y * v1.Y) * Math.Sqrt(v2.X * v2.X + v2.Y * v2.Y));
            });
            return angle;
        }
    }
}
