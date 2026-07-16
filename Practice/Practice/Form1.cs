using Practice.Bridge;
using Practice.Classes;
using Practice.Interface1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace Practice
{
    public partial class Form1 : Form
    {

        private Random rnd = new Random();
        private List<Line> _line = new List<Line>();
        private List<Bezier> _bez = new List<Bezier>();
        private IImplementor _greenimp = new GreenRealization();
        private IImplementor _blackimp = new BlackRealization();
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Paint += DrawGreen;
            pictureBox2.Paint += DrawBlack;
        }

        private void DrawGreen(object sender, PaintEventArgs e)
        {
            if (_line == null) return;
            if (_bez == null) return;

            foreach (var bez in _bez)
            {
                VisualBezier drawBez = new VisualBezier(bez, e.Graphics);
                drawBez.Draw(_greenimp);
            }

            foreach (var line in _line)
            {
                VisualLine drawLine = new VisualLine(line, e.Graphics);
                drawLine.Draw(_greenimp);
            }
            
        }

        private void DrawBlack(object sender, PaintEventArgs e)
        {
            if (_line == null) return;
            if (_bez == null) return;

            foreach (var bez in _bez)
            {
                VisualBezier drawBez = new VisualBezier(bez, e.Graphics);
                drawBez.Draw(_blackimp);
            }

            foreach (var line in _line)
            {
                VisualLine drawLine = new VisualLine(line, e.Graphics);
                drawLine.Draw(_blackimp);
            }

        }

        private string BuildSVG(IImplementor implementor, int width, int height, bool arrowmarker)
        {
            var sb = new System.Text.StringBuilder();
            sb.AppendLine($"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{width}\" height=\"{height}\">");
            if (arrowmarker)
            {
                sb.AppendLine("<defs>");
                sb.AppendLine("<marker id=\"arrowhead\" markerWidth=\"5\" markerHeight=\"3.5\" refX=\"4.5\" refY=\"1.75\" orient=\"auto\">");
                sb.AppendLine("<polygon points=\"0 0, 5 1.75, 0 3.5\" fill=\"green\" />");
                sb.AppendLine("</marker>");
                sb.AppendLine("</defs>");
            }
            foreach (var line in _line)
            {
                VisualLine drawLine = new VisualLine(line);
                sb.AppendLine(drawLine.ExportToSvg(implementor));
            }
            foreach (var bezier in _bez)
            {
                VisualBezier drawBezier = new VisualBezier(bezier);
                sb.AppendLine(drawBezier.ExportToSvg(implementor));
            }
            sb.AppendLine("</svg>");
            return sb.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Classes.Point a = new Classes.Point(rnd.Next(350), rnd.Next(250));
            Classes.Point b = new Classes.Point(rnd.Next(350), rnd.Next(250));
            _line.Add(new Line(a, b));

            Classes.Point c = new Classes.Point(rnd.Next(350), rnd.Next(250));
            Classes.Point d = new Classes.Point(rnd.Next(350), rnd.Next(250));
            Classes.Point f = new Classes.Point(rnd.Next(350), rnd.Next(250));
            Classes.Point g = new Classes.Point(rnd.Next(350), rnd.Next(250));
            _bez.Add(new Bezier(c, d, f, g));


            pictureBox1.Invalidate();
            pictureBox2.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (_line.Count == 0 && _bez.Count == 0) return;

            string svg = BuildSVG(_greenimp, pictureBox1.Width, pictureBox1.Height, true);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "SVG files (*.svg)|*.svg";
            dialog.FileName = "green.svg";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(dialog.FileName, svg);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_line.Count == 0 && _bez.Count == 0) return;

            string svg = BuildSVG(_blackimp, pictureBox2.Width, pictureBox2.Height, false);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "SVG files (*.svg)|*.svg";
            dialog.FileName = "black.svg";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                System.IO.File.WriteAllText(dialog.FileName, svg);
            }

        }
    }
}
