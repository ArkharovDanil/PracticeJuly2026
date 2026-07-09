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
            IPoint p1 = _bezier.GetA();
            IPoint p2 = _bezier.GetB();
            IPoint p3 = _bezier.GetC();
            IPoint p4 = _bezier.GetD();

            Pen pen = new Pen(Color.Red, 3);
            g.DrawLine(pen, (float)p1.X, (float)p1.Y, (float)p2.X, (float)p2.Y);
            g.DrawLine(pen, (float)p2.X, (float)p2.Y, (float)p3.X, (float)p3.Y);
            g.DrawLine(pen, (float)p3.X, (float)p3.Y, (float)p4.X, (float)p4.Y);
        }
    }
}
