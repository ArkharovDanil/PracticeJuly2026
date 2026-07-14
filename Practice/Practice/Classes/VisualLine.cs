using Aspose.Svg;
using Practice.Bridge;
using Practice.interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Classes
{
    public class VisualLine : AVisualCurve
    {
        IImplementor _dot;
        IPoint endpoint;
        IPoint preendpoint;
        private Line _line;

        public VisualLine(Line line2)
        {
            _line = line2;
            _dot = new GreenRealization();
        }
        public override void GetPoint(double t, out IPoint p)
        {
            _line.GetPoint(t, out p);
        }
        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Green, 3);
            int segments = 20;
            _line.GetPoint(0, out IPoint prevPoint);
            _dot.DrawStartPoint(g, prevPoint);
            for (int i = 1; i <= segments; i++)
            {
                double t = (double)i / segments;
                _line.GetPoint(t, out IPoint currentPoint);

                g.DrawLine(pen, (float)prevPoint.X,(float)prevPoint.Y,(float)currentPoint.X, (float)currentPoint.Y);

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
            _dot.DrawEndPoint(g, endpoint, preendpoint);
        }

        public override string ExportToSvg(int width, int height)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine($"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{width}\" height=\"{height}\">");

            _line.GetPoint(0, out IPoint startPoint);

            IPoint prevPoint = startPoint;
            int segments = 20;


            sb.AppendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "<circle cx=\"{0}\" cy=\"{1}\" r=\"5\" fill=\"green\"/>",
                startPoint.X, startPoint.Y));

            sb.AppendLine("<defs>");
            sb.AppendLine("<marker id=\"arrowhead\" markerWidth=\"5\" markerHeight=\"3.5\" refX=\"4.5\" refY=\"1.75\" orient=\"auto\">");
            sb.AppendLine("<polygon points=\"0 0, 5 1.75, 0 3.5\" fill=\"green\" />");
            sb.AppendLine("</marker>");
            sb.AppendLine("</defs>");

            for (int i = 1; i <= segments; i++)
            {
                double t = (double)i / segments;
                _line.GetPoint(t, out IPoint currentPoint);

                string markerAttr = (i == segments) ? " marker-end=\"url(#arrowhead)\"" : "";

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                    "<line x1=\"{0}\" y1=\"{1}\" x2=\"{2}\" y2=\"{3}\" stroke=\"green\" stroke-width=\"3\"{4} />",
                    prevPoint.X, prevPoint.Y, currentPoint.X, currentPoint.Y, markerAttr));

                prevPoint = currentPoint;

            }

            sb.AppendLine("</svg>");

            return sb.ToString();
        }
    }
}
