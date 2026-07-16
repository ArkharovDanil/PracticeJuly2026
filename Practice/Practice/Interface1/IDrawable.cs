using Practice.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Practice.Interface1
{
    internal interface IDrawable
    {
        void Draw(IImplementor _imp);
    }
}
