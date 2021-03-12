using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    class CanvasView : Panel
    {
        public Canvas Canvas { get; }

        public CanvasView(Canvas canvas)
        {
            Canvas = canvas;

            Dock = DockStyle.Fill;
            ResizeRedraw = true;

            Paint += this_Paint;
            MouseDown += this_MouseDown;
            MouseUp += this_MouseUp;
            MouseMove += this_MouseMove;
        }

        public void this_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics graphics = CreateGraphics())
            {
                graphics.DrawImage(Canvas.Bitmap, 0, 0, Width, Height);
            }
        }

        public void this_MouseDown(object sender, MouseEventArgs e)
        {
            Form1 form = FindForm() as Form1;
            form.CanvasView_MouseDown(sender, e);
        }

        public void this_MouseUp(object sender, MouseEventArgs e)
        {
            Form1 form = FindForm() as Form1;
            form.CanvasView_MouseUp(sender, e);
        }

        public void this_MouseMove(object sender, MouseEventArgs e)
        {
            Form1 form = FindForm() as Form1;
            form.CanvasView_MouseMove(sender, e);
        }
    }
}
