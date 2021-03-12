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
        public CanvasView View { get; }

        public Bitmap Bitmap { get; }
        public Graphics Graphics { get; }

        public Canvas()
        {
            View = new CanvasView(this);

            Bitmap = new Bitmap(800, 600);
            Graphics = Graphics.FromImage(Bitmap);
            Graphics.Clear(Color.White);

            // TODO: Remove example line.
            Graphics.DrawLine(new Pen(Color.Black, 5), new Point(0, 0), new Point(800, 600));
        }
    }
}
