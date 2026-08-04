using Practice.Bridge;
using Practice.Classes;
using Practice.Decorator;
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
        private ICurve _lastCurve;
        private bool _isMove;
        private DecoratorHelper Helper;

        public Form1()
        {
            InitializeComponent();
            _options1 = new Options
            {
                Graphics = pictureBox1.CreateGraphics()
            };
            _options2 = new Options
            {
                Graphics = pictureBox2.CreateGraphics()
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ICurve newCurve = GenerateCurve();

            if (_isMove && _lastCurve != null)
            {
                _lastCurve.GetPoint(1, out IPoint previousEnd);
                newCurve = new MoveTo(newCurve, previousEnd);
            }
            _curves.Add(newCurve);
            Helper = new DecoratorHelper(_curves, _options1, _options2);
            _lastCurve = newCurve;

            Helper.RedrawBoth(pictureBox1, pictureBox2);
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (_lastCurve == null) return;

            _lastCurve = new Fragment(_lastCurve, 1, 0);
            Helper.ReplaceLastCurve(_lastCurve);

            Helper.RedrawBoth(pictureBox1, pictureBox2);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Helper.HandleMoveClick(e.Location, _lastCurve, pictureBox1, pictureBox2);
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            Helper.HandleMoveClick(e.Location, _lastCurve, pictureBox1, pictureBox2);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _isMove = radioButton1.Checked;
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