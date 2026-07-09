using Practice.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Paint += DrawImage;
        }

        private void DrawImage(object sender, PaintEventArgs e)
        {
            Classes.Point a = new Classes.Point(5,5);
            Classes.Point b = new Classes.Point(100,100);
            Line line = new Line(a, b);
            VisualLine drawLine = new VisualLine(line);
            drawLine.Draw(e.Graphics);

            Classes.Point c = new Classes.Point(200, 200);
            Classes.Point d = new Classes.Point(330, 330);
            Classes.Point f = new Classes.Point(410, 150);
            Classes.Point g = new Classes.Point(150, 110);
            Bezier bez = new Bezier(c, d, f, g);
            VisualBezier drawBez = new VisualBezier(bez);
            drawBez.Draw(e.Graphics);
        }
    }
}
