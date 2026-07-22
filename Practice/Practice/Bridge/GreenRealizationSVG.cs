using Practice.Classes;
using Practice.Interface1;
using System.Net;

namespace Practice.Bridge
{
    public class GreenRealizationSVG : AVisualCurve
    {
        public override void Draw(IImplementor _imp)
        {
            throw new System.NotImplementedException();
        }

        public override void DrawEndPoint(IPoint endp, IPoint preendp)
        {
            throw new System.NotImplementedException();
        }

        public override void DrawLine(IPoint from, IPoint to)
        {
            throw new System.NotImplementedException();
        }

        public override void DrawStartPoint(IPoint startp)
        {
            throw new System.NotImplementedException();
        }

        public override void GetPoint(double t, out IPoint p)
        {
            throw new System.NotImplementedException();
        }
    }
}
