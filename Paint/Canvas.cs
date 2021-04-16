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
        private Bitmap _previousBitmap;

        public Canvas()
        {
            View = new CanvasView(this);

            Bitmap = new Bitmap(1600, 800);
            CreateGraphics();
            _graphics.Clear(Color.White);
            SaveState();
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
            RefreshView();
        }

        public void FillSquare(Pen pen, Point point)
        {
            Brush brush = new SolidBrush(pen.Color);
            _graphics.FillRectangle(brush, point.X - pen.Width / 2, point.Y - pen.Width / 2, pen.Width, pen.Width);
            RefreshView();
        }

        public void DrawLine(Pen pen, Point point1, Point point2)
        {
            _graphics.DrawLine(pen, point1, point2);
            RefreshView();
        }

        public void DrawText(string text, Font font, Color color, Point point)
        {
            Brush brush = new SolidBrush(color);
            _graphics.DrawString(text, font, brush, point.X, point.Y);
            RefreshView();
        }

        public void Clear()
        {
            _graphics.Clear(Color.White);
            RefreshView();
        }

        public void Fill(Color Color)
        {
            _graphics.Clear(Color);
            RefreshView();
        }

        public void RefreshView()
        {
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
            RefreshView();
        }

        public void SaveState()
        {
            _previousBitmap = Bitmap.Clone() as Bitmap;
        }

        public void Undo()
        {
            Bitmap currentBitmap = Bitmap;

            Bitmap = _previousBitmap;
            CreateGraphics();
            RefreshView();

            _previousBitmap = currentBitmap;
        }
    }
}
