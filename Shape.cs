using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Многоугольники
{
    public abstract class Shape
    {
        protected int x, y, chosenX, chosenY;
        protected static int r;
        public bool dragged;
        public bool inShell;
        protected static Color lineC, pointC;
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

        public Color LineColor
        {
            get => lineC;
            set
            {
                lineC = value;
            }
        }
        public Color PointColor
        {
            get => pointC;
            set
            {
                pointC = value;
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
        public static int Radius
        {
            get => r;
            set
            {
                r = value;
            }
        }

        public abstract void Draw(Graphics g, Color color);
        public abstract bool IsInside(int xx, int yy);
    }
}
