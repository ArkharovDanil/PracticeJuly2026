using MyWpfApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MyWpfApp.Classes
{
    abstract public class VisualCurve
    {
        public Implement Scheme { get; set; }

        public int SegmentsCount { get; set; } = 20;

        public abstract void GetPoint(double t, out Ipoint p);

        public abstract void Draw(DrawingContext dc);
    }
}
