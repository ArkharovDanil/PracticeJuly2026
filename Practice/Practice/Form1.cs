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
        private Options _options1 = null;
        private Options _options2 = null;

        public Form1()
        {
            InitializeComponent();
            _options1 = new Options
            {
                FileBuffer = string.Empty,
                Graphics = pictureBox2.CreateGraphics()
            };
            _options2 = new Options
            {
                FileBuffer = string.Empty,
                Graphics = pictureBox1.CreateGraphics()
            };

        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            var generatedLine = GenerateCurve();
            AVisualCurve blackRealization = new BlackRealization(generatedLine, _options1);
            AVisualCurve greenRealization = new GreenRealization(generatedLine, _options2);
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




        private void button3_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //    if (_line.Count == 0 && _bez.Count == 0) return;

            //    string svg = BuildSVG(_greenimp, pictureBox1.Width, pictureBox1.Height, true);

            //    SaveFileDialog dialog = new SaveFileDialog();
            //    dialog.Filter = "SVG files (*.svg)|*.svg";
            //    dialog.FileName = "green.svg";

            //    if (dialog.ShowDialog() == DialogResult.OK)
            //    {
            //        System.IO.File.WriteAllText(dialog.FileName, svg);
            //    }

        }
    }
}
