using MyWpfApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpfApp.Classes
{
    public class Line : ACurve
    {
        public Line(Ipoint a, Ipoint b) : base(a, b)
        {
    
        }


        public override double CountX(double t)
        {
            return (1 - t) * GetA().X + t * GetB().X ;
        }

        public override double CountY(double t)
        {
            return (1 - t) * GetA().Y + t * GetB().Y;
        }
    }
}
