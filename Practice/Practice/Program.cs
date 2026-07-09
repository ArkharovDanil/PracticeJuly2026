using System;
using System.Windows.Forms;
using Practice.Classes;
using System.Drawing;
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
            Do();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void Do()
        {
            Classes.Point a = new Classes.Point(5,5);
            Classes.Point b = new Classes.Point(10, 10);
            Line line = new Line(a, b);
        }
    }
}
