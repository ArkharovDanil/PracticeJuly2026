using Practice.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Practice
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Do();
            Graphics gr = new Graphics();



        }

        // Draw(Graphics gr)

        static void Do()
        {
            Point point1 = new Point();
            point1.SetX(0);
            point1.SetY(0);
            Point point2 = new Point();
            point2.SetX(1);
            point2.SetY(1);

            Line k = new Line(point1,point2);
            k.GetPoint(0.3);//
        }
    }
}
