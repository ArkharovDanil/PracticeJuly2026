using Aspose.Svg;
using Aspose.Svg.Rendering.Image;
using Practice.Bridge;
using Practice.Classes;
using Svg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Practice
{
    public partial class Form1 : Form
    {
        private Random rnd = new Random();
        private Line _line;
        private Bezier _bezier;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Paint += DrawPictureBox1;
            pictureBox2.Paint += DrawPictureBox2;
        }

        private void DrawPictureBox1(object sender, PaintEventArgs e)
        {
            if (_line == null) return;

            VisualLine drawLine = new VisualLine(_line);
            drawLine.Draw(e.Graphics);
        }

        private void DrawPictureBox2(object sender, PaintEventArgs e)
        {
            if (_bezier == null) return;

            VisualBezier drawBezier = new VisualBezier(_bezier);
            drawBezier.Draw(e.Graphics);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Classes.Point a = new Classes.Point(rnd.Next(250), rnd.Next(250));
            Classes.Point b = new Classes.Point(rnd.Next(250), rnd.Next(250));
            _line = new Line(a, b);

            Classes.Point pa = new Classes.Point(rnd.Next(250), rnd.Next(250));
            Classes.Point pb = new Classes.Point(rnd.Next(250), rnd.Next(250));
            Classes.Point pc = new Classes.Point(rnd.Next(250), rnd.Next(250));
            Classes.Point pd = new Classes.Point(rnd.Next(250), rnd.Next(250));
            _bezier = new Bezier(pa, pb, pc, pd);

            pictureBox1.Invalidate();
            pictureBox2.Invalidate();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_line == null) return;

            VisualLine drawLine = new VisualLine(_line);
            string svg = drawLine.ExportToSvg(pictureBox1.Width, pictureBox1.Height);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "SVG files (*.svg)|*.svg";
            dialog.FileName = "line.svg";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(dialog.FileName, svg);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_bezier == null) return;

            VisualBezier drawBezier = new VisualBezier(_bezier);
            string svg = drawBezier.ExportToSvg(pictureBox2.Width, pictureBox2.Height);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "SVG files (*.svg)|*.svg";
            dialog.FileName = "line.svg";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(dialog.FileName, svg);
            }
        }
    }
}

