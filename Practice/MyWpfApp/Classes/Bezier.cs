using MyWpfApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpfApp.Classes
{
    public class Bezier : ACurve
    {


        public Ipoint _c;
        public Ipoint _d;

        public Bezier( Ipoint a, Ipoint b, Ipoint c, Ipoint d) : base( a, b ) 
        {
            _c = c;
            _d = d;
        }
        

        public override double CountX(double t)
        {
            return Math.Pow(1 - t, 3) * GetA().X + 3*t * Math.Pow(1 - t, 2) * _c.X + 3* Math.Pow(t, 2) * (1-t) * _d.X + Math.Pow(t, 3) * GetB().X;
        }

        public override double CountY(double t)
        {
            return Math.Pow(1 - t, 3) * GetA().Y + 3 * t * Math.Pow(1 - t, 2) * _c.Y + 3 * Math.Pow(t, 2) * (1 - t) * _d.Y + Math.Pow(t, 3) * GetB().Y;
        }
    }
}
