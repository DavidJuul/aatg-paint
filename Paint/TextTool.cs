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
    class TextTool : Tool
    {
        private FontFamily _fontFamily = new FontFamily("Arial");
        private Point _point;

        public TextTool()
        { 
            Color = Color.Black;
            Size = 15;
        }

        public override void OnMouseDown(object sender, MouseEventArgs e)
        {
            TextDialog textDialog = new TextDialog();
            DialogResult dialogResult = textDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                CanvasView canvasView = sender as CanvasView;
                _point = canvasView.GetBitmapLocation(e.Location);

                Canvas canvas = canvasView.Canvas;
                Font font = new Font(_fontFamily, Size);

                canvas.DrawText(textDialog.Text, font, Color, _point);
            }            
        }

        public override void OnMouseMove(object sender, MouseEventArgs e)
        {
        }

        public override void OnMouseUp(object sender, MouseEventArgs e)
        {
        }
    }
}
