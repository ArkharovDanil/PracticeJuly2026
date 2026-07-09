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
            IPoint p1 = _bez.GetA();
            IPoint p2 = _bez.GetB();
            IPoint p3 = _bez.GetC();
            IPoint p4 = _bez.GetD();
            Pen pen = new Pen(Color.Red, 3);
            g.DrawLine(pen, (float)p1.X, (float)p1.Y, (float)p2.X, (float)p2.Y);
            g.DrawLine(pen, (float)p2.X, (float)p2.Y, (float)p3.X, (float)p3.Y);
            g.DrawLine(pen, (float)p3.X, (float)p3.Y, (float)p4.X, (float)p4.Y);
        }
    }
}
