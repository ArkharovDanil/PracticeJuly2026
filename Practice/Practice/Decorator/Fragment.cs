using Practice.interfaces;

namespace Practice.Decorator
{
    public class Fragment : Decorator
    {
        private double _tStart;
        private double _tEnd;

        public Fragment(ICurve curve, double tStart, double tEnd) : base(curve)
        {
            _tStart = tStart;
            _tEnd = tEnd;
        }

        public override void GetPoint(double t, out IPoint p)
        {
            double nowT = _tStart + t * (_tEnd - _tStart);
            _curve.GetPoint(nowT, out p);
        }
    }
}
