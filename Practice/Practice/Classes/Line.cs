using Practice.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Classes
{
    public class Line : ACurve
    {
        public Line(IPoint a, IPoint b) : base(a, b)
        {
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
            return (1 - t) * GetA().X + t * GetB().X;
        }
        private double CountY(double t)
        {
            return (1 - t) * GetA().Y + t * GetB().Y;
        }
    }
}
