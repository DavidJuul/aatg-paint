using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class Canvas
    {
        private Graphics _graphics;

        public CanvasView View { get; }

        public Bitmap Bitmap { get; private set; }

        public Canvas()
        {
            View = new CanvasView(this);

            Bitmap = new Bitmap(800, 600);
            _graphics = Graphics.FromImage(Bitmap);
            _graphics.SmoothingMode = SmoothingMode.AntiAlias;
            _graphics.Clear(Color.White);

            // TODO: Remove example line.
            DrawLine(new Pen(Color.Black, 5), new Point(0, 0), new Point(800, 600));
        }

        public void FillCircle(Pen pen, Point point)
        {
            Brush brush = new SolidBrush(pen.Color);
            _graphics.FillEllipse(brush, point.X - pen.Width / 2, point.Y - pen.Width / 2, pen.Width, pen.Width);
            View.this_Paint(this, null);
        }

        public void FillSquare(Pen pen, Point point)
        {
            Brush brush = new SolidBrush(pen.Color);
            _graphics.FillRectangle(brush, point.X - pen.Width / 2, point.Y - pen.Width / 2, pen.Width, pen.Width);
            View.this_Paint(this, null);
        }

        public void DrawLine(Pen pen, Point point1, Point point2)
        {
            _graphics.DrawLine(pen, point1, point2);
            View.this_Paint(this, null);
        }

        public void Clear()
        {
            _graphics.Clear(Color.White);
            View.this_Paint(this, null);
        }

        public void Save(string filePath)
        {
            Bitmap.Save(filePath);
        }

        public void Open(string filePath)
        {
            Bitmap = new Bitmap(filePath);
            _graphics = Graphics.FromImage(Bitmap);
            View.this_Paint(this, null);
        }
    }
}
