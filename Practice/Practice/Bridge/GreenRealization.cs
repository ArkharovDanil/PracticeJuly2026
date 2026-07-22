using Practice.Classes;
using Practice.Interface1;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using static System.Windows.Forms.AxHost;

namespace Practice.Bridge
{
    public class GreenRealization : AVisualCurve
    {
        Graphics _g;
        ICurve _curve = null;
        public GreenRealization(Graphics g, ICurve curve)
        {
            _g = g;
            _curve = curve;
        }

        public void DrawStartPoint(/*Graphics g, */IPoint startp)
        {

        }

        public void DrawLine(/*Graphics g, */IPoint from, IPoint to)
        {

        }

        public void DrawEndPoint(/*Graphics g, */IPoint endp, IPoint preendp)
        {

        }
        public string DrawStartPointSVG(IPoint startp)
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, "<circle cx=\"{0}\" cy=\"{1}\" r=\"5\" fill=\"green\" stroke=\"green\" stroke-width=\"3\" />",
                startp.X, startp.Y);
        }

        public string DrawLineSVG(IPoint from, IPoint to)
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, "<line x1=\"{0}\" y1=\"{1}\" x2=\"{2}\" y2=\"{3}\" stroke=\"green\" stroke-width=\"3\" />",
            from.X, from.Y, to.X, to.Y);
        }

        public string DrawEndPointSVG(IPoint endp, IPoint preendp)
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, "<line x1=\"{0}\" y1=\"{1}\" x2=\"{2}\" y2=\"{3}\" stroke=\"green\" stroke-width=\"3\" marker-end=\"url(#arrowhead)\"/>",
            preendp.X, preendp.Y, endp.X, endp.Y);
        }

        public override void DrawLine(IPoint from, IPoint to)
        {
            using (var pen = new Pen(Color.Green, 3))
            {
                _g.DrawLine(pen, (float)from.X, (float)from.Y, (float)to.X, (float)to.Y);
            }
        }

        public override void DrawStartPoint(IPoint startp)
        {
            using (var pen = new Pen(Color.Green, 5))
            {
                _g.DrawEllipse(pen, (float)startp.X, (float)startp.Y, 3, 3);
            }
        }

        public override void DrawEndPoint(IPoint endp, IPoint preendp)
        {
            using (var pen = new Pen(Color.Green, 5))
            {
                pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                _g.DrawLine(pen, (float)preendp.X, (float)preendp.Y, (float)endp.X, (float)endp.Y);
            }
        }

        public override void Draw()
        {
            throw new System.NotImplementedException();
        }

        public override void GetPoint(double t, out IPoint p)
        {
            throw new System.NotImplementedException();
        }
    }
}
