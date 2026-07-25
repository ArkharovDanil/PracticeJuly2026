using Practice.interfaces;
using System.Collections.Generic;

namespace Practice.Classes
{
    public abstract class AVisualCurve : IDrawable, ICurve
    {
        ICurve _curve = null;
        List<ICurve> _curves = new List<ICurve>();
        private readonly int _segments = 20;

        public AVisualCurve(ICurve curve)
        {
            _curve = curve;
        }
        public AVisualCurve()
        {
        }

        public abstract void DrawLine(IPoint from, IPoint to);

        public abstract void DrawStartPoint(IPoint startp);

        public abstract void DrawEndPoint(IPoint endp, IPoint preendp);

        public void Draw()
        {

            GetPoint(0, out IPoint prevPoint);

            DrawStartPoint(prevPoint);
            for (int i = 1; i <= _segments; i++)
            {
                var t = (double)i / _segments;
                _curve.GetPoint(t, out IPoint currentPoint);

                DrawLine(prevPoint, currentPoint);

                prevPoint = currentPoint;

            }

            var t1 = (double)_segments / _segments;
            var t2 = (double)(_segments - 1) / _segments;
            _curve.GetPoint(t1, out IPoint endpoint);
            _curve.GetPoint(t2, out IPoint preEndpoint);
            DrawEndPoint(endpoint, preEndpoint);
        }

        public void GetPoint(double t, out IPoint p)
        {
            _curve.GetPoint(t, out p);
        }

    }
}