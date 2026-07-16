using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpfApp.Interfaces
{
    public interface ICurve
    {
        public void GetPoint(double t, out Ipoint p);
    }
}
