using Practice.interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Bridge
{
    public class GreenRealization : IImplementor
    {
        private Pen pen = new Pen(Color.Green, 5);
        public void DrawStartPoint(Graphics g, IPoint start)
        {
            g.DrawEllipse(pen, (float)start.X, (float)start.Y, 5, 5);
        }
        public void DrawEndPoint(Graphics g, IPoint end, IPoint preendpoint)
        {
            pen.Width = 6;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            g.DrawLine(pen, (float)preendpoint.X, (float)preendpoint.Y, (float)end.X, (float)end.Y);
        }
    }
}
