﻿using System;
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

            Paint += this_Paint;
        }

        public void this_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics graphics = CreateGraphics())
            {
                graphics.DrawImage(Canvas.Bitmap, 0, 0, Width, Height);
            }
        }
    }
}
