using Practice.Bridge;
using Practice.interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace Practice.Classes
{
    internal class VisualBezier : AVisualCurve
    {
        private Bezier _bezier;
        IImplementor _dot;
        IPoint endpoint;
        public VisualBezier(Bezier bezier2)
        {
            _bezier = bezier2;
            _dot = new BlackRealization();
        }
        public override void GetPoint(double t, out IPoint p)
        {
            _bezier.GetPoint(t, out p);
        }
        public override void Draw(Graphics g)
        {
            int segments = 20;
            Pen pen = new Pen(Color.Black, 3);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            _bezier.GetPoint(0, out IPoint prevPoint);
            _dot.DrawStartPoint(g, prevPoint);
            for (int i=1; i<= segments; i++)
            {
                double t = (double)i / segments;
                _bezier.GetPoint(t, out IPoint currentPoint);
                g.DrawLine(pen, (float)prevPoint.X, (float)prevPoint.Y, (float)currentPoint.X, (float)currentPoint.Y);

                prevPoint = currentPoint;
                if (i == segments)
                {
                    endpoint = currentPoint;
                }
                
            }
            _dot.DrawEndPoint(g, endpoint, endpoint);
        }

        public override string ExportToSvg(int width, int height)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine($"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{width}\" height=\"{height}\">");

            _bezier.GetPoint(0, out IPoint startPoint);

            IPoint prevPoint = startPoint;
            int segments = 20;


            sb.AppendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "<rect x=\"{0}\" y=\"{1}\" width=\"10\" height=\"10\" fill=\"black\"/>",
                startPoint.X, startPoint.Y));


            for (int i = 1; i <= segments; i++)
            {
                double t = (double)i / segments;
                _bezier.GetPoint(t, out IPoint currentPoint);

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
