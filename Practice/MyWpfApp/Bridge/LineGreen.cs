using MyWpfApp.Interfaces;
using System.Windows.Media;

namespace MyWpfApp.Bridge
{
    public class LineGreen : Implement
    {
        private Pen _linePen = new Pen(Brushes.Green, 3);
        private Brush _startBrush = Brushes.Green;
        private System.Windows.Point _lastSegmentStart;
        private System.Windows.Point _lastSegmentEnd;

        public void DrawSegment(DrawingContext dc, System.Windows.Point startPoint, System.Windows.Point endPoint)
        {
            //сохраняем для стрелки
            _lastSegmentStart = startPoint;
            _lastSegmentEnd = endPoint;

            dc.DrawLine(_linePen, startPoint, endPoint);
        }

        public void DrawStartpoint(DrawingContext dc, System.Windows.Point point)
        {
            dc.DrawEllipse(_startBrush, null, point, 5, 5);
        }

        public void DrawEndpoint(DrawingContext dc, System.Windows.Point endPoint, System.Windows.Point preEndPoint)
        {
            Pen arrowPen = new Pen(Brushes.Green, 15);
            arrowPen.EndLineCap = PenLineCap.Triangle;

            dc.DrawLine(arrowPen, preEndPoint, endPoint);
        }
    }
}