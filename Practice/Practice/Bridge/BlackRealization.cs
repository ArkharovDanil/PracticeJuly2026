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
    public class BlackRealization : IImplementor
    {
        private Pen pen = new Pen(Color.Black, 5);
        public void DrawEndPoint(Graphics g, IPoint endp, IPoint preendp)
        {
            pen.Width = 6;
            g.DrawRectangle(pen, (float)endp.X, (float)endp.Y, 3, 3);
        }

        public void DrawStartPoint(Graphics g, IPoint startp)
        {
            pen.Width = 6;
            g.DrawRectangle(pen, (float)startp.X, (float)startp.Y, 3, 3);
        }
    }
}
