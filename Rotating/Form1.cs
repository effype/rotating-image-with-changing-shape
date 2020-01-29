using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace Rotating
{
    public partial class Form1 : Form
    {
        Timer _timer;
        Graphics _gfx;
        Bitmap _originalBitmap;
        Bitmap redrawnBitmap;
        Stopwatch _sw;
        double _angle;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _angle = _sw.Elapsed.TotalSeconds * 40;
            //_angle = 270;
            var newBitmap = RotateImage(_originalBitmap, (float)_angle);
        }

        private Bitmap RotateImage(Image bmp, float angle)
        {
            var returnBitmap = new Bitmap(bmp.Width, bmp.Height);

            using (var fromImage = Graphics.FromImage(returnBitmap))
            { 
                fromImage.InterpolationMode = InterpolationMode.HighQualityBicubic;
                fromImage.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
                fromImage.ScaleTransform(0.9F, 0.6F);
                fromImage.RotateTransform(angle);
                fromImage.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
                fromImage.DrawImage(bmp, new Point(0, -52));

                Pen p = new Pen(new SolidBrush(Color.FromArgb(219, 74, 30)), 3);
                Rectangle r = new Rectangle(120, 60, 100, 60);
                fromImage.DrawEllipse(p, r);

                fromImage.Dispose();
            }
            pictureBox1.Image = returnBitmap;
            return returnBitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _timer = new Timer
            {
                Interval = 16,
                Enabled = true
            };
            _timer.Tick += timer1_Tick;
            _sw = new Stopwatch();
            _sw.Start();
            _gfx = CreateGraphics();

            _originalBitmap = new Bitmap(255, 255);
            redrawnBitmap = new Bitmap(255, 255);
        }
    }
}
