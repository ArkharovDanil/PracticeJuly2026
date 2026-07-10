using Practice.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Classes
{
    public abstract class ACurve : ICurve
    {
        private IPoint _a;
        private IPoint _b;

        public ACurve(IPoint a, IPoint b)
        {
            _a = a;
            _b = b;
        }

        public IPoint GetA()
        {
            return _a;
        }
        public IPoint GetB()
        {
            return _b;
        }
         public void GetPoint(double t, out IPoint p)
        {
            Point point = new Point();
            point.SetX(CountX(t));
            point.SetY(CountY(t));
            p = point;
        }
        public abstract double CountX(double t);
        public abstract double CountY(double t);


    }
}
