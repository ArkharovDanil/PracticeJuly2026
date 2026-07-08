using Practice.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Classes
{
    public class Line : ACurve
    {
        private IPoint _a;
        private IPoint _b;
        public Line(IPoint a, IPoint b) : base(a, b)
        {
            _a = a;
            _b = b;
        }
        //p=(1−t)·a+t·b
        
        private double CountX()
        {
            return _a.GetX() + _b.GetX();
        }

        private double CountY()
        {
            return 0;
        }

    }
}
