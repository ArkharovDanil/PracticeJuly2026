using Practice.Decorator;
using Practice.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Composite
{
    public class CompositeHelper
    {
        public ICurve Generate(ICurve curve1, ICurve curve2, ICurve curve3)
        {

            curve1.GetPoint(1, out IPoint previousEnd);
            curve2 = new MoveTo(curve2, previousEnd);
            ICurve FirstChain = new Chain(curve1, curve2);

            FirstChain.GetPoint(1, out IPoint previousEnd2);
            curve3 = new MoveTo(curve3, previousEnd2);

            ICurve SecondChain = new Chain(FirstChain, curve3);
            return SecondChain;
        }
    }
}
