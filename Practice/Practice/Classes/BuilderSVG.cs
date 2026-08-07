using Practice.Bridge;
using Practice.Interface1;
using System.Collections.Generic;

namespace Practice.Classes
{
    internal class BuilderSVG
    {
        public string BuildSVG(List<ICurve> _curves, int width, int height, bool arrowmarker)
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
                foreach (var curve in _curves)
                {
                    var curveSVG = new GreenRealizationSVG(curve);
                    curveSVG.Draw();
                    sb.AppendLine(curveSVG.GetFileBuffer());
                }
            }
            else
            {
                foreach (var curve in _curves)
                {
                    var curveSVG = new BlackRealizationSVG(curve);
                    curveSVG.Draw();
                    sb.AppendLine(curveSVG.GetFileBuffer());
                }
            }

            sb.AppendLine("</svg>");
            return sb.ToString();
        }
    }
}