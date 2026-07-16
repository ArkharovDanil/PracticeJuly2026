using Practice.interfaces;
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
        abstract public void GetPoint(double t, out IPoint p);
        abstract public void Draw(IImplementor implementor);

        abstract public string ExportToSvg(IImplementor implementor);

    }
}
