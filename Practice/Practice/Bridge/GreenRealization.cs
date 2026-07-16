using Practice.interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.PeerToPeer.Collaboration;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Bridge
{
    public class GreenRealization : IImplementor
    {
        public void DrawStartPoint(Graphics g, IPoint start)
        {
            using (Pen pen = new Pen(Color.Green, 5))
            {
                g.DrawEllipse(pen, (float)start.X, (float)start.Y, 5, 5);
            }
        }
        public void DrawEndPoint(Graphics g, IPoint end, IPoint preendpoint)
        {
            using (Pen pen = new Pen(Color.Green, 5)) 
            {

                pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

                g.DrawLine(pen, (float)preendpoint.X, (float)preendpoint.Y, (float)end.X, (float)end.Y);
            }
               
            
        }

        public void DrawLine(Graphics g, IPoint from, IPoint to)
        {
            using (Pen pen = new Pen(Color.Green, 3))
            {
                g.DrawLine(pen, (float)from.X, (float)from.Y, (float)to.X, (float)to.Y);
            }
            
        }

        public string DrawStartPointSVG(IPoint start)
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, "<circle cx=\"{0}\" cy=\"{1}\" r=\"5\" fill=\"green\"/>",
                start.X, start.Y);
        }

        public string DrawEndPointSVG(IPoint end, IPoint preendpoint)
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, "<line x1=\"{0}\" y1=\"{1}\" x2=\"{2}\" y2=\"{3}\" stroke=\"green\" stroke-width=\"3\" marker-end=\"url(#arrowhead)\"/>",
                preendpoint.X, preendpoint.Y, end.X, end.Y);
        }

        public string DrawLineSVG(IPoint from, IPoint to)
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, "<line x1=\"{0}\" y1=\"{1}\" x2=\"{2}\" y2=\"{3}\" stroke=\"green\" stroke-width=\"3\" />",
                from.X, from.Y, to.X, to.Y);
        }
    }
}
