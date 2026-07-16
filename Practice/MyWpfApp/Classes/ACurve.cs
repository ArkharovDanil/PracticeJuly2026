using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWpfApp.Interfaces;

namespace MyWpfApp.Classes
{
    public abstract class ACurve : ICurve
    {
        private Ipoint _a;
        private Ipoint _b;


        public ACurve (Ipoint a, Ipoint b)
        {
            _a = a;
            _b = b;
        }

        public Ipoint GetA()
        {
            return _a;
        }

        public Ipoint GetB()
        {
            return _b;
        }
        public void GetPoint(double t, out Ipoint p)
        {
            Point point = new Point();
            point.SetX(CountX(t));
            point.SetY(CountY(t));
            p= point;
        }

        public abstract double CountX(double t);
        public abstract double CountY(double t);
    }
}
