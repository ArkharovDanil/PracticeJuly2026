using Practice.Classes;
using Practice.Interface1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Bridge
{
    public class BlackRealizationSVG : AVisualCurve
    {
        public BlackRealizationSVG()
        {

        }
        public BlackRealizationSVG(AVisualCurve Parent) : base(Parent._fileBuffer)
        {

        }

        public override void DrawEndPoint(IPoint endp, IPoint preendp)
        {
            _fileBuffer = string.Format(System.Globalization.CultureInfo.InvariantCulture, "<rect x=\"{0}\" y=\"{1}\" width=\"10\" height=\"10\" fill=\"black\"/>",
        endp.X, endp.Y);
        }

        public override void DrawLine(IPoint from, IPoint to)
        {
            _fileBuffer = string.Format(CultureInfo.InvariantCulture, "<line x1=\"{0}\" y1=\"{1}\" x2=\"{2}\" y2=\"{3}\" stroke=\"black\" stroke-width=\"2\" stroke-dasharray=\"5,3\" />",
        from.X, from.Y, to.X, to.Y);
        }

        public override void DrawStartPoint(IPoint startp)
        {
            _fileBuffer = string.Format(System.Globalization.CultureInfo.InvariantCulture, "<rect x=\"{0}\" y=\"{1}\" width=\"10\" height=\"10\" fill=\"black\"/>",
        startp.X, startp.Y);
        }
    }
}
