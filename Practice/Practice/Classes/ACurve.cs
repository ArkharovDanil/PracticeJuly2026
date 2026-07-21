using Practice.Interface1;


namespace Practice.Classes
{
    public abstract class ACurve : ICurve
    {
        //приватные поля
        private IPoint _a;
        private IPoint _b;

        //Конструктор и публичные методы
        public ACurve(IPoint a, IPoint b)
        {
            _a = a;
            _b = b;
        }

        public IPoint GetA()
        {
            return _a;
        }

        public IPoint GetB()
        {
            return _b;
        }

        public void GetPoint(double t, out IPoint p)
        {
            var point = new Point();
            point.SetX(CountX(t));
            point.SetY(CountY(t));
            p = point;
        }

        public abstract double CountX(double t);

        public abstract double CountY(double t);

    }
}
