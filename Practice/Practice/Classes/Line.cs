using Practice.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Classes
{
    public class Line : ACurve
    {
        public Line(IPoint a, IPoint b) : base(a, b)
        {
        }

        public override double CountX(double t) //p = (1 − t) · a + t · b

        {
            return (1 - t) * GetA().X + t * GetB().X;
        }
        public override double CountY(double t)
        {
            return (1 - t) * GetA().Y + t * GetB().Y;
        }
    }
}
