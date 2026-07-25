using Practice.Classes;
using Practice.interfaces;
using System.Globalization;
using System.Text;

namespace Practice.Bridge
{
    internal class BlackRealizationSVG : AVisualCurve
    {
        StringBuilder _filebuffer = new StringBuilder();
        public BlackRealizationSVG(ICurve curve) : base(curve)
        {
        }

        public override void DrawEndPoint(IPoint endp, IPoint preendp)
        {
            _filebuffer.AppendLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "<rect x=\"{0}\" y=\"{1}\" width=\"10\" height=\"10\" fill=\"black\"/>",
                endp.X, endp.Y));
        }

        public override void DrawLine(IPoint from, IPoint to)
        {
            _filebuffer.AppendLine(string.Format(CultureInfo.InvariantCulture, "<line x1=\"{0}\" y1=\"{1}\" x2=\"{2}\" y2=\"{3}\" stroke=\"black\" stroke-width=\"2\" stroke-dasharray=\"5,3\" />",
                from.X, from.Y, to.X, to.Y));
        }

        public override void DrawStartPoint(IPoint startp)
        {
            _filebuffer.AppendLine (string.Format(System.Globalization.CultureInfo.InvariantCulture, "<rect x=\"{0}\" y=\"{1}\" width=\"10\" height=\"10\" fill=\"black\"/>",
                startp.X, startp.Y));
        }

        public string GetFileBuffer()
        {
            return _filebuffer.ToString();
        }

    }
}
