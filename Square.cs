using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Многоугольники.Form1;

namespace Многоугольники
{
    [Serializable()]
    public class Square : Shape
    {
        public Square(int xx, int yy) : base(xx, yy)
        {
        }
        public override void Draw(Graphics g, Color color)
        {
            Point[] points = new Point[]
            {
            new Point(X - (int)(Math.Sqrt(2) * R / 2), Y + (int)(Math.Sqrt(2) * R / 2)),
            new Point(X - (int)(Math.Sqrt(2) * R / 2), Y - (int)(Math.Sqrt(2) * R / 2)),
            new Point(X + (int)(Math.Sqrt(2) * R / 2), Y - (int)(Math.Sqrt(2) * R / 2)),
            new Point(X + (int)(Math.Sqrt(2) * R / 2), Y + (int)(Math.Sqrt(2) * R / 2))
            };

            g.FillPolygon(new SolidBrush(color), points);
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
