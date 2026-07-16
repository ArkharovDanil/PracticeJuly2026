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
using Practice.interfaces;
namespace Practice
{
    public partial class Form1 : Form
    {
        private IImplementor greenImpl = new GreenRealization();
        private IImplementor blackImpl = new BlackRealization();
        private Random rnd = new Random();
        private List<Line> _line = new List<Line>();
        private List<Bezier> _bezier = new List<Bezier>();
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Paint += DrawPictureBox1;
            pictureBox2.Paint += DrawPictureBox2;
        }

        private void DrawPictureBox1(object sender, PaintEventArgs e)
        {


            if (_line == null) return;
            foreach (var line in _line)
            {
                VisualLine drawLine = new VisualLine(line, e.Graphics);
                drawLine.Draw(greenImpl);

            }
            foreach (var bezier in _bezier)
            {
                VisualBezier drawBezier = new VisualBezier(bezier, e.Graphics);
                drawBezier.Draw(greenImpl);
            }
        }

        private void DrawPictureBox2(object sender, PaintEventArgs e)
        {

            if (_bezier == null) return;
            foreach (var line in _line)
            {
                VisualLine drawLine = new VisualLine(line, e.Graphics);
                drawLine.Draw(blackImpl);

            }
            foreach (var bezier in _bezier)
            {
                VisualBezier drawBezier = new VisualBezier(bezier, e.Graphics);
                drawBezier.Draw(blackImpl);
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Classes.Point a = new Classes.Point(rnd.Next(250), rnd.Next(250));
            Classes.Point b = new Classes.Point(rnd.Next(250), rnd.Next(250));
            _line.Add(new Line(a, b));

            Classes.Point pa = new Classes.Point(rnd.Next(250), rnd.Next(250));
            Classes.Point pb = new Classes.Point(rnd.Next(250), rnd.Next(250));
            Classes.Point pc = new Classes.Point(rnd.Next(250), rnd.Next(250));
            Classes.Point pd = new Classes.Point(rnd.Next(250), rnd.Next(250));
            _bezier.Add(new Bezier(pa, pb, pc, pd));

            pictureBox1.Invalidate();
            pictureBox2.Invalidate();

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
            foreach (var bezier in _bezier)
            {
                VisualBezier drawBezier = new VisualBezier(bezier);
                sb.AppendLine(drawBezier.ExportToSvg(implementor));
            }
            sb.AppendLine("</svg>");
            return sb.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_line.Count == 0 && _bezier.Count == 0) return;

            string svg = BuildSVG(greenImpl, pictureBox1.Width, pictureBox1.Height, true);

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
            if (_line.Count == 0 && _bezier.Count == 0) return;

            string svg = BuildSVG(blackImpl, pictureBox2.Width, pictureBox2.Height, false);

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

