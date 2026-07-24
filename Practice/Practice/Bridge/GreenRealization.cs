using Practice.Classes;
using Practice.Interface1;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Net;
using static System.Windows.Forms.AxHost;

namespace Practice.Bridge
{
    public class GreenRealization : AVisualCurve
    {
        Graphics _g;

        public GreenRealization(ICurve curve, Options options) : base(curve)
        {
            _g = options.Graphics;
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
    }
}
