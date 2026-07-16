using MyWpfApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpfApp.Classes
{
   public class Point : Ipoint
    {
        private double _x;
        private double _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public Point() { }

        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }

        public void SetY(double v)
        {
            _y = v;
        }

        public void SetX(double v) 
        {
            _x = v;
        }


    }
}
