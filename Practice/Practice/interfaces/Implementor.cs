using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.interfaces
{
    public interface IImplementor
    {
        void DrawStartPoint(Graphics g, IPoint start);
        void DrawEndPoint(Graphics g, IPoint end, IPoint preendpoint);

    }
}
