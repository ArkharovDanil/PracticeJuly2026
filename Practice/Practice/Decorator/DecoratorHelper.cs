using Practice.Bridge;
using Practice.Classes;
using Practice.interfaces;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Practice.Decorator
{
    internal class DecoratorHelper
    {
        private List<ICurve> _curves = new List<ICurve>();
        private Options _options1 = null;
        private Options _options2 = null;
        public DecoratorHelper(List<ICurve> curves, Options options1, Options options2)
        {
            _curves = curves;
            _options1 = options1;
            _options2 = options2;
        }

        public void ReplaceLastCurve(ICurve newCurve)
        {
            if (_curves.Count == 0) return;
            _curves[_curves.Count - 1] = newCurve;
        }

        public void RedrawBoth(PictureBox pictureBox1, PictureBox pictureBox2)
        {
            _options1.Graphics.Clear(pictureBox1.BackColor);
            _options2.Graphics.Clear(pictureBox2.BackColor);

            foreach (var curve in _curves)
            {
                AVisualCurve blackRealization = new BlackRealization(curve, _options1);
                AVisualCurve greenRealization = new GreenRealization(curve, _options2);
                blackRealization.Draw();
                greenRealization.Draw();
            }
        }
        public void HandleMoveClick(System.Drawing.Point clickLocation, ICurve _lastCurve, PictureBox pictureBox1, PictureBox pictureBox2)
        {
            if (_lastCurve == null) return;

            IPoint target = new Classes.Point(clickLocation.X, clickLocation.Y);
            _lastCurve = new MoveTo(_lastCurve, target);
            ReplaceLastCurve(_lastCurve);

            RedrawBoth(pictureBox1, pictureBox2);
        }
    }
}
