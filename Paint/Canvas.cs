using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    class Canvas
    {
        private Graphics _graphics;

        public CanvasView View { get; }

        public Bitmap Bitmap { get; }

        public Canvas()
        {
            View = new CanvasView(this);

            Bitmap = new Bitmap(800, 600);
            _graphics = Graphics.FromImage(Bitmap);
            _graphics.Clear(Color.White);

            // TODO: Remove example line.
            DrawLine(new Pen(Color.Black, 5), new Point(0, 0), new Point(800, 600));
        }

        public void DrawLine(Pen pen, Point point1, Point point2)
        {
            _graphics.DrawLine(pen, point1, point2);
            View.this_Paint(this, null);
        }
    }
}
