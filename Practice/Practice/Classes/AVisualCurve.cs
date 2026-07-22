using Practice.Interface1;


namespace Practice.Classes
{
    public abstract class AVisualCurve : ICurve, IDrawable
    {
        public abstract void DrawLine(IPoint from, IPoint to);

        public abstract void DrawStartPoint(IPoint startp);

        public abstract void DrawEndPoint(IPoint endp, IPoint preendp);


        public abstract void Draw(IImplementor _imp);
        public abstract void GetPoint(double t, out IPoint p);
    }
}
