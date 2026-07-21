using Practice.Interface1;


namespace Practice.Classes
{
    public class Line : ACurve
    {
   
        public Line(IPoint a, IPoint b) : base(a, b)
        {

        }

        public override double CountX(double t)
        {
            return (1 - t) * GetA().X + t * GetB().X;
        }

        public override double CountY(double t)
        {
            return (1 - t) * GetA().Y + t * GetB().Y;
        }
    }
}
