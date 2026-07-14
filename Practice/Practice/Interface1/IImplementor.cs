using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Interface1
{
    public interface IImplementor
    {
        void DrawStartPoint(Graphics g, IPoint startp);
        void DrawEndPoint(Graphics g, IPoint endp, IPoint preendp);
    }
}
