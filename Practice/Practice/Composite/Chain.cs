using Practice.Bridge;
using Practice.Classes;
using Practice.Decorator;
using Practice.interfaces;
using System;
using System.Windows.Forms;

public class Chain : ICurve
{
    ICurve _curve1; // 4 точки
    ICurve _curve2; // 4 точки

    public Chain(ICurve curve1, ICurve curve2)
    {
        _curve1 = curve1;
        _curve2 = curve2;
    }
    public Chain()
    {
    }
    public void GetPoint(double t, out IPoint p)
    {
        if (t <= 0.5)
        {
            double t1 = t * 2;
            _curve1.GetPoint(t1, out p);
        }
        else
        {
            double t1 = (t - 0.5) * 2;
            _curve2.GetPoint(t1, out p);
        }
    }
}