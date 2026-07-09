using Practice.Interface1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        abstract public void GetPoint(double t, out IPoint p);
    }
}
