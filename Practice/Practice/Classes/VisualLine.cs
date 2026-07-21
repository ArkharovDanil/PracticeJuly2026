using Practice.Interface1;
using System.Collections.Generic;
using System.Drawing;


namespace Practice.Classes
{
    internal class VisualLine : AVisualCurve
    {
        Graphics _g;
        private Line _line;
        IPoint endpoint;
        IPoint preendpoint;
        int segments = 20;

        public VisualLine(Line line)
        {
            _line = line;
        }

        public VisualLine(Line line, Graphics g)
        {
            _line = line;
            _g = g;
        }

        public override void GetPoint(double t, out IPoint p)
        {
            _line.GetPoint(t, out p);
        }

        public override void Draw(IImplementor _imp)
        {
            _line.GetPoint(0, out IPoint prevPoint);

            _imp.DrawStartPoint(/*_g, */prevPoint);

            for (int i = 1; i <= segments; i++)
            {
                var t = (double)i / segments;
                _line.GetPoint(t, out IPoint currentPoint);

                _imp.DrawLine(/*_g, */prevPoint, currentPoint);

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
            _imp.DrawEndPoint(/*_g, */endpoint, preendpoint);

        }

        public override string ExportToSvg(IImplementor _imp)
        {
            var sb = new System.Text.StringBuilder();

            _line.GetPoint(0, out IPoint startPoint);
            IPoint prevPoint = startPoint;

            sb.AppendLine(_imp.DrawStartPointSVG(startPoint));

            for (int i = 1; i <= segments; i++)
            {
                var t = (double)i / segments;
                _line.GetPoint(t, out IPoint currentPoint);

                sb.AppendLine(_imp.DrawLineSVG(prevPoint, currentPoint));

                prevPoint = currentPoint;

                if (i == segments)
                {
                    endpoint = currentPoint;
                }

                if (i == segments)
                {
                    preendpoint = currentPoint;
                }

            }

            sb.AppendLine(_imp.DrawEndPointSVG(endpoint, preendpoint));
            
            return sb.ToString();
        }
    }
}
