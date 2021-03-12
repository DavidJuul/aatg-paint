using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    class BrushTool : Tool
    {
        private Pen _pen = new Pen(new Color(), 0);
        private bool _drawing = false;
        private Point _previousPoint;

        public Color Color
        {
            get { return _pen.Color; }
            set { _pen.Color = value; }
        }

        public float Width
        {
            get { return _pen.Width; }
            set { _pen.Width = value; }
        }

        public BrushTool()
        {
            Color = Color.Black;
            Width = 5;
        }

        public override void OnMouseDown(object sender, MouseEventArgs e)
        {
            _drawing = true;
        }

        public override void OnMouseUp(object sender, MouseEventArgs e)
        {
            _drawing = false;
        }

        public override void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_drawing)
            {
                Point currentPoint = new Point(e.X, e.Y);
                if (_previousPoint == Point.Empty)
                {
                    _previousPoint = currentPoint;
                }

                Canvas canvas = (sender as CanvasView).Canvas;
                canvas.Graphics.DrawLine(_pen, _previousPoint, currentPoint);

                _previousPoint = currentPoint;
            }
        }
    }
}
