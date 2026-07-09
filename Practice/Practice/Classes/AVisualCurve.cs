using Practice.Interface1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Classes
{
    public abstract class AVisualCurve : ICurve, IDrawable
    {
        abstract public void Draw(Graphics g);

        abstract public void GetPoint(double t, out IPoint p);
    }
}
