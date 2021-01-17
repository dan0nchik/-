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
    public class Triangle : Shape
    {

        public Triangle(int xx, int yy) : base(xx, yy)
        {
        }
        public override void Draw(Graphics g, Color color)
        {
            //плохой код
            Point B = new Point(x, y - r);
            Point A = new Point(x - (int)(r * Math.Sqrt(3) / 2), (int)(y + (0.5 * r)));
            Point C = new Point(x + (int)(r * Math.Sqrt(3) / 2), (int)(y + (0.5 * r)));
            g.FillPolygon(new SolidBrush(color), new Point[] { A, B, C });
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
}
