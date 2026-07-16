using Practice.Bridge;
using Practice.Interface1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Classes
{
    internal class VisualBezier : AVisualCurve
    {
        Graphics _g;
        private Bezier _bez;
        IPoint endpoint;
        IPoint preendpoint;
        int segments = 20;

        public VisualBezier(Bezier bez)
        {
            _bez = bez;
            
        }

        public VisualBezier(Bezier bez, Graphics g)
        {
            _bez = bez;
            _g = g;
            
        }

        public override void GetPoint(double t, out IPoint p)
        {
            _bez.GetPoint(t, out p);
        }

        public override void Draw(IImplementor _imp)
        {
            Pen pen = new Pen(Color.Black, 3);
            pen.DashStyle = DashStyle.Dash;

            _bez.GetPoint(0, out IPoint prevPoint);
            _imp.DrawStartPoint(_g, prevPoint);
            for (int i = 1; i <= segments; i++)
            {
                double t = (double)i / segments;
                _bez.GetPoint(t, out IPoint currentPoint);

                _imp.DrawLine(_g, prevPoint, currentPoint);

                prevPoint = currentPoint;

                if (i == segments - 1)
                {
                    preendpoint = currentPoint;
                }

                if (i == segments)
                {
                    endpoint = currentPoint;
                }
            }
            _imp.DrawEndPoint(_g, endpoint, preendpoint);
        }

        public override string ExportToSvg(IImplementor _imp)
        {
            var sb = new System.Text.StringBuilder();

            _bez.GetPoint(0, out IPoint startPoint);
            IPoint prevPoint = startPoint;


            sb.AppendLine(_imp.DrawStartPointSVG(startPoint));


            for (int i = 1; i <= segments; i++)
            {
                double t = (double)i / segments;
                _bez.GetPoint(t, out IPoint currentPoint);

                sb.AppendLine(_imp.DrawLineSVG(prevPoint, currentPoint));

                prevPoint = currentPoint;

                if (i == segments)
                {
                    endpoint = currentPoint;
                }
                if (i == segments - 1)
                {
                    preendpoint = currentPoint;
                }

            }

            sb.AppendLine(_imp.DrawEndPointSVG(endpoint, preendpoint));
            return sb.ToString();
        }
    }
}
