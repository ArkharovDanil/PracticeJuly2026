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
        IPoint endpoint;
        IPoint preendpoint;
        private Line _line;
        private int segments = 20;
        Graphics _g;


        public VisualLine(Line line2, Graphics g)
        {
            _line = line2;
            _g = g;
        }
        public VisualLine(Line line2)
        {
            _line = line2;
        }
        public override void GetPoint(double t, out IPoint p)
        {
            _line.GetPoint(t, out p);
        }
        public override void Draw(IImplementor _implementor)
        {

            _line.GetPoint(0, out IPoint prevPoint);
            _implementor.DrawStartPoint(_g, prevPoint);
            for (int i = 1; i <= segments; i++)
            {
                double t = (double)i / segments;
                _line.GetPoint(t, out IPoint currentPoint);

                _implementor.DrawLine(_g, prevPoint,currentPoint);

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
            _implementor.DrawEndPoint(_g, endpoint, preendpoint);
        }

        public override string ExportToSvg(IImplementor _implementor)
        {
            var sb = new System.Text.StringBuilder();

            _line.GetPoint(0, out IPoint startPoint);

            IPoint prevPoint = startPoint;


            sb.AppendLine(_implementor.DrawStartPointSVG(startPoint));


            for (int i = 1; i <= segments; i++)
            {
                double t = (double)i / segments;
                _line.GetPoint(t, out IPoint currentPoint);

                sb.AppendLine(_implementor.DrawLineSVG(prevPoint,currentPoint));

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

            sb.AppendLine(_implementor.DrawEndPointSVG(endpoint, preendpoint));

            return sb.ToString();
        }
    }
}
