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
            CreateGraphics();
            _graphics.Clear(Color.White);
        }

        private void CreateGraphics()
        {
            _graphics = Graphics.FromImage(Bitmap);
            _graphics.SmoothingMode = SmoothingMode.AntiAlias;
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

        public void DrawText(string text, Font font, Color color, Point point)
        {
            Brush brush = new SolidBrush(color);
            _graphics.DrawString(text, font, brush, point.X, point.Y);
            View.this_Paint(this, null);
        }

        public void Clear()
        {
            _graphics.Clear(Color.White);
            View.this_Paint(this, null);
        }

        public void Fill(Color Color)
        {
            _graphics.Clear(Color);
            View.this_Paint(this, null);
        }

        public void Replace(Bitmap bitmap)
        {
            Bitmap = bitmap;
            CreateGraphics();
            View.this_Paint(this, null);
        }

        public void Save(string filePath)
        {
            Bitmap.Save(filePath);
        }

        public void Open(string filePath)
        {
            Bitmap = new Bitmap(filePath);
            CreateGraphics();
            View.this_Paint(this, null);
        }
    }
}
