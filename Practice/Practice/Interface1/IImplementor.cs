using System.Drawing;


namespace Practice.Interface1
{
    public interface IImplementor
    {
        void DrawLine(/*Graphics g, */IPoint from, IPoint to);

        void DrawStartPoint(/*Graphics g, */IPoint startp);

        void DrawEndPoint(/*Graphics g,*/ IPoint endp, IPoint preendp);

        string DrawLineSVG(IPoint from, IPoint to);

        string DrawStartPointSVG(IPoint startp);

        string DrawEndPointSVG(IPoint endp, IPoint preendp);

    }
}
