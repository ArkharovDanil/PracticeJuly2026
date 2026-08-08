using Practice.interfaces;
using Practice.Classes;

namespace Practice.Decorator
{
    internal class MoveTo : Decorator
    {
        private double _x;
        private double _y;

        public MoveTo(ICurve curve, IPoint point) : base(curve)
        {
            _curve = curve;

            curve.GetPoint(0, out IPoint originalStart);
            _x = point.X - originalStart.X;
            _y = point.Y - originalStart.Y;
        }

        public override void GetPoint(double t, out IPoint p)
        {
            _curve.GetPoint(t, out IPoint originalPoint);
            p = new Point(originalPoint.X + _x, originalPoint.Y + _y);
        }
    }
}
