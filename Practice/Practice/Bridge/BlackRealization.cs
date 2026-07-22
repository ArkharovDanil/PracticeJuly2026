using Practice.Classes;
using Practice.Interface1;
using System.CodeDom;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Practice.Bridge
{
    public class BlackRealization : AVisualCurve
    {
        Graphics _g;

        public BlackRealization(ICurve curve,Options options) : base(curve)
        {
            _g = options.Graphics;
        }

        public override void DrawLine(IPoint from, IPoint to)
        {
            using (var pen = new Pen(Color.Black, 2))
            {
                pen.DashStyle = DashStyle.Dash;
                _g.DrawLine(pen, (float)from.X, (float)from.Y, (float)to.X, (float)to.Y);
            }
        }

        public override void DrawStartPoint(IPoint startp)
        {
            using (var pen = new Pen(Color.Black, 5))
            {
                pen.Width = 6;
                _g.DrawRectangle(pen, (float)startp.X, (float)startp.Y, 3, 3);
            }
        }

        public override void DrawEndPoint(IPoint endp, IPoint preendp)
        {
            DrawStartPoint(endp);
        }
    }
}
