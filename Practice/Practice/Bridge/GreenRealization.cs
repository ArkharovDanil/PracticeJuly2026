using Practice.Interface1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace Practice.Bridge
{
    public class GreenRealization : IImplementor
    {
        private Pen pen = new Pen(Color.Green, 5);
        public void DrawEndPoint(Graphics g, IPoint endp, IPoint preendp)
        {
            pen.Width = 6;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            g.DrawLine(pen, (float)preendp.X, (float)preendp.Y, (float)endp.X, (float)endp.Y);
        }

        public void DrawStartPoint(Graphics g, IPoint startp)
        {
            g.DrawEllipse(pen, (float)startp.X, (float)startp.Y, 3, 3);
        }
    }
}
