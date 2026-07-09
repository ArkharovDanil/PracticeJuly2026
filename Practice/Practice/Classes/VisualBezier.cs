using Practice.Interface1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Classes
{
    internal class VisualBezier : AVisualCurve
    {
        private Bezier _bez;

        public VisualBezier(Bezier bez)
        {
            _bez = bez;
        }

        public override void GetPoint(double t, out IPoint p)
        {
            _bez.GetPoint(t, out p);
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Red, 3);

            int segments = 20;
            _bez.GetPoint(0, out IPoint prevPoint);
            for (int i = 1; i <= segments; i++)
            {
                double t = (double)i / segments;
                _bez.GetPoint(t, out IPoint currentPoint);

                g.DrawLine(pen, (float)prevPoint.X, (float)prevPoint.Y, (float)currentPoint.X, (float)currentPoint.Y);

                prevPoint = currentPoint;
            }
        }
    }
}
