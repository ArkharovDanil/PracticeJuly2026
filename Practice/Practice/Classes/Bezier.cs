using Practice.Interfaces;

namespace Practice.Classes
{
    internal class Bezier : ACurve
    {
        IPoint _a;
        IPoint _b;
        IPoint _c;
        IPoint _d;
     
        public Bezier(IPoint a, IPoint b, IPoint c, IPoint d) : base(a, b)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
        }

        public override double CountX()
        {
            return _a.GetX() + _b.GetX() + _c.GetX() + _d.GetX();
        }

        public override double CountY()
        {
            return 0;
        }
    }
}
