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

        public Form1()
        {
            InitializeComponent();

            // Create and add a new Canvas.
            _canvas = new Canvas();
            Controls.Add(_canvas.View);
        }

        public void CanvasView_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Mouse Down");
        }

        public void CanvasView_MouseUp(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Mouse Up");
        }

        public void CanvasView_MouseMove(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Mouse Move");
        }
    }
}
