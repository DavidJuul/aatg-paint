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
        public BucketTool()
        {
            Color = Color.Black;
        }

        public override void OnMouseDown(object sender, MouseEventArgs e)
        {
            CanvasView canvasView = sender as CanvasView;

            Canvas canvas = canvasView.Canvas;
            canvas.Fill(Color);
        }

        public override void OnMouseUp(object sender, MouseEventArgs e) { }

        public override void OnMouseMove(object sender, MouseEventArgs e) { }
    }
}
