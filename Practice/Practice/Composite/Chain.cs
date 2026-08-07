using Practice.Classes;
using Practice.Decorator;
using Practice.Interface1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Composite
{
    public class Chain : ICurve
    {
        ICurve _curve1; // 4 точки
        ICurve _curve2; // 4 точки
        private readonly int _segments = 20;

        public Chain(ICurve curve1, ICurve curve2)
        {
            _curve1 = curve1;
            _curve2 = curve2;
        }

        public void GetPoint(double t, out IPoint p)
        {
            if (t <= 0.5)
            {
                double t1 = t * 2;
                _curve1.GetPoint(t1, out p);
            }
            else
            {
                double t1 = (t - 0.5) * 2;
                _curve2.GetPoint(t1, out p);
            }
        }
    }
}
