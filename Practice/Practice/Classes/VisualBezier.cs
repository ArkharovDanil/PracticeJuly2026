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
        private Bezier _bez;
        IImplementor _implementor;
        IPoint endpoint;

        public VisualBezier(Bezier bez)
        {
            _bez = bez;
            _implementor = new BlackRealization();
        }

        public override void GetPoint(double t, out IPoint p)
        {
            _bez.GetPoint(t, out p);
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            pen.DashStyle = DashStyle.Dash;

            int segments = 20;
            _bez.GetPoint(0, out IPoint prevPoint);
            _implementor.DrawStartPoint(g, prevPoint);
            for (int i = 1; i <= segments; i++)
            {
                double t = (double)i / segments;
                _bez.GetPoint(t, out IPoint currentPoint);

                g.DrawLine(pen, (float)prevPoint.X, (float)prevPoint.Y, (float)currentPoint.X, (float)currentPoint.Y);

                prevPoint = currentPoint;
                if (i == segments)
                {
                    endpoint = currentPoint;
                }
            }
            _implementor.DrawEndPoint(g, endpoint, endpoint);
        }

        public override string ExportToSvg(int width, int height)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine($"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{width}\" height=\"{height}\">");

            _bez.GetPoint(0, out IPoint startPoint);

            IPoint prevPoint = startPoint;
            int segments = 20;


            sb.AppendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "<rect x=\"{0}\" y=\"{1}\" width=\"10\" height=\"10\" fill=\"black\"/>",
                startPoint.X, startPoint.Y));


            for (int i = 1; i <= segments; i++)
            {
                double t = (double)i / segments;
                _bez.GetPoint(t, out IPoint currentPoint);

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    "<line x1=\"{0}\" y1=\"{1}\" x2=\"{2}\" y2=\"{3}\" stroke=\"black\" stroke-width=\"3\" stroke-dasharray=\"10\"/>",
                    prevPoint.X, prevPoint.Y, currentPoint.X, currentPoint.Y));

                prevPoint = currentPoint;

                if (i == segments)
                {
                    endpoint = currentPoint;
                }

            }

            sb.AppendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "<rect x=\"{0}\" y=\"{1}\" width=\"10\" height=\"10\" fill=\"black\"/>",
                endpoint.X, endpoint.Y));



            sb.AppendLine("</svg>");

            return sb.ToString();
        }
    }
}
