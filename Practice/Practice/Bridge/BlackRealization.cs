using Practice.interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Bridge
{
    public class BlackRealization : IImplementor
    {
        private Pen pen = new Pen(Color.Black, 5);
        Brush brush = new SolidBrush(Color.Black);
        public void DrawStartPoint(Graphics g, IPoint start)
        {
            g.DrawRectangle(pen, (float)start.X, (float)start.Y, 5, 5);
        }
        public void DrawEndPoint(Graphics g, IPoint end, IPoint preendpoint)
        {
            g.DrawRectangle(pen, (float)end.X, (float)end.Y, 5, 5);
        }
    }
}
