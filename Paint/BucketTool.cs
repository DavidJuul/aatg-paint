using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    class BucketTool : Tool
    {
        private bool _drawing = false;

        public Color Color;

        public BucketTool()
        {
            Color = Color.White;
        }

        public override void OnMouseDown(object sender, MouseEventArgs e)
        {
            _drawing = true;

            CanvasView canvasView = sender as CanvasView;

            Canvas canvas = canvasView.Canvas;
            canvas.Fill(Color);
        }

        public override void OnMouseUp(object sender, MouseEventArgs e)
        {
            _drawing = false;
        }

        public override void OnMouseMove(object sender, MouseEventArgs e)
        {
        }
    }
}
