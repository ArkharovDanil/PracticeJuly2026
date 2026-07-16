using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


namespace MyWpfApp.Interfaces
{
    public interface Implement
    {

        void DrawStartpoint(DrawingContext dc, System.Windows.Point point);
        void DrawSegment(DrawingContext dc, System.Windows.Point startPoint, System.Windows.Point endPoint);
        void DrawEndpoint(DrawingContext dc, System.Windows.Point endPoint, System.Windows.Point preEndPoint);

    }
}
