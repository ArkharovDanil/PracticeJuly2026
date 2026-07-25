using Practice.Bridge;
using Practice.Interface1;
using System.Collections.Generic;
using System.Net;


namespace Practice.Classes
{
    public abstract class AVisualCurve : IDrawable, ICurve
    {
        ICurve _curve = null;
        private readonly int _segments = 20;
        public string _fileBuffer { get; set; } = null;
        public AVisualCurve()
        {

        }

        public AVisualCurve(string fileBuffer)
        {
            _fileBuffer = fileBuffer;
        }

        public AVisualCurve(ICurve curve)
        {
            _curve = curve;
        }

        public abstract void DrawLine(IPoint from, IPoint to);

        public abstract void DrawStartPoint(IPoint startp);

        public abstract void DrawEndPoint(IPoint endp, IPoint preendp);

        public void Draw()
        {

            GetPoint(0, out IPoint prevPoint);

            DrawStartPoint(prevPoint);
            for (int i = 1; i <= _segments; i++)
            {
                var t = (double)i / _segments;
                _curve.GetPoint(t, out IPoint currentPoint);

                DrawLine(prevPoint, currentPoint);

                prevPoint = currentPoint;

            }

            var t1 = (double)_segments / _segments;
            var t2 = (double)(_segments - 1) / _segments;
            _curve.GetPoint(t1, out IPoint endpoint);
            _curve.GetPoint(t2, out IPoint preEndpoint);
            DrawEndPoint(endpoint, preEndpoint);
        }

        public string BuildSVG(List<ICurve> curves, int width, int height, bool arrowmarker)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine($"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{width}\" height=\"{height}\">");
            if (arrowmarker)
            {
                sb.AppendLine("<defs>");
                sb.AppendLine("<marker id=\"arrowhead\" markerWidth=\"5\" markerHeight=\"3.5\" refX=\"4.5\" refY=\"1.75\" orient=\"auto\">");
                sb.AppendLine("<polygon points=\"0 0, 5 1.75, 0 3.5\" fill=\"green\" />");
                sb.AppendLine("</marker>");
                sb.AppendLine("</defs>");
            }
            foreach (var curve in curves)
            {
                sb.AppendLine(ExportToSvg(curve, arrowmarker));
            }
            sb.AppendLine("</svg>");
            return sb.ToString();
        }

        public string ExportToSvg(ICurve curve, bool isgr)
        {
            var sb = new System.Text.StringBuilder();

            curve.GetPoint(0, out IPoint startPoint);
            IPoint prevPoint = startPoint;
            
            DrawStartPoint(startPoint);
            sb.AppendLine(GetFileBuffer());


            for (int i = 1; i <= _segments; i++)
            {
                double t = (double)i / _segments;
                curve.GetPoint(t, out IPoint currentPoint);

                DrawLine(prevPoint, currentPoint);
                sb.AppendLine(GetFileBuffer());

                prevPoint = currentPoint;
            }


            var t1 = (double)_segments / _segments;
            var t2 = (double)(_segments - 1) / _segments;
            curve.GetPoint(t1, out IPoint endpoint);
            curve.GetPoint(t2, out IPoint preendpoint);
            DrawEndPoint(endpoint, preendpoint);

            sb.AppendLine(GetFileBuffer());
            return sb.ToString();
        }

        public void GetPoint(double t, out IPoint p)
        {
            _curve.GetPoint(t, out p);
        }

        public string GetFileBuffer()
        {
            return _fileBuffer;
        }
    }
}
