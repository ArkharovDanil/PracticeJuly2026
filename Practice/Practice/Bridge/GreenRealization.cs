using Practice.Classes;
using Practice.Interface1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace Practice.Bridge
{
    public class GreenRealization : IImplementor
    {
        Graphics g;
        private Line _line;
        IPoint endpoint;
        private List<string> _svg = new List<string>();
        int segments = 20;

        public void DrawStartPoint(Graphics g, IPoint startp)
        {
            using (Pen pen = new Pen(Color.Green, 5))
            {
                g.DrawEllipse(pen, (float)startp.X, (float)startp.Y, 3, 3);
            }
        }

        public void DrawLine(Graphics g, IPoint from, IPoint to)
        {
            using (Pen pen = new Pen(Color.Green, 3))
            {
                g.DrawLine(pen, (float)from.X, (float)from.Y, (float)to.X, (float)to.Y);
            }
        }

        public void DrawEndPoint(Graphics g, IPoint endp, IPoint preendp)
        {
            using (Pen pen = new Pen(Color.Green, 5))
            {
                pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                g.DrawLine(pen, (float)preendp.X, (float)preendp.Y, (float)endp.X, (float)endp.Y);
            }
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
    }
}
