using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MyWpfApp.Interfaces
{
    internal interface IDrawable
    {
        void Draw(DrawingContext dc);
    }
}
