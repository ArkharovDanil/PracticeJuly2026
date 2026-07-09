using Practice.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Classes
{
    internal class Bezier : ACurve
    {
        private IPoint _c;
        private IPoint _d;

        public Bezier(IPoint a, IPoint b, IPoint c, IPoint d) : base(a, b)
        {
            _c = c;
            _d = d;
        }

        public override void GetPoint(double t, out IPoint p)
        {
            Point point = new Point();
            point.SetX(CountX(t));
            point.SetY(CountY(t));
            p = point;
        }
        private double CountX(double t) //p = (1 − t) · a + t · b

        {
            return Math.Pow((1 - t), 3) * GetA().X + 3 * t * Math.Pow((1 - t), 2) * _c.X + 3 * Math.Pow(t, 2) * (1 - t) * _d.X + Math.Pow(t, 3) * GetB().X;
        }
        private double CountY(double t)
        {
            return Math.Pow((1 - t), 3) * GetA().Y + 3 * t * Math.Pow((1 - t), 2) * _c.Y + 3 * Math.Pow(t, 2) * (1 - t) * _d.Y + Math.Pow(t, 3) * GetB().Y;
        }
    }
}
