using MyWpfApp.Classes;
using MyWpfApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MyWpfApp.Bridge
{
    public class BezierBlack : Implement
    {
 
        private Pen _dottedPen;
        private Brush _blackBrush = Brushes.Black;

        public BezierBlack()
        {
            _dottedPen = new Pen(Brushes.Black, 3);
            _dottedPen.DashStyle = DashStyles.Dash;
        }

        public void DrawSegment(DrawingContext dc, System.Windows.Point startPoint, System.Windows.Point endPoint)
        {
            dc.DrawLine(_dottedPen, startPoint, endPoint);
        }

        public void DrawStartpoint(DrawingContext dc, System.Windows.Point point)
        {
            Rect rect = new Rect(point.X - 4, point.Y - 4, 8, 8);
            dc.DrawRectangle(_blackBrush, null, rect);
        }

        public void DrawEndpoint(DrawingContext dc, System.Windows.Point point, System.Windows.Point preEndPoint)
        {
            Rect rect = new Rect(point.X - 4, point.Y - 4, 8, 8);
            dc.DrawRectangle(_blackBrush, null, rect);
        }
    }
}