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
    class EraseTool : Tool
    {
        private Pen _pen;
        private bool _drawing = false;
        private Point _previousPoint;

        public override float Size
        {
            get { return _pen.Width; }
            set { _pen.Width = value; }
        }

        public EraseTool()
        {
            Color = Color.White;
            ColorChangeable = false;

            _pen = new Pen(Color, 0);
            Size = 5;

            _pen.StartCap = _pen.EndCap = LineCap.Round;
        }

        public override void OnMouseDown(object sender, MouseEventArgs e)
        {
            _drawing = true;

            CanvasView canvasView = sender as CanvasView;
            _previousPoint = canvasView.GetBitmapLocation(e.Location);

            Canvas canvas = canvasView.Canvas;
            canvas.FillCircle(_pen, _previousPoint);
        }

        public override void OnMouseUp(object sender, MouseEventArgs e)
        {
            _drawing = false;
        }

        public override void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_drawing)
            {
                CanvasView canvasView = sender as CanvasView;
                Point currentPoint = canvasView.GetBitmapLocation(e.Location);

                Canvas canvas = canvasView.Canvas;
                canvas.DrawLine(_pen, _previousPoint, currentPoint);

                _previousPoint = currentPoint;
            }
        }
    }
}
