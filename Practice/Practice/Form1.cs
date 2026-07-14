using Practice.Classes;
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
//using Aspose.SVG;
//using Aspose.SVG.ImageVectorization;


namespace Practice
{
    public partial class Form1 : Form
    {

        private Random rnd = new Random();
        private Line _line;
        private Bezier _bez;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Paint += DrawGreen;
            pictureBox2.Paint += DrawBlack;
        }

        

        private void DrawGreen(object sender, PaintEventArgs e)
        {
            if (_line == null) return;
            VisualLine drawLine = new VisualLine(_line);
            drawLine.Draw(e.Graphics);
        }

        private void DrawBlack(object sender, PaintEventArgs e)
        {
            if (_bez == null) return;

            VisualBezier drawBez = new VisualBezier(_bez);
            drawBez.Draw(e.Graphics);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Classes.Point a = new Classes.Point(rnd.Next(350), rnd.Next(250));
            Classes.Point b = new Classes.Point(rnd.Next(350), rnd.Next(250));
            _line = new Line(a, b);

            Classes.Point c = new Classes.Point(rnd.Next(350), rnd.Next(250));
            Classes.Point d = new Classes.Point(rnd.Next(350), rnd.Next(250));
            Classes.Point f = new Classes.Point(rnd.Next(350), rnd.Next(250));
            Classes.Point g = new Classes.Point(rnd.Next(350), rnd.Next(250));
            _bez = new Bezier(c, d, f, g);


            pictureBox1.Invalidate();
            pictureBox2.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Bitmap bmpSave = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //pictureBox1.DrawToBitmap(bmpSave, new Rectangle(0, 0, bmpSave.Width, bmpSave.Height));
            //bmpSave.Save("output.svg", System.Drawing.Imaging.ImageFormat.Svg);

            //Bitmap bmpSave = (Bitmap)pictureBox2.Image;
            //SaveFileDialog sfd = new SaveFileDialog();
            //sfd.DefaultExt = "bmp";
            //sfd.Filter = "Image files (*.bmp)|*.bmp|All files (*.*)|*.*";
            //if (sfd.ShowDialog() == DialogResult.OK)
            //{
            //    bmpSave.Save(sfd.FileName, ImageFormat.Bmp);
            //}


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
            if (_bez == null) return;

            VisualBezier drawBez = new VisualBezier(_bez);
            string svg = drawBez.ExportToSvg(pictureBox2.Width, pictureBox2.Height);

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
