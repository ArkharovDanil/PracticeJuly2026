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
        private IImplementor _greenimp;
        private IImplementor _blackimp;

        public Form1()
        {
            InitializeComponent();
            Graphics g1 = pictureBox1.CreateGraphics();
            Graphics g2 = pictureBox2.CreateGraphics();
            _greenimp = new GreenRealization(g1);
            _blackimp = new BlackRealization(g2);
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            Classes.Point a = new Classes.Point(rnd.Next(350), rnd.Next(250));
            Classes.Point b = new Classes.Point(rnd.Next(350), rnd.Next(250));
            var line = new Line(a, b);

            Classes.Point c = new Classes.Point(rnd.Next(350), rnd.Next(250));
            Classes.Point d = new Classes.Point(rnd.Next(350), rnd.Next(250));
            Classes.Point f = new Classes.Point(rnd.Next(350), rnd.Next(250));
            Classes.Point g = new Classes.Point(rnd.Next(350), rnd.Next(250));
            var bezier = new Bezier(c, d, f, g);

  
            pictureBox1.Invalidate();
            pictureBox2.Invalidate();
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
