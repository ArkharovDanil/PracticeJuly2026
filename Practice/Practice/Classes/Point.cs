using Practice.Interface1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Classes
{
    public class Point : IPoint
    {
        public Point()
        {
    
        }
        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }
        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }

        private double _x;
        private double _y;

        internal void SetY(double v)
        {
            _y = v;
        }

        internal void SetX(double v)
        {
            _x = v;
        }
    }
}
