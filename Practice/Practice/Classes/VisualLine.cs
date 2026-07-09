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
            Pen pen = new Pen(Color.Black, 3);

            int segments = 20;
            _line.GetPoint(0, out IPoint prevPoint);
            for(int i = 1; i <= segments; i++)
            {
                double t = (double)i / segments;
                _line.GetPoint(t, out IPoint currentPoint);

                g.DrawLine(pen, (float)prevPoint.X,(float)prevPoint.Y,(float)currentPoint.X, (float)currentPoint.Y);

                prevPoint = currentPoint;
            }
        }

        
    }
}
