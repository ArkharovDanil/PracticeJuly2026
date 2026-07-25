using Practice.Interface1;
using System;


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

        public override double CountX(double t)
        {
            return Math.Pow(1 - t, 3) * GetA().X + 3 * t * Math.Pow(1 - t, 2) * _c.X + 3 * Math.Pow(t, 2) * (1 - t) * _d.X + Math.Pow(t, 3) * GetB().X;
        }

        public override double CountY(double t)
        {
            return Math.Pow(1 - t, 3) * GetA().Y + 3 * t * Math.Pow(1 - t, 2) * _c.Y + 3 * Math.Pow(t, 2) * (1 - t) * _d.Y + Math.Pow(t, 3) * GetB().Y;
        }
    }
}
