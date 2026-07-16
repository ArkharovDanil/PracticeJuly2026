using MyWpfApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MyWpfApp.Classes
{
    public class VisualLine : VisualCurve
    {

        private Line _line;

        public VisualLine(Line line, Implement scheme)
        {
            _line = line;
            Scheme = scheme;
        }


        public override void Draw(DrawingContext dc)
        {
            if (SegmentsCount <= 0 || Scheme == null) return;

           
            GetPoint(0, out Ipoint prevIPoint);
            System.Windows.Point prevPoint = new System.Windows.Point((int)prevIPoint.X, (int)prevIPoint.Y);

            Scheme.DrawStartpoint(dc, prevPoint);

            System.Windows.Point currentPoint = prevPoint;

      
            for (int i = 1; i <= SegmentsCount; i++)
            {
                double t = (double)i / SegmentsCount;
                GetPoint(t, out Ipoint currentIPoint);
                currentPoint = new System.Windows.Point((int)currentIPoint.X, (int)currentIPoint.Y);

                Scheme.DrawSegment(dc, prevPoint, currentPoint);

                prevPoint = currentPoint;
            }


            double preT = (double)(SegmentsCount - 1) / SegmentsCount;
            GetPoint(preT, out Ipoint preIPoint);
            System.Windows.Point preEndPoint = new System.Windows.Point((int)preIPoint.X, (int)preIPoint.Y);

            // Конечная точка со стрелкой
            Scheme.DrawEndpoint(dc, currentPoint, preEndPoint);
        }
        
        

        public override void GetPoint(double t, out Ipoint p)
        {
            _line.GetPoint(t, out p);
        }
    }
}
