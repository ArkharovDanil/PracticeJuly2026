using Practice.Bridge;
using Practice.Interface1;
using System.Collections.Generic;
using System.Net;


namespace Practice.Classes
{
    public abstract class AVisualCurve : IDrawable, ICurve
    {
        ICurve _curve = null;
        private readonly int _segments = 20;
        public AVisualCurve()
        {

        }

        public AVisualCurve(ICurve curve)
        {
            _curve = curve;
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
                GetPoint(t, out IPoint currentPoint);

                DrawLine(prevPoint, currentPoint);

                prevPoint = currentPoint;

            }

            var t1 = (double)_segments / _segments;
            var t2 = (double)(_segments - 1) / _segments;
            GetPoint(t1, out IPoint endpoint);
            GetPoint(t2, out IPoint preEndpoint);
            DrawEndPoint(endpoint, preEndpoint);
        }

        public void GetPoint(double t, out IPoint p)
        {
            _curve.GetPoint(t, out p);
        }
    }
}
