using Practice.Interfaces;

namespace Practice.Classes
{
    internal class Point : IPoint
    {
        private double _x;
        private double _y;
        public double GetX()
        {
            return _x;
        }

        public double GetY()
        {
            return _y;
        }

        public void SetX(double x)
        {
            _x = x;
        }

        public void SetY(double y)
        {
            _y = y;
        }
    }
}
