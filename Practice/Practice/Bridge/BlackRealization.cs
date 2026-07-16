using Practice.Interface1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace Practice.Bridge
{
    public class BlackRealization : IImplementor
    {
        public void DrawStartPoint(Graphics g, IPoint startp)
        {
            using (Pen pen = new Pen(Color.Black, 5))
            {
                pen.Width = 6;
                g.DrawRectangle(pen, (float)startp.X, (float)startp.Y, 3, 3);
            }
        }

        public void DrawLine(Graphics g, IPoint from, IPoint to)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                pen.DashStyle = DashStyle.Dash;
                g.DrawLine(pen, (float)from.X, (float)from.Y, (float)to.X, (float)to.Y);
            }
        }

        public void DrawEndPoint(Graphics g, IPoint endp, IPoint preendp)
        {
            using (Pen pen = new Pen(Color.Black, 5))
            {
                pen.Width = 6;
                g.DrawRectangle(pen, (float)endp.X, (float)endp.Y, 3, 3);
            }
        }

        public string DrawStartPointSVG(IPoint startp)
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, "<rect x=\"{0}\" y=\"{1}\" width=\"10\" height=\"10\" fill=\"black\"/>",
        startp.X, startp.Y);
        }

        public string DrawLineSVG(IPoint from, IPoint to)
        {
            return string.Format(CultureInfo.InvariantCulture, "<line x1=\"{0}\" y1=\"{1}\" x2=\"{2}\" y2=\"{3}\" stroke=\"black\" stroke-width=\"2\" stroke-dasharray=\"5,3\" />",
        from.X, from.Y, to.X, to.Y);
        }

        public string DrawEndPointSVG(IPoint endp, IPoint preendp)
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, "<rect x=\"{0}\" y=\"{1}\" width=\"10\" height=\"10\" fill=\"black\"/>",
        endp.X, endp.Y);
        }
    }
}
