using Practice.interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Classes
{
    public class VisualLine : AVisualCurve
    {
        private Line _line;

        public VisualLine(Line line2)
        {
            _line = line2;
        }
        public override void GetPoint(double t, out IPoint p)
        {
            _line.GetPoint(t, out p);
        }
        public override void Draw(Graphics g)
        {
            IPoint start = _line.GetA();
            IPoint end = _line.GetB();
            Pen pen = new Pen(Color.Black, 3);
            g.DrawLine(pen, (float)start.X, (float)start.Y, (float)end.X, (float)end.Y);
        }

        
    }
}
