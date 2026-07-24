using Practice.Classes;
using Practice.Interface1;

namespace Practice.Bridge
{
    public class GreenRealizationSVG : AVisualCurve
    {
        public GreenRealizationSVG()
        {
     
        }

        public GreenRealizationSVG(AVisualCurve Parent) : base(Parent._fileBuffer)
        {
           
        }

        public override void DrawEndPoint(IPoint endp, IPoint preendp)
        {
            _fileBuffer = string.Format(System.Globalization.CultureInfo.InvariantCulture, "<line x1=\"{0}\" y1=\"{1}\" x2=\"{2}\" y2=\"{3}\" stroke=\"green\" stroke-width=\"3\" marker-end=\"url(#arrowhead)\"/>",
            preendp.X, preendp.Y, endp.X, endp.Y);
        }

        public override void DrawLine(IPoint from, IPoint to)
        {
            _fileBuffer = string.Format(System.Globalization.CultureInfo.InvariantCulture, "<line x1=\"{0}\" y1=\"{1}\" x2=\"{2}\" y2=\"{3}\" stroke=\"green\" stroke-width=\"3\" />",
            from.X, from.Y, to.X, to.Y);
        }

        public override void DrawStartPoint(IPoint startp)
        {
            _fileBuffer = string.Format(System.Globalization.CultureInfo.InvariantCulture, "<circle cx=\"{0}\" cy=\"{1}\" r=\"5\" fill=\"green\" stroke=\"green\" stroke-width=\"3\" />",
                startp.X, startp.Y);
        }
    }
}
