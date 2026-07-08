using Practice.Interfaces;
using System;


namespace Practice.Classes
{
    public abstract class ACurve : ICurve
    {
        //Приватные поля
        private IPoint _a;
        private IPoint _b;

        //Конструктор и публичные методы
        public ACurve(IPoint a, IPoint b)
        {
            _a = a;
            _b = b;
        }

        public IPoint GetPoint(double t)
        {
            Point point = new Point();
            point.SetX(CountX());
            point.SetY(CountY());
            return point;
        }

        public abstract double CountX();
        public abstract double CountY();

        //Приватные методы
    }
}
