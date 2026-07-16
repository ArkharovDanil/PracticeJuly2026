using Practice.interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Bridge
{
    public class BlackRealization : IImplementor
    {
        public void DrawStartPoint(Graphics g, IPoint start)
        {
            using (Pen pen = new Pen(Color.Black, 5))
            {
                g.DrawRectangle(pen, (float)start.X, (float)start.Y, 5, 5); ;
            }
        }
        public void DrawEndPoint(Graphics g, IPoint end, IPoint preendpoint)
        {
            using (Pen pen = new Pen(Color.Black, 5))
            {
                g.DrawRectangle(pen, (float)end.X, (float)end.Y, 5, 5);
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

        public string DrawStartPointSVG(IPoint start)
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, "<rect x=\"{0}\" y=\"{1}\" width=\"10\" height=\"10\" fill=\"black\"/>",
                start.X, start.Y);
        }

        public string DrawEndPointSVG(IPoint end, IPoint preendpoint)
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, "<rect x=\"{0}\" y=\"{1}\" width=\"10\" height=\"10\" fill=\"black\"/>",
                end.X, end.Y);
        }

        public string DrawLineSVG(IPoint from, IPoint to)
        {
            return string.Format(CultureInfo.InvariantCulture, "<line x1=\"{0}\" y1=\"{1}\" x2=\"{2}\" y2=\"{3}\" stroke=\"black\" stroke-width=\"2\" stroke-dasharray=\"5,3\" />",
                from.X, from.Y, to.X, to.Y);
        }
    }
}
