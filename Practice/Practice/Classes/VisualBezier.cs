using Practice.interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace Practice.Classes
{
    internal class VisualBezier : AVisualCurve
    {
        private Bezier _bezier;
        public VisualBezier(Bezier bezier2)
        {
            _bezier = bezier2;
        }
        public override void GetPoint(double t, out IPoint p)
        {
            _bezier.GetPoint(t, out p);
        }
        public override void Draw(Graphics g)
        {
            int segments = 20;
            Pen pen = new Pen(Color.Red, 3);
            _bezier.GetPoint(0, out IPoint prevPoint);
            for (int i=1; i<= segments; i++)
            {
                double t = (double)i / segments;
                _bezier.GetPoint(t, out IPoint currentPoint);
                g.DrawLine(pen, (float)prevPoint.X, (float)prevPoint.Y, (float)currentPoint.X, (float)currentPoint.Y);

                prevPoint = currentPoint;
            }
        }
    }
}
