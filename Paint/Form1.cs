using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        private Canvas _canvas;
        private Tool _tool;

        public Form1()
        {
            InitializeComponent();

            // Create and add a new Canvas.
            _canvas = new Canvas();
            Controls.Add(_canvas.View);

            _tool = new BrushTool();
        }

        public void CanvasView_MouseDown(object sender, MouseEventArgs e)
        {
            _tool.OnMouseDown(sender, e);
        }

        public void CanvasView_MouseUp(object sender, MouseEventArgs e)
        {
            _tool.OnMouseUp(sender, e);
        }

        public void CanvasView_MouseMove(object sender, MouseEventArgs e)
        {
            _tool.OnMouseMove(sender, e);
        }
    }
}
