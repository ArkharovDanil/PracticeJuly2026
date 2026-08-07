using Practice.Decorator;
using Practice.Interface1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Composite
{
    public class CompositeHelp
    {
        public CompositeHelp() { }

        public ICurve Generate(ICurve Curve1, ICurve Curve2, ICurve Curve3)
        {
            Curve1.GetPoint(1, out IPoint previousEnd);
            Curve2 = new MoveTo(Curve2, previousEnd);
            ICurve FirstChain = new Chain(Curve1, Curve2);

            FirstChain.GetPoint(1, out IPoint previousEnd2);
            Curve3 = new MoveTo(Curve3, previousEnd2);

            ICurve SecondChain = new Chain(FirstChain, Curve3);
            return SecondChain;
        }
    }
}
