using Practice.Classes;
using Practice.interfaces;
using System.Text;

namespace Practice.Bridge
{
    internal class GreenRealizationSVG : AVisualCurve
    {
        StringBuilder _filebuffer = new StringBuilder();
        public GreenRealizationSVG(ICurve curve) : base(curve)
        {
        }

        public override void DrawEndPoint(IPoint endp, IPoint preendp)
        {
            _filebuffer.AppendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "<line x1=\"{0}\" y1=\"{1}\" x2=\"{2}\" y2=\"{3}\" stroke=\"green\" stroke-width=\"3\" marker-end=\"url(#arrowhead)\"/>",
                preendp.X, preendp.Y, endp.X, endp.Y));
        }

        public override void DrawLine(IPoint from, IPoint to)
        {
            _filebuffer.AppendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "<line x1=\"{0}\" y1=\"{1}\" x2=\"{2}\" y2=\"{3}\" stroke=\"green\" stroke-width=\"3\" />",
                from.X, from.Y, to.X, to.Y));
        }

        public override void DrawStartPoint(IPoint startp)
        {
            _filebuffer.AppendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "<circle cx=\"{0}\" cy=\"{1}\" r=\"5\" fill=\"green\"/>",
                startp.X, startp.Y));
        }
        public string GetFileBuffer()
        {
            return _filebuffer.ToString();
        }
    }
}
