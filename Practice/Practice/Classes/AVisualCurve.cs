using Practice.Interface1;


namespace Practice.Classes
{
    public abstract class AVisualCurve : ICurve, IDrawable
    {
        abstract public void Draw(IImplementor _imp);

        abstract public void GetPoint(double t, out IPoint p);

        abstract public string ExportToSvg(IImplementor _imp/*, int width, int height*/);
    }
}
