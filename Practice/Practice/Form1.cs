using Practice.Bridge;
using Practice.Classes;
using Practice.interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Practice
{
    public partial class Form1 : Form
    {
        private BuilderSVG builder = new BuilderSVG();
        private Random rnd = new Random();
        private Options _options1 = null;
        private Options _options2 = null;
        private List<ICurve> _curves = new List<ICurve>();

        public Form1()
        {
            InitializeComponent();
            _options1 = new Options
            {
                Graphics = pictureBox2.CreateGraphics()
            };
            _options2 = new Options
            {
                Graphics = pictureBox1.CreateGraphics()
            };

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var generatedLine = GenerateCurve();
            _curves.Add(generatedLine);
            AVisualCurve blackRealization = new BlackRealization(generatedLine, _options1);
            AVisualCurve greenRealization = new GreenRealization(generatedLine, _options2);
            AVisualCurve greenRealizationSVG = new GreenRealizationSVG(generatedLine);
            blackRealization.Draw();
            greenRealization.Draw();
        }

        private ICurve GenerateCurve()
        {
            var coin = rnd.Next(2) % 2 == 0;
            if (coin)
            {
                Classes.Point a = new Classes.Point(rnd.Next(350), rnd.Next(250));
                Classes.Point b = new Classes.Point(rnd.Next(350), rnd.Next(250));
                return new Line(a, b);
            }

            Classes.Point c = new Classes.Point(rnd.Next(350), rnd.Next(250));
            Classes.Point d = new Classes.Point(rnd.Next(350), rnd.Next(250));
            Classes.Point f = new Classes.Point(rnd.Next(350), rnd.Next(250));
            Classes.Point g = new Classes.Point(rnd.Next(350), rnd.Next(250));
            return new Bezier(c, d, f, g);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_curves.Count == 0) return;
            string svg = builder.BuildSVG(_curves, pictureBox1.Width, pictureBox1.Height, true);

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
            if (_curves.Count == 0) return;

            string svg = builder.BuildSVG(_curves, pictureBox1.Width, pictureBox1.Height, false);

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