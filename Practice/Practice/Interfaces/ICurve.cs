using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Interfaces
{
    public interface ICurve
    {
        IPoint GetPoint(double t);
    }
}
