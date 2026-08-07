using Practice.Interface1;

namespace Practice.Decorator
{
    public abstract class Decorator : ICurve
    {
        public ICurve _curve;

        public Decorator(ICurve curve)
        {
            _curve = curve;
        }
        public abstract void GetPoint(double t, out IPoint p);
    }
}
