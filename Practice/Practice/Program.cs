using Practice.Classes;
using Practice.Interface1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Practice
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            DoSmth();

        }

        static void DoSmth()
        {
            Point a = new Point(5,5);
            Point b = new Point(10,10);
            Line line = new Line(a,b);
            //Console.WriteLine(line.);
        }
    }
}
